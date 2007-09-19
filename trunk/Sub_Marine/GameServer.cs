using System;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Net;


namespace Sub_Marine_Server
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class GameServer
	{
		const int NPLAYER = 2; //Number of players
		//public AsyncCallback pfnWorkerCallBack; //Async Callback
		private TcpListener listener; // listen for client connection
		private string m_IP;
		private int m_port;
		private Thread[] reacive_t;
		private Thread connection_t; //Reavice and send data thread
		public delegate void Command(String str);
		public Command r_Command; //Revice functio
		private bool connectionIsUp = true;
		private bool serverIsUp;
		private int aPlayer = 0; //Active player between 0 and 1
		private Player[] m_Player;
		public GameServer(int port)
		{
			m_IP = "127.0.0.1";
			m_port = port;
			m_Player = new Player[NPLAYER];
			m_Player[0] = new Player();
			m_Player[1] = new Player();
			reacive_t = new Thread[NPLAYER];
			connection_t = new Thread((limitConnection));
			connection_t.Start();
			//reacive_t[0] = new Thread(
			
			try
			{
				listener = new TcpListener(IPAddress.Parse(m_IP), m_port); //listner
			}
			catch (ArgumentNullException ar)
			{
				//	MessageBox.Show("ar " + ar.Message);
			}

			catch (ArgumentOutOfRangeException ar1)
			{
				//	MessageBox.Show("ar1 " + ar1.Message);
			}
		}
		private void onDataRecieved(object data)
		{
			int pnum = int.Parse(data.ToString());
			String str;
			connectionIsUp = true;
			while(connectionIsUp)
			{
				try
				{
					str = m_Player[pnum].input.ReadString();

				}
				catch (ObjectDisposedException se)
				{
					//	MessageBox.Show("odrse " +se.Message);
					//listener.Stop();
					connectionIsUp = false;
					aPlayer = -1; //Reset game
					return;
				}
				catch (IOException se1)
				{
					connectionIsUp = false;
					//MessageBox.Show("odrse1 "+se1.Message);
					if (m_Player[0].connection!=null && !m_Player[0].connection.Connected)
					{
						m_Player[0].clearUser();
						if (m_Player[1]!=null)
						{
							m_Player[0] = new Player();
							reacive_t[0] = null;
							recover(0);
						}
						else
						{
							startPlayers();
						}
					}
					if (m_Player[1].connection!=null  && !m_Player[1].connection.Connected)
					{
						m_Player[1].clearUser();
						if (m_Player[0]!=null)
						{
							m_Player[1] = new Player();
							reacive_t[1] = null;
							recover(1);
						}
						else
						{
							startPlayers();
						}
						
					}
					//listener.Stop();
					return;
				}
				if (str != null & pnum==aPlayer)
				{
					handleData(str);
					if (pnum == 0){
						send(str,1);
						changePlayer();
					}
					else
					{
						send(str,0);
						changePlayer();
					}
				}
				else
				{
					send("Not Your Turn",pnum);
				}
				
				
			}

		}
		private void handleData(String str)
		{
			r_Command(str);
		}

		private void startListen()
		{
			try
			{
				listener.Start();
			}

			catch (ArgumentOutOfRangeException se)
			{
				//MessageBox.Show("se " + se.Message);
			}
			catch (SocketException se1)
			{
				//MessageBox.Show("se1 " + se1.Message);
			}
			catch (InvalidOperationException se2)
			{
				//MessageBox.Show("se2 " + se2.Message);
			}
		}
		private void init(int pnum)
		{

			try
			{
				Socket connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				m_Player[pnum].connection = listener.AcceptSocket();
			}
			catch (ObjectDisposedException di)
			{
				//MessageBox.Show(di.Message);
			}
			catch (InvalidOperationException op)
			{
				//MessageBox.Show("op " + op.Message);
			}
			catch (SocketException se)
			{
				//MessageBox.Show("se " + se.Message);
			}
		}
		public void stop()
		{   try{
				listener.Stop();
			}
			catch (ArgumentNullException)
			{
				
			}
			if (reacive_t[0] != null)
			{
				reacive_t[0].Abort();
				reacive_t[0] = null;
			}
			if (reacive_t[1] != null)
			{
				reacive_t[1].Abort();
				reacive_t[1] = null;
			}
			aPlayer = -1; //Reset game
			connectionIsUp=false;
			serverIsUp = false;
		}
		public void start()
		{
			try
			{
				//	while (serverIsUp)
				//	{
				//Need to add socket expection if a client died not at the end
				startListen();
				startPlayers();

			}
			catch (ThreadAbortException)
			{
				//stop();
			}
		}
		private bool send(string str ,int pnum)
		{
			if (m_Player[pnum]!=null)
			{
				m_Player[pnum].output.Write(str);
				return true;
			}
			else
				return false;
		}
		private void changePlayer()
		{
			if (aPlayer==0)
			{
				aPlayer=1;
			}
			else
				if (aPlayer==1)
			{
				aPlayer=0;
			}
		}

		private void startPlayers()
		{
			for (aPlayer=0;aPlayer<NPLAYER;aPlayer++)
			{
				init(aPlayer);
				m_Player[aPlayer].setSocketStream();
				reacive_t[aPlayer] = new Thread((onDataRecieved));
				reacive_t[aPlayer].IsBackground = true;
			}
			connectionIsUp = true;
			aPlayer=0;
			reacive_t[0].Start(0);
			reacive_t[1].Start(1);
		}
		private void stopPlayer(int pnum)
		{
			m_Player[pnum].clearUser();
			reacive_t[pnum]=null;
		}
		private void recover(int pnum) //It creates new thread for the broken connection with init and waiting for data
		{							
			init(pnum);
			m_Player[pnum].setSocketStream();
			reacive_t[pnum] = new Thread((onDataRecieved));
			reacive_t[pnum].IsBackground = true;
			reacive_t[pnum].Start(pnum);
		}
		private void limitConnection()
		{
			Socket connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			while(1) //it should be written with throw expection
			if (m_Player[0].isConnected() && m_Player[1].isConnected())
			{
				connection = listener.AcceptSocket();
				connection.Close();
				
			}
		}
	}
}


