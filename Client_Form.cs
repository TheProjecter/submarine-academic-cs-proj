using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Sub_Marine_Client
{
    public partial class Client_Form : Form
    {
    	private Thread init = null;
        private GameClient game; 
        public Client_Form()
        {
            InitializeComponent();
        }


        private void Connect_Click(object sender, EventArgs e)
        {
            game = new GameClient(ip.Text, int.Parse(port.Text));
            game.r_Command = reaciveEvent;
            init = new Thread(new ThreadStart(game.start));
            init.Start();
        }

        private void send_Click(object sender, EventArgs e)
        {
                    game.SendData(outData.Text);
        }
        
        private void reaciveEvent(string str)
        {
        	input.Text = str;
        }

    }
}
