namespace MasterRTU
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtBaud = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.Slave1 = new System.Windows.Forms.Label();
            this.tCoil1_1 = new System.Windows.Forms.Label();
            this.lblCoil1_1 = new System.Windows.Forms.Label();
            this.lblCoil1_2 = new System.Windows.Forms.Label();
            this.tCoil1_2 = new System.Windows.Forms.Label();
            this.lblCoil1_3 = new System.Windows.Forms.Label();
            this.tCoil1_3 = new System.Windows.Forms.Label();
            this.lblCoil2_3 = new System.Windows.Forms.Label();
            this.tCoil2_3 = new System.Windows.Forms.Label();
            this.lblCoil2_2 = new System.Windows.Forms.Label();
            this.tCoil2_2 = new System.Windows.Forms.Label();
            this.lblCoil2_1 = new System.Windows.Forms.Label();
            this.tCoil2_1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.timerPoll = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PORT";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(100, 28);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "COM2";
            // 
            // txtBaud
            // 
            this.txtBaud.Location = new System.Drawing.Point(100, 58);
            this.txtBaud.Name = "txtBaud";
            this.txtBaud.Size = new System.Drawing.Size(100, 20);
            this.txtBaud.TabIndex = 5;
            this.txtBaud.Text = "9600";
            this.txtBaud.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "BaudRate";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(37, 100);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(163, 34);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(80, 334);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Not Connected";
            // 
            // Slave1
            // 
            this.Slave1.AutoSize = true;
            this.Slave1.Location = new System.Drawing.Point(34, 164);
            this.Slave1.Name = "Slave1";
            this.Slave1.Size = new System.Drawing.Size(46, 13);
            this.Slave1.TabIndex = 0;
            this.Slave1.Text = "Slave 1:";
            this.Slave1.Click += new System.EventHandler(this.label4_Click);
            // 
            // tCoil1_1
            // 
            this.tCoil1_1.AutoSize = true;
            this.tCoil1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCoil1_1.Location = new System.Drawing.Point(37, 188);
            this.tCoil1_1.Name = "tCoil1_1";
            this.tCoil1_1.Size = new System.Drawing.Size(42, 46);
            this.tCoil1_1.TabIndex = 8;
            this.tCoil1_1.Text = "0";
            // 
            // lblCoil1_1
            // 
            this.lblCoil1_1.AutoSize = true;
            this.lblCoil1_1.Location = new System.Drawing.Point(42, 234);
            this.lblCoil1_1.Name = "lblCoil1_1";
            this.lblCoil1_1.Size = new System.Drawing.Size(30, 13);
            this.lblCoil1_1.TabIndex = 9;
            this.lblCoil1_1.Text = "Coil1";
            this.lblCoil1_1.Click += new System.EventHandler(this.lblCoil1_Click);
            // 
            // lblCoil1_2
            // 
            this.lblCoil1_2.AutoSize = true;
            this.lblCoil1_2.Location = new System.Drawing.Point(80, 234);
            this.lblCoil1_2.Name = "lblCoil1_2";
            this.lblCoil1_2.Size = new System.Drawing.Size(30, 13);
            this.lblCoil1_2.TabIndex = 11;
            this.lblCoil1_2.Text = "Coil2";
            // 
            // tCoil1_2
            // 
            this.tCoil1_2.AutoSize = true;
            this.tCoil1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCoil1_2.Location = new System.Drawing.Point(75, 188);
            this.tCoil1_2.Name = "tCoil1_2";
            this.tCoil1_2.Size = new System.Drawing.Size(42, 46);
            this.tCoil1_2.TabIndex = 10;
            this.tCoil1_2.Text = "0";
            // 
            // lblCoil1_3
            // 
            this.lblCoil1_3.AutoSize = true;
            this.lblCoil1_3.Location = new System.Drawing.Point(121, 234);
            this.lblCoil1_3.Name = "lblCoil1_3";
            this.lblCoil1_3.Size = new System.Drawing.Size(30, 13);
            this.lblCoil1_3.TabIndex = 13;
            this.lblCoil1_3.Text = "Coil3";
            // 
            // tCoil1_3
            // 
            this.tCoil1_3.AutoSize = true;
            this.tCoil1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCoil1_3.Location = new System.Drawing.Point(116, 188);
            this.tCoil1_3.Name = "tCoil1_3";
            this.tCoil1_3.Size = new System.Drawing.Size(42, 46);
            this.tCoil1_3.TabIndex = 12;
            this.tCoil1_3.Text = "0";
            // 
            // lblCoil2_3
            // 
            this.lblCoil2_3.AutoSize = true;
            this.lblCoil2_3.Location = new System.Drawing.Point(258, 234);
            this.lblCoil2_3.Name = "lblCoil2_3";
            this.lblCoil2_3.Size = new System.Drawing.Size(30, 13);
            this.lblCoil2_3.TabIndex = 20;
            this.lblCoil2_3.Text = "Coil3";
            // 
            // tCoil2_3
            // 
            this.tCoil2_3.AutoSize = true;
            this.tCoil2_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCoil2_3.Location = new System.Drawing.Point(253, 188);
            this.tCoil2_3.Name = "tCoil2_3";
            this.tCoil2_3.Size = new System.Drawing.Size(42, 46);
            this.tCoil2_3.TabIndex = 19;
            this.tCoil2_3.Text = "0";
            // 
            // lblCoil2_2
            // 
            this.lblCoil2_2.AutoSize = true;
            this.lblCoil2_2.Location = new System.Drawing.Point(217, 234);
            this.lblCoil2_2.Name = "lblCoil2_2";
            this.lblCoil2_2.Size = new System.Drawing.Size(30, 13);
            this.lblCoil2_2.TabIndex = 18;
            this.lblCoil2_2.Text = "Coil2";
            // 
            // tCoil2_2
            // 
            this.tCoil2_2.AutoSize = true;
            this.tCoil2_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCoil2_2.Location = new System.Drawing.Point(212, 188);
            this.tCoil2_2.Name = "tCoil2_2";
            this.tCoil2_2.Size = new System.Drawing.Size(42, 46);
            this.tCoil2_2.TabIndex = 17;
            this.tCoil2_2.Text = "0";
            // 
            // lblCoil2_1
            // 
            this.lblCoil2_1.AutoSize = true;
            this.lblCoil2_1.Location = new System.Drawing.Point(179, 234);
            this.lblCoil2_1.Name = "lblCoil2_1";
            this.lblCoil2_1.Size = new System.Drawing.Size(30, 13);
            this.lblCoil2_1.TabIndex = 16;
            this.lblCoil2_1.Text = "Coil1";
            // 
            // tCoil2_1
            // 
            this.tCoil2_1.AutoSize = true;
            this.tCoil2_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCoil2_1.Location = new System.Drawing.Point(174, 188);
            this.tCoil2_1.Name = "tCoil2_1";
            this.tCoil2_1.Size = new System.Drawing.Size(42, 46);
            this.tCoil2_1.TabIndex = 15;
            this.tCoil2_1.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Slave 1:";
            // 
            // timerPoll
            // 
            this.timerPoll.Interval = 1000;
            this.timerPoll.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCoil2_3);
            this.Controls.Add(this.tCoil2_3);
            this.Controls.Add(this.lblCoil2_2);
            this.Controls.Add(this.tCoil2_2);
            this.Controls.Add(this.lblCoil2_1);
            this.Controls.Add(this.tCoil2_1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCoil1_3);
            this.Controls.Add(this.tCoil1_3);
            this.Controls.Add(this.lblCoil1_2);
            this.Controls.Add(this.tCoil1_2);
            this.Controls.Add(this.lblCoil1_1);
            this.Controls.Add(this.tCoil1_1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtBaud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.Slave1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Modbus RTU Master";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtBaud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label Slave1;
        private System.Windows.Forms.Label tCoil1_1;
        private System.Windows.Forms.Label lblCoil1_1;
        private System.Windows.Forms.Label lblCoil1_2;
        private System.Windows.Forms.Label tCoil1_2;
        private System.Windows.Forms.Label lblCoil1_3;
        private System.Windows.Forms.Label tCoil1_3;
        private System.Windows.Forms.Label lblCoil2_3;
        private System.Windows.Forms.Label tCoil2_3;
        private System.Windows.Forms.Label lblCoil2_2;
        private System.Windows.Forms.Label tCoil2_2;
        private System.Windows.Forms.Label lblCoil2_1;
        private System.Windows.Forms.Label tCoil2_1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timerPoll;
    }
}

