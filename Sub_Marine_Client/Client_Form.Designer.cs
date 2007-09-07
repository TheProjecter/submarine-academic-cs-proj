namespace Sub_Marine_Client
{
    partial class Client_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.ip = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.TextBox();
            this.gameGridPanel1 = new Sub_Marine_Client.GameGridPanel();
            this.repositoryGridPanel1 = new Sub_Marine_Client.RepositoryGridPanel();
            this.SuspendLayout();
            // 
            // outData
            // 
            this.outData.Location = new System.Drawing.Point(417, 158);
            this.outData.Name = "outData";
            this.outData.Size = new System.Drawing.Size(84, 20);
            this.outData.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(435, 253);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(66, 31);
            this.send.TabIndex = 3;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(417, 45);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(72, 20);
            this.ip.TabIndex = 4;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(417, 102);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(69, 20);
            this.port.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(435, 290);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(66, 28);
            this.Connect.TabIndex = 8;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(449, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Input";
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(417, 217);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(84, 20);
            this.input.TabIndex = 10;
            // 
            // gameGridPanel1
            // 
            this.gameGridPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.gameGridPanel1.Location = new System.Drawing.Point(9, 2);
            this.gameGridPanel1.Name = "gameGridPanel1";
            this.gameGridPanel1.Size = new System.Drawing.Size(355, 349);
            this.gameGridPanel1.TabIndex = 11;
            // 
            // repositoryGridPanel1
            // 
            this.repositoryGridPanel1.Location = new System.Drawing.Point(46, 357);
            this.repositoryGridPanel1.Name = "repositoryGridPanel1";
            this.repositoryGridPanel1.Size = new System.Drawing.Size(318, 65);
            this.repositoryGridPanel1.TabIndex = 12;
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 492);
            this.Controls.Add(this.repositoryGridPanel1);
            this.Controls.Add(this.gameGridPanel1);
            this.Controls.Add(this.input);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.send);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Client_Form";
            this.Text = "SubMarine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label label4;

        #endregion

        private System.Windows.Forms.TextBox outData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Connect;
        private GameGridPanel gameGridPanel1;
        private RepositoryGridPanel repositoryGridPanel1;
    }
}

