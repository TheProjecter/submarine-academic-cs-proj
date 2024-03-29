﻿namespace Sub_Marine_Client
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
        	this.components = new System.ComponentModel.Container();
        	this.ip = new System.Windows.Forms.TextBox();
        	this.port = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.Connect = new System.Windows.Forms.Button();
        	this.m_myBoard = new Sub_Marine_Client.GameGridPanel();
        	this.m_submarineHanger = new Sub_Marine_Client.RepositoryGridPanel();
        	this.m_opponentBoard = new Sub_Marine_Client.GameGridPanel();
        	this.m_startGame = new System.Windows.Forms.Button();
        	this.turn = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.m_clientTooltip = new System.Windows.Forms.ToolTip(this.components);
        	this.SuspendLayout();
        	// 
        	// ip
        	// 
        	this.ip.Location = new System.Drawing.Point(494, 452);
        	this.ip.Name = "ip";
        	this.ip.Size = new System.Drawing.Size(72, 20);
        	this.ip.TabIndex = 4;
        	this.m_clientTooltip.SetToolTip(this.ip, "IP Address");
        	// 
        	// port
        	// 
        	this.port.Location = new System.Drawing.Point(572, 452);
        	this.port.Name = "port";
        	this.port.Size = new System.Drawing.Size(69, 20);
        	this.port.TabIndex = 5;
        	this.m_clientTooltip.SetToolTip(this.port, "Port Number");
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(510, 429);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(17, 13);
        	this.label2.TabIndex = 6;
        	this.label2.Text = "IP";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(586, 428);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(26, 13);
        	this.label3.TabIndex = 7;
        	this.label3.Text = "Port";
        	// 
        	// Connect
        	// 
        	this.Connect.Location = new System.Drawing.Point(647, 447);
        	this.Connect.Name = "Connect";
        	this.Connect.Size = new System.Drawing.Size(66, 28);
        	this.Connect.TabIndex = 8;
        	this.Connect.Text = "Connect";
        	this.m_clientTooltip.SetToolTip(this.Connect, "Connect to the server");
        	this.Connect.UseVisualStyleBackColor = true;
        	this.Connect.Click += new System.EventHandler(this.Connect_Click);
        	// 
        	// m_myBoard
        	// 
        	this.m_myBoard.BackColor = System.Drawing.SystemColors.Control;
        	this.m_myBoard.Location = new System.Drawing.Point(10, 35);
        	this.m_myBoard.Name = "m_myBoard";
        	this.m_myBoard.Size = new System.Drawing.Size(349, 378);
        	this.m_myBoard.TabIndex = 11;
        	this.m_clientTooltip.SetToolTip(this.m_myBoard, "My board Grid");
        	// 
        	// m_submarineHanger
        	// 
        	this.m_submarineHanger.AllowDrop = true;
        	this.m_submarineHanger.BackColor = System.Drawing.Color.Transparent;
        	this.m_submarineHanger.Location = new System.Drawing.Point(34, 424);
        	this.m_submarineHanger.Name = "m_submarineHanger";
        	this.m_submarineHanger.Size = new System.Drawing.Size(318, 65);
        	this.m_submarineHanger.TabIndex = 12;
        	this.m_clientTooltip.SetToolTip(this.m_submarineHanger, "Submarine hanger");
        	// 
        	// m_opponentBoard
        	// 
        	this.m_opponentBoard.BackColor = System.Drawing.SystemColors.Control;
        	this.m_opponentBoard.Location = new System.Drawing.Point(367, 35);
        	this.m_opponentBoard.Name = "m_opponentBoard";
        	this.m_opponentBoard.Size = new System.Drawing.Size(346, 378);
        	this.m_opponentBoard.TabIndex = 13;
        	this.m_clientTooltip.SetToolTip(this.m_opponentBoard, "Opponent\'s Board Grid");
        	// 
        	// m_startGame
        	// 
        	this.m_startGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.m_startGame.ForeColor = System.Drawing.Color.DarkRed;
        	this.m_startGame.Location = new System.Drawing.Point(19, 421);
        	this.m_startGame.Name = "m_startGame";
        	this.m_startGame.Size = new System.Drawing.Size(342, 76);
        	this.m_startGame.TabIndex = 14;
        	this.m_startGame.Text = "My submarines are all in place!        Give me a worthy opponent to crush!";
        	this.m_startGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.m_clientTooltip.SetToolTip(this.m_startGame, "Start the game");
        	this.m_startGame.UseVisualStyleBackColor = true;
        	this.m_startGame.Visible = false;
        	this.m_startGame.Click += new System.EventHandler(this.M_startGameClick);
        	// 
        	// turn
        	// 
        	this.turn.BackColor = System.Drawing.SystemColors.ActiveBorder;
        	this.turn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
        	this.turn.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.turn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
        	this.turn.Location = new System.Drawing.Point(231, 19);
        	this.turn.Name = "turn";
        	this.turn.Size = new System.Drawing.Size(243, 53);
        	this.turn.TabIndex = 15;
        	this.m_clientTooltip.SetToolTip(this.turn, "Current game status");
        	// 
        	// label1
        	// 
        	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
        	this.label1.Location = new System.Drawing.Point(81, 41);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(150, 23);
        	this.label1.TabIndex = 16;
        	this.label1.Text = "My Board";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// label4
        	// 
        	this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
        	this.label4.Location = new System.Drawing.Point(478, 40);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(210, 23);
        	this.label4.TabIndex = 17;
        	this.label4.Text = "Oponnent\'s  Board";
        	this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// Client_Form
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(749, 509);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.turn);
        	this.Controls.Add(this.m_startGame);
        	this.Controls.Add(this.m_opponentBoard);
        	this.Controls.Add(this.m_submarineHanger);
        	this.Controls.Add(this.m_myBoard);
        	this.Controls.Add(this.Connect);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.port);
        	this.Controls.Add(this.ip);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        	this.MaximizeBox = false;
        	this.Name = "Client_Form";
        	this.Text = "SubMarine";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormFormClosing);
        	this.Load += new System.EventHandler(this.Client_FormLoad);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolTip m_clientTooltip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.Button m_startGame;
        private Sub_Marine_Client.RepositoryGridPanel m_submarineHanger;
        private Sub_Marine_Client.GameGridPanel m_opponentBoard;
        private Sub_Marine_Client.GameGridPanel m_myBoard;

        #endregion

        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Connect;
    }
}

