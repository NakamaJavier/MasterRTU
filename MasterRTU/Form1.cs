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
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        }

        private void lblCoil1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ModClient.Connected == true)
            {
                ModClient.UnitIdentifier = 1;
                bool[] vals = ModClient.ReadCoils(0, 3);
                int[] coilsAlert = new int[vals.Length];
                for (int i = 0; i < vals.Length; i++)
                {
                    coilsAlert[i] = vals[i] ? 1 : 0;
                }
                tCoil1_1.Text = coilsAlert[0].ToString();
                tCoil1_2.Text = coilsAlert[1].ToString();
                tCoil1_3.Text = coilsAlert[2].ToString();

                ModClient.UnitIdentifier = 2;
                vals = ModClient.ReadCoils(0, 3);
                for (int i = 0; i < vals.Length; i++)
                {
                    coilsAlert[i] = vals[i] ? 1 : 0;
                }
                tCoil2_1.Text = coilsAlert[0].ToString();
                tCoil2_2.Text = coilsAlert[1].ToString();
                tCoil2_3.Text = coilsAlert[2].ToString();
            }
        }
    }
}
