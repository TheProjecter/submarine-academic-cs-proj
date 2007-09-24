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
		private bool connectionIsUp = true; //Game is up.
		private int aPlayer = 0; //Active player between 0 and 1
		private Player[] m_Player;
		Globals.LoggerDelegate m_logger = null;
		public GameServer(int port, Globals.LoggerDelegate logger)
		{
			m_IP = "0.0.0.0";
			m_port = port;
			m_logger = logger;
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
			catch (ArgumentNullException)
			{
				m_logger("caught ArgumentNullException");
			}
			catch (ArgumentOutOfRangeException)
			{
				m_logger("caught ArgumentOutOfRangeException");
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
					m_logger(string.Format("data recieved from player {0}:{1}",pnum, str));
				}
				catch (ObjectDisposedException)
				{
					connectionIsUp = false;
					aPlayer = -1; //Reset game
					return;
				}
				catch (IOException)
				{
					connectionIsUp = false;
					if (m_Player[0].connection!=null && !m_Player[0].connection.Connected)
					{
						m_logger("player 0 was disconnected");
						m_Player[0].clearUser();
						if (m_Player[1]!=null)
						{
							m_Player[0] = new Player();
							reacive_t[0] = null;
							recover(0);
						}
						else
						{
							m_logger("both players disconnected");
							startPlayers();
						}
					}
					if (m_Player[1].connection!=null  && !m_Player[1].connection.Connected)
					{
						m_logger(string.Format("player 1 was disconnected"));
						m_Player[1].clearUser();
						if (m_Player[0]!=null)
						{
							m_Player[1] = new Player();
							reacive_t[1] = null;
							recover(1);
						}
						else
						{
							m_logger("both players disconnected");
							startPlayers();
						}
						
					}
					return;
				}
				if (m_Player[pnum].subInPlace && str != null && pnum==aPlayer)
				{
					handleData(str);
					if (pnum == 0){
						send(str,1);
					}
					else
					{
						send(str,0);
					}
				}
				else
				{
					if (str.StartsWith("HI") || str.StartsWith("MI"))
					{
						send(str,aPlayer); //I will always send to aplayer. it
						changePlayer(); //After sending data switch player
						
					}
					if (str.StartsWith("SU"))
					{
						m_Player[pnum].subInPlace = true;
					}
					else 
					{
						send("nut",pnum);
						m_logger(string.Format("Player {0} tried to move while it was not it's turn",pnum));
					}
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

			catch (ArgumentOutOfRangeException)
			{
				m_logger("caught ArgumentOutOfRangeException");
			}
			catch (SocketException)
			{
				m_logger("caught SocketException");
			}
			catch (InvalidOperationException)
			{
				m_logger("caught InvalidOperationException");
			}
		}
		private void init(int pnum)
		{
			try
			{
				Socket connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				m_Player[pnum].connection = listener.AcceptSocket();
				m_logger(string.Format("Player {0} is connected",pnum));
			}
			catch (ObjectDisposedException)
			{
				m_logger("caught ObjectDisposedException");
			}
			catch (InvalidOperationException)
			{
				m_logger("caught InvalidOperationException");
			}
			catch (SocketException)
			{
				m_logger("caught SocketException");
			}
		}
		public void stop()
		{   try{
				listener.Stop();
				m_logger("Server stopped");
			}
			catch (ArgumentNullException)
			{
				m_logger("caught ArgumentNullException");
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
				m_logger("Commencing game");

			}
			catch (ThreadAbortException)
			{
				
			}
		}
		private bool send(string str ,int pnum)
		{
			if (m_Player[pnum]!=null)
			{
				m_Player[pnum].output.Write(str);
				m_logger(string.Format("data was sent to player {0} " + str, pnum));
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
				send("ut",1);
				send("nut",0);
			}
			else
				if (aPlayer==1)
			{
				aPlayer=0;
				send("ut",0);
				send("nut",1);
			}
		}
		private bool onlyPlayer()
		{
			if ((m_Player[0].connection!=null && !m_Player[0].connection.Connected) &&m_Player[1].connection!=null && !m_Player[1].connection.Connected)
				return false; //I'm only player
			else
				return true; //I'm only player
			
		}
		private void startPlayers()
		{
			for (aPlayer=0;aPlayer<NPLAYER;aPlayer++)
			{
				init(aPlayer);
				m_Player[aPlayer].setSocketStream();
				if (onlyPlayer())
					send("wj",0);
				reacive_t[aPlayer] = new Thread((onDataRecieved));
				reacive_t[aPlayer].IsBackground = true;
				reacive_t[aPlayer].Start(aPlayer);
			}
			aPlayer=0;
			sendInitStatus();
			m_logger("2 players have been connected successfully");
		}
		private void sendInitStatus()
		{
			send("ut",0);
			send ("nut",1);
		}
		private void stopPlayer(int pnum)
		{
			m_Player[pnum].clearUser();
			reacive_t[pnum]=null;
		}
		private void recover(int pnum) //It creates new thread for the broken connection with init and waiting for data
		{
			if (pnum==0)
				send("wj",1);
			else
				send("wj",2);
			init(pnum);
			m_Player[pnum].setSocketStream();
			m_Player[pnum].subInPlace = false;
			reacive_t[pnum] = new Thread((onDataRecieved));
			reacive_t[pnum].IsBackground = true;
			reacive_t[pnum].Start(pnum);
		}
		private void limitConnection()
		{
			Socket connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			//while(1) //it should be written with throw expection
			if (m_Player[0].isConnected() && m_Player[1].isConnected())
			{
				connection = listener.AcceptSocket();
				connection.Close();
				
			}
		}
	}
}


