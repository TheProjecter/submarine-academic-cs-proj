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
    	public delegate void MyDelegateMethod(string str);
    	public void DoWork(string str)
{
   if (this.InvokeRequired)
   {
      MyDelegateMethod theDelegateMethod = new MyDelegateMethod(this.DoWork);
      this.Invoke(theDelegateMethod, new object[] { str });
   }
   else
   {
      this.input.Text = str;
   }
}

        public GameServer server = null;
        private Thread init = null;
        public Server_Form()
        {
            InitializeComponent();
        }


        private void lunchServer_Click(object sender, EventArgs e)
        {
            String str = port.Text;
            int i_port = int.Parse(port.Text);
            server = new GameServer(i_port);
            server.r_Command = data_handler;
            init = new Thread(new ThreadStart(server.start));// server.start();
            init.Start();
        }
        public void data_handler(String str)
        {
            //MessageBox.Show(str);

            DoWork(str);
        }

        
        void Server_FormFormClosing(object sender, FormClosingEventArgs e)
        {
        	if (server != null)
        	{
        		server.stop();
        	}
        	
        	init.Abort();
        	while (init.IsAlive)
        	{
        		Thread.Sleep(250);
        	}
        }
        
        void TextBox1TextChanged(object sender, EventArgs e)
        {
        	
        }
        
        void Button1Click(object sender, EventArgs e)
        {
        	//server.send(m_Output.Text);
        }
    }
}
