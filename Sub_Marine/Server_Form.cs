using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Sub_Marine_Server
{
    public partial class Server_Form : Form
    {
        public GameServer server;
        private Thread init;
        public Server_Form()
        {
            InitializeComponent();
        }


        private void lunchServer_Click(object sender, EventArgs e)
        {
            String str = port.Text;
            int i_port = int.Parse(port.Text);
            server = new GameServer(ip.Text,i_port);
            server.m_Command = data_handler;
            init = new Thread(new ThreadStart(server.start));// server.start();
            init.Start();
        }
        public void data_handler(String str)
        {
            //MessageBox.Show(str);

            input.Set = str;
        }

    }
}