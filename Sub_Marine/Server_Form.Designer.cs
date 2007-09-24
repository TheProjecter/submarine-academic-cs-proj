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
        	this.components = new System.ComponentModel.Container();
        	this.lunchServer = new System.Windows.Forms.Button();
        	this.port = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.m_loggerOutput = new System.Windows.Forms.ListBox();
        	this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
        	this.SuspendLayout();
        	// 
        	// lunchServer
        	// 
        	this.lunchServer.Location = new System.Drawing.Point(170, 7);
        	this.lunchServer.Name = "lunchServer";
        	this.lunchServer.Size = new System.Drawing.Size(50, 41);
        	this.lunchServer.TabIndex = 1;
        	this.lunchServer.Text = "Lunch Server";
        	this.m_tooltip.SetToolTip(this.lunchServer, "Launch the server");
        	this.lunchServer.UseVisualStyleBackColor = true;
        	this.lunchServer.Click += new System.EventHandler(this.lunchServer_Click);
        	// 
        	// port
        	// 
        	this.port.Location = new System.Drawing.Point(13, 28);
        	this.port.Name = "port";
        	this.port.Size = new System.Drawing.Size(138, 20);
        	this.port.TabIndex = 4;
        	this.m_tooltip.SetToolTip(this.port, "Port number");
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
        	// m_loggerOutput
        	// 
        	this.m_loggerOutput.FormattingEnabled = true;
        	this.m_loggerOutput.HorizontalScrollbar = true;
        	this.m_loggerOutput.Location = new System.Drawing.Point(12, 72);
        	this.m_loggerOutput.Name = "m_loggerOutput";
        	this.m_loggerOutput.Size = new System.Drawing.Size(348, 186);
        	this.m_loggerOutput.TabIndex = 7;
        	this.m_tooltip.SetToolTip(this.m_loggerOutput, "Logger output");
        	// 
        	// Server_Form
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(372, 276);
        	this.Controls.Add(this.m_loggerOutput);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.port);
        	this.Controls.Add(this.lunchServer);
        	this.MaximizeBox = false;
        	this.Name = "Server_Form";
        	this.Text = "Sub Marine Server";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormFormClosing);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.ListBox m_loggerOutput;

        #endregion

        private System.Windows.Forms.Button lunchServer;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label3;
    }
}

