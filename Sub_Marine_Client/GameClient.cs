using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Sub_Marine_Client
{
	class GameClient
	{
		const int TEN=10;
		public enum Result{BEGIN,BOL,PGIAA,MISS,WIN,LOOSE,END};
		private string m_IP;
		private int m_port;
		private Thread reacive_t; //Reavice data thread
		private BinaryWriter output; //Out buffer
		private BinaryReader input;  //in buffer
		private TcpClient connection; //Connection
		private NetworkStream stream; // network data stream
		private int[,] gameBoard;
		public delegate void Command(String str);
		public Command r_Command; //Revice functio
		private bool connectionIsUp = true;
		public GameClient(String ip, int port)
		{
			gameBoard = new int[TEN,TEN];
			m_IP = ip;
			m_port = port;
			try
			{
				connection = new TcpClient(ip, port);
				stream = connection.GetStream();
				output = new BinaryWriter(stream);
				input = new BinaryReader(stream);
			}
			catch (SocketException se)
			{
				MessageBox.Show(se.Message);
			}
			catch (ArgumentException ar)
			{
				MessageBox.Show(ar.Message);

			}
		}
		public void SendData(String str)
		{
			output.Write(str);
		}
		
		public void onDataRecieved()
		{
			String str = null;
			while (connectionIsUp == true)
			{
				try
				{
					str = input.ReadString();
	
				}
				catch (ObjectDisposedException se)
				{
					MessageBox.Show(se.Message);
					connectionIsUp = false;
					return;
				}
				catch (IOException)
				{
					connectionIsUp = false;
					MessageBox.Show("Communication to the sever is out, please make sure that the server is up and running");
					return;
				}
				if (str != null)
				{
					handleData(str);
				}
			}
		}
		void handleData(String str)
		{
			r_Command(str);
		}
		
		public void start()
		{
			try
			{
				reacive_t = new Thread(new ThreadStart(onDataRecieved));
				reacive_t.IsBackground = true;
				reacive_t.Start();
			}
			catch (ThreadAbortException)
			{
				//stop();
			}
		}
		
		public void stop()
		{
			connectionIsUp = false;
		}
	}

}
