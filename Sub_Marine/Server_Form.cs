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
		}

		public GameServer server = null;
		private Thread init = null;
		public Server_Form()
		{
			InitializeComponent();
			log("Application launched");
		}


		private void lunchServer_Click(object sender, EventArgs e)
		{
			try
			{
				String str = port.Text;
				int i_port = 0; 
				int.TryParse(port.Text,out i_port);
				if ( 0 >= i_port || i_port >= 65535 )
				{
					throw new ArgumentException();
				}
				log(string.Format("Server launched on port {0}", port.Text));
				lunchServer.Enabled = false;
				port.Enabled = false;
				server = new GameServer(i_port,new Globals.LoggerDelegate(log));
				server.r_Command = data_handler;
				init = new Thread(new ThreadStart(server.start));// server.start();
				init.Start();
				log("Waiting for 2 players to connect");
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Port number is invalid or empty. Please choose a different port",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
			}
		}
		public void data_handler(String str)
		{
			DoWork(str);
		}

		
		private void Server_FormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (server != null)
			{
				server.stop();
			}
			
			try 
			{
				init.Abort();
				while (init.IsAlive)
				{
					Thread.Sleep(250);
				}
			}
			catch(NullReferenceException) 
			{
				
			}
		}
		
		private void log(string msg)
		{
			if (this.InvokeRequired)
			{
				// Pass the same function to BeginInvoke,
				// but the call would come on the correct
				// thread and InvokeRequired will be false.
				this.BeginInvoke(new Globals.LoggerDelegate(log), new object[] {msg});
				return;
			}
			string currentDate = DateTime.Now.ToShortDateString();
			string currentTime = DateTime.Now.ToShortTimeString();
			m_loggerOutput.Items.Add(string.Format("{0} {1}: {2}",currentDate, currentTime, msg));
		}
	}
}
