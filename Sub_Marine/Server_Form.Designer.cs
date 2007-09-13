namespace Sub_Marine_Server
{
    partial class Server_Form
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
        	this.input = new System.Windows.Forms.TextBox();
        	this.lunchServer = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.port = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// input
        	// 
        	this.input.Location = new System.Drawing.Point(90, 28);
        	this.input.Name = "input";
        	this.input.Size = new System.Drawing.Size(86, 20);
        	this.input.TabIndex = 0;
        	// 
        	// lunchServer
        	// 
        	this.lunchServer.Location = new System.Drawing.Point(182, 28);
        	this.lunchServer.Name = "lunchServer";
        	this.lunchServer.Size = new System.Drawing.Size(50, 41);
        	this.lunchServer.TabIndex = 1;
        	this.lunchServer.Text = "Lunch Server";
        	this.lunchServer.UseVisualStyleBackColor = true;
        	this.lunchServer.Click += new System.EventHandler(this.lunchServer_Click);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(135, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(31, 13);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "Input";
        	// 
        	// port
        	// 
        	this.port.Location = new System.Drawing.Point(13, 28);
        	this.port.Name = "port";
        	this.port.Size = new System.Drawing.Size(56, 20);
        	this.port.TabIndex = 4;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(24, 9);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(25, 13);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "port";
        	// 
        	// Server_Form
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(232, 119);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.port);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.lunchServer);
        	this.Controls.Add(this.input);
        	this.Name = "Server_Form";
        	this.Text = "Sub Marine Server";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormFormClosing);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button lunchServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label3;
    }
}

