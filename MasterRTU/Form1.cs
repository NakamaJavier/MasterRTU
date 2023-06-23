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

namespace MasterRTU
{
    public partial class Form1 : Form
    {
        ModbusClient ModClient = new ModbusClient();
        List<int> slaveIds = new List<int>();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // ...
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                ModClient.SerialPort = txtPort.Text;
                ModClient.Baudrate = int.Parse(txtBaud.Text);
                ModClient.Connect();
                timerPoll.Start();
                lblStatus.Text = "Connected";
                btnConnect.Text = "Disconect";
                ModClient.ConnectionTimeout = 250;
                slaveIds.Clear();
                for (byte slaveId = 1; slaveId <= 15; slaveId++) // Itera sobre todos los posibles IDs de esclavos (1-255)
                {
                    try
                    {
                        ModClient.UnitIdentifier = slaveId;
                        int[] response = ModClient.ReadHoldingRegisters(0, 1);
                        // Si no se produce una excepción, significa que el esclavo con el ID actual está conectado
                        slaveIds.Add(slaveId);
                    }
                    catch (Exception)
                    {
                        // Si se produce una excepción, el esclavo con el ID actual no está conectado
                        // Puedes agregar un manejo de excepciones más específico si lo deseas
                    }
                }
                Console.WriteLine("Cantidad de slaves conectados: " + slaveIds.Count);
                CreateWriteRegistersComponents(353, 50, slaveIds);
                ModClient.ConnectionTimeout = 1000;
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ModClient.Connected == true)
            {
                foreach (byte slaveId in slaveIds)
                {
                    ModClient.UnitIdentifier = slaveId;
                    bool[] vals = ModClient.ReadCoils(0, 3);
                    int[] coilsAlert = new int[vals.Length];
                    for (int i = 0; i < vals.Length; i++)
                    {
                        coilsAlert[i] = vals[i] ? 1 : 0;
                    }
                    tCoil1_1.Text = coilsAlert[0].ToString();
                    tCoil1_2.Text = coilsAlert[1].ToString();
                    tCoil1_3.Text = coilsAlert[2].ToString();
                    string textBoxName = "txtGrm" + slaveId;
                    TextBox textBox = Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;

                    if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
                    {
                        ModClient.WriteSingleRegister(0, int.Parse(textBox.Text));
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
        private void Form1_Load(object sender, EventArgs e)
        {
            // Lógica para agregar un botón dinámicamente
            if (true)
            {
                Console.WriteLine("se genera el boton dinamico");
                Button button = new Button();
                button.Text = "Botón Dinámico";
                button.Location = new System.Drawing.Point(520, 381);
                button.Click += Button_Click; // Suscribir un controlador de eventos para el botón

                this.Controls.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Lógica del controlador de eventos del botón dinámico
            MessageBox.Show("¡Hiciste clic en el botón dinámico!");
        }
        private void CreateWriteRegistersComponents(int posicionX, int posicionY, List<int> slaveIds)
        {
            //variables de formato:
            int indexlabel1Y = 70;
            int indexlabel2Y = indexlabel1Y+50;
            int indextextBoxX = 170;

            int labelTitleX = posicionX;
            int labelTitleY = posicionY;
            int label1PosX = posicionX;
            int label1PosY = posicionY + indexlabel1Y;
            int label2PosX = posicionX;
            int label2PosY = posicionY + indexlabel2Y;
            int textBoxPosX = posicionX + indextextBoxX;
            int textBoxPosY = posicionY + indexlabel2Y-2;


            Label labelRegisterWriteTitle = new Label();
            labelRegisterWriteTitle.Text = "Escritura de Registros:";
            labelRegisterWriteTitle.AutoSize = true;
            labelRegisterWriteTitle.Font = new Font(labelRegisterWriteTitle.Font.FontFamily, 25, labelRegisterWriteTitle.Font.Style);
            labelRegisterWriteTitle.Location = new System.Drawing.Point(labelTitleX, labelTitleY);
            this.Controls.Add(labelRegisterWriteTitle);

            for (int i = 0; i < slaveIds.Count; i++)
            {
                Label labelSlave = new Label();
                labelSlave.Text = "Slave " + slaveIds[i]+":";
                labelSlave.Font = new Font(labelSlave.Font.FontFamily, 18, labelSlave.Font.Style);
                labelSlave.AutoSize = true;
                labelSlave.Location = new System.Drawing.Point(label1PosX, label1PosY);

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
                this.Controls.Add(labelSlave);
                this.Controls.Add(labelGramos);
                this.Controls.Add(textBox);

                // Incrementar las posiciones para el siguiente conjunto de componentes
                label1PosY += 100;
                label2PosY += 100;
                textBoxPosY += 100;
            }
        }
    }

}
