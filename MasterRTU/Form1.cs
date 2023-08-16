using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace MasterRTU
{
    public partial class Form1 : Form
    {
        ModbusClient ModClient = new ModbusClient();
        List<int> slaveIds = new List<int>();
        private const string SlaveIdsFileName = "slaveIds.txt";
        SerialPort serialPort = new SerialPort();
        class SlaveObject
        {
            public int SlaveId { get; set; }
            public int FailCount { get; set; }
        }
        List<SlaveObject> slaveList = new List<SlaveObject>();

        public Form1()
        {
            InitializeComponent();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // ...
        }
        //Funcion de cuando se toca el boton de Connect:

        //Configura el Modbus segun los datos que se le indican (baud y PORT)
        //Ademas reconoce los slaves conectados si es la primera vez que se levanta el programa y guarda
        //esa informacion en un txt para evitar hacer un reconocimiento nuevo (lleva mucho tiempo)
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //si la comunicacion esta apagada: se conecta la comunicacion y se setean los valores visibles
            if (btnConnect.Text == "Connect")
            {


                // Configurar los parámetros del puerto serie
                serialPort.PortName = (txtPort.Text);
                serialPort.BaudRate = int.Parse(txtBaud.Text);
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;

                //Inicializa la comunicacion ModBus
                ModClient.SerialPort = serialPort.PortName;
                ModClient.Connect();
                timerPoll.Start();
                lblStatus.Text = "Connected";
                btnConnect.Text = "Disconect";
                // Cargar los valores de slaveIds desde el archivo SlaveIdsFileName 
                if (File.Exists(SlaveIdsFileName))
                {
                    Console.WriteLine("Se cargaron los slaveIds desde un archivo");
                    string[] lines = File.ReadAllLines(SlaveIdsFileName);
                    slaveIds = lines.Select(int.Parse).ToList();
                    CreateWriteRegistersComponents(353, 20, slaveIds);
                }
                // Si no existe el archivo SlaveIdsFileName, pasa a identificar cada slave conectado
                else
                {
                    ModClient.ConnectionTimeout = 250; //pongo un tiempo de timeout mas corto para identificar mas rapido
                    slaveIds.Clear(); //limpia la lista de slaves

                    // A continuacion envio un mismo mensaje a diferentes slaves id (cambiar los parametros del for para saber cual es el slaveid maximo a iterar)
                    for (byte slaveId = 1; slaveId <= 5; slaveId++) 
                    {
                        int retryCount = 2;
                        bool connected = false;
                        for (int retry = 0; retry < retryCount; retry++)//reintenta conectarse retryCount veces a cada slaveId
                        {
                            try //se usa try porque si se produce un timeout el programa se cuelga porque tira una excepcion, de esta manera se evita eso y el codigo sigue
                            {
                                ModClient.UnitIdentifier = slaveId;
                                bool[] response = ModClient.ReadCoilsRTS(0, 1,serialPort); //se usa un read coil (function 01) para ver si el slave responde, si no responde el codigo continua al catch
                                // Si no se produce una excepción, significa que el esclavo con el ID actual está conectado
                                connected = true;
                                break; // Sale del bucle de intentos si la conexión fue exitosa
                            }
                            catch (Exception)
                            {
                                connected = false;
                                // Si se produce una excepción, el esclavo con el ID actual no está conectado
                                // Puedes agregar un manejo de excepciones más específico si lo deseas
                            }
                        }
                        //si el slave responde correctamente
                        if (connected)
                        {
                            slaveIds.Add(slaveId); //se agrega el slaveID a la lista
                        }
                    }
                    Console.WriteLine("Cantidad de slaves conectados: " + slaveIds.Count);
                    CreateWriteRegistersComponents(353, 20, slaveIds); //funcion que crea los componentes visibles de cada slave segun la lista de slaveids (los dos primeros parametros son las posiciones absolutas en el ejex y ejey donde comienza a plotear los componentes)
                    ModClient.ConnectionTimeout = 1000;//vuelvo a un timeout de 1 segundo para la comunicacion Modbus
                    File.WriteAllLines(SlaveIdsFileName, slaveIds.Select(id => id.ToString())); //escribe la lista en el archivo SlaveIdsFileName
                    Console.WriteLine("Se creo un archivo de SlavesIds");
                }
            }
            //si la comunicacion esta conectada: se desconecta la comunicacion y se setea valores visibles
            else
            {
                ModClient.Disconnect();
                timerPoll.Stop();
                lblStatus.Text = "Disconnected";
                btnConnect.Text = "Connect";
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            // ...
        }

        private void lblCoil1_Click(object sender, EventArgs e)
        {
            // ...
        }

        //funcion que se repite cada x cantidad de tiempo (seteado en 1 segundo)
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (ModClient.Connected == true)
            {
                //repite el siguiente codigo para cada valor de slaveId almacenado en la lista slaveIds
                foreach (byte slaveId in slaveIds)
                {
                    //crea una lista que contenga objetos que poseen como atributos el slaveId y la cantidad de fallas consecutivas al intentar acceder a ese slaveId
                    // maximo de 6 reintentos consecutivos, de llegar a 6 deja de intentar conectarse a ese slaveId, hasta que no se le indique lo contrario
                    SlaveObject slaveObject = slaveList.FirstOrDefault(slave => slave.SlaveId == slaveId);
                    if (slaveObject == null)
                    {
                        slaveObject = new SlaveObject { SlaveId = slaveId, FailCount = 0 };
                        slaveList.Add(slaveObject);
                    }
                    if (slaveObject.FailCount < 6)
                    {
                        try
                        {   
                            //logica de la comunicacion iterativa a los diferentes slaveIds:
                            ModClient.UnitIdentifier = slaveId; //identidica el slave al cual se comunicara
                            bool[] vals = ModClient.ReadCoilsRTS(0, 3, serialPort);//lee 3 bobinas, a partir de la posicion 0. Dentro utiliza el RTS (ctrl+click en el metodo para ir a su deficion, por si se quiere cambiar el tiempo para el RTS)
                            
                            //lo siguiente transforma los true y false, en 1 o 0
                            int[] coilsAlert = new int[vals.Length];
                            for (int i = 0; i < vals.Length; i++)
                            {
                                coilsAlert[i] = vals[i] ? 1 : 0;
                            }
                            tCoil1_1.Text = coilsAlert[0].ToString();
                            tCoil1_2.Text = coilsAlert[1].ToString();
                            tCoil1_3.Text = coilsAlert[2].ToString();
                            string textBoxName = "txtGrm" + slaveId;//textBoxName contendra el identificador del componente donde uno escribe el dato para escribir un registro
                            TextBox textBox = Controls.Find(textBoxName, true).FirstOrDefault() as TextBox; //busca el componente con el nombre de textBoxName
                            if (textBox != null && !string.IsNullOrEmpty(textBox.Text)) //si el componente existe
                            {
                                int[] registerValuesArray = new int[] { int.Parse(textBox.Text) };//convierto el valor ingresado en el componente que es un input para el usuario, en un array de enteros por eso parseo a int ya que lo que se coloca en el input se hace como string
                                ModClient.WriteMultipleRegistersRTS(0, registerValuesArray,serialPort); //escribe multiples registros del slave con id slaveId, configurado para que sea solo 1 registro
                            }
                            slaveObject.FailCount = 0;//reinicia la cantidad de fallos para este slaveid
                        }
                        catch
                        {
                            Console.WriteLine("No se encontro el Slave:" + slaveId + " \n Error: " + slaveObject.FailCount);
                            slaveObject.FailCount++;//si no responde el slaveid se aumenta en 1 la cantidad de fallas reiterativas de este slaveId
                        }
                    }
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            // ...
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // ...
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            // ...
        }

        // Evento Form1_Load fuera de la clase Form1

        private void CreateWriteRegistersComponents(int posicionX, int posicionY, List<int> slaveIds)
        {

            //variables de formato:
            int indexlabel1Y = 70;
            int indexlabel2Y = indexlabel1Y + 50;
            int indextextBoxX = 170;

            int labelTitleX = posicionX;
            int labelTitleY = posicionY;
            int label1PosX = posicionX;
            int label1PosY = posicionY + indexlabel1Y;
            int label2PosX = posicionX;
            int label2PosY = posicionY + indexlabel2Y;
            int textBoxPosX = posicionX + indextextBoxX;
            int textBoxPosY = posicionY + indexlabel2Y - 2;


            Label labelRegisterWriteTitle = new Label();
            labelRegisterWriteTitle.Text = "Escritura de Registros:";
            labelRegisterWriteTitle.AutoSize = true;
            labelRegisterWriteTitle.Font = new Font(labelRegisterWriteTitle.Font.FontFamily, 25, labelRegisterWriteTitle.Font.Style);
            labelRegisterWriteTitle.Location = new System.Drawing.Point(labelTitleX, labelTitleY);
            this.Controls.Add(labelRegisterWriteTitle);

            for (int i = 0; i < slaveIds.Count; i++)
            {
                Label labelSlave = new Label();
                labelSlave.Text = "Slave " + slaveIds[i] + ":";
                labelSlave.Font = new Font(labelSlave.Font.FontFamily, 18, labelSlave.Font.Style);
                labelSlave.AutoSize = true;
                labelSlave.Location = new System.Drawing.Point(label1PosX, label1PosY);
                this.Controls.Add(labelSlave);

                try
                {
                    ModClient.UnitIdentifier = Convert.ToByte(slaveIds[i]);
                    int[] response = ModClient.ReadHoldingRegisters(0, 1);
                    // Si no se produce una excepción, significa que el esclavo con el ID actual está conectado
                    Label labelGramos = new Label();
                    labelGramos.Text = "Cantidad de gramos:";
                    labelGramos.Font = new Font(labelGramos.Font.FontFamily, 12, labelGramos.Font.Style);
                    labelGramos.AutoSize = true;
                    labelGramos.Location = new System.Drawing.Point(label2PosX, label2PosY);

                    TextBox textBox = new TextBox();
                    textBox.Name = "txtGrm" + slaveIds[i];
                    textBox.Location = new System.Drawing.Point(textBoxPosX, textBoxPosY);
                    textBox.Font = new Font(textBox.Font.FontFamily, 12, textBox.Font.Style);
                    // Agregar los componentes al formulario

                    this.Controls.Add(labelGramos);
                    this.Controls.Add(textBox);
                }
                catch (Exception)
                {
                    Label labelGramos = new Label();
                    labelGramos.Text = "DESCONECTADO";
                    labelGramos.Font = new Font(labelGramos.Font.FontFamily, 12, labelGramos.Font.Style);
                    labelGramos.AutoSize = true;
                    labelGramos.Location = new System.Drawing.Point(label2PosX, label2PosY);
                    this.Controls.Add(labelGramos);
                    // Si se produce una excepción, el esclavo con el ID actual no está conectado
                    // Puedes agregar un manejo de excepciones más específico si lo deseas
                }



                // Incrementar las posiciones para el siguiente conjunto de componentes
                label1PosY += 100;
                label2PosY += 100;
                textBoxPosY += 100;
            }
            Button btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Font = new Font(btnRefresh.Font.FontFamily, 18, btnRefresh.Font.Style);
            btnRefresh.AutoSize = true;
            btnRefresh.Location = new System.Drawing.Point(label1PosX, label1PosY);
            this.Controls.Add(btnRefresh);
            Button btnRecognize = new Button();
            btnRecognize.Text = "Recognize Slaves";
            btnRecognize.Name = "btnRecognize";
            btnRecognize.Font = new Font(btnRecognize.Font.FontFamily, 18, btnRecognize.Font.Style);
            btnRecognize.AutoSize = true;
            btnRecognize.Location = new System.Drawing.Point(label1PosX + 120, label1PosY);
            this.Controls.Add(btnRecognize);
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }
    }

}