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
        //public AsyncCallback pfnWorkerCallBack; //Async Callback
        internal Socket connection; // Socket for accepting a connection
        private TcpListener listener; // listen for client connection 
        private string m_IP;
        private int m_port;
        private Thread reacive_t, send_t; //Reavice and send data thread
        private BinaryWriter output; //Out buffer
        private BinaryReader input;  //in buffer
        private NetworkStream socketStream; // network data stream
        public delegate void Command(String str);
        public Command m_Command;
        public GameServer(String ip, int port)
        {
            m_IP = ip;
            m_IP = "127.0.0.1";
            m_port = port;
        }
        public void onDataRecieved()
        {
            String str = null;
            try
            {
                MessageBox.Show("I'm stupid");
                str = input.ReadString();

            }
            catch (ObjectDisposedException se)
            {
                MessageBox.Show("odrse " +se.Message);
                reacive_t.Abort();
                return;
            }
            catch (IOException se1)
            {
                MessageBox.Show("odrse1 "+se1.Message);
                reacive_t.Abort();
                listener.Stop();
                return;
            }
            if (str != null)
            {
                handleData(str);
            }
        }
        void handleData(String str)
        {
            m_Command(str);
        }

        public void init()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(m_IP), m_port); //listner
            }
            catch (ArgumentNullException ar)
            {
                MessageBox.Show("ar " + ar.Message);
            }

            catch (ArgumentOutOfRangeException ar1)
            {
                MessageBox.Show("ar1 " + ar1.Message);
            }
            try
            {
                listener.Start();
            }

            catch (ArgumentOutOfRangeException se)
            {
                MessageBox.Show("se " + se.Message);
            }
            catch (SocketException se1)
            {
                MessageBox.Show("se1 " + se1.Message);
            }
            catch (InvalidOperationException se2)
            {
                MessageBox.Show("se2 " + se2.Message);
            }
            try
            {
                connection = listener.AcceptSocket();
            }
            catch (InvalidOperationException op)
            {
                MessageBox.Show("op " + op.Message);
            }
        }
        public void start()
        {
            bool status = true;
            socketStream = new NetworkStream(connection);
            output = new BinaryWriter(socketStream);
            input = new BinaryReader(socketStream);
            init();
            while (status)
            {
                reacive_t = new Thread(new ThreadStart(onDataRecieved));
                reacive_t.IsBackground = true;
                reacive_t.Start();
                while (reacive_t.IsAlive) ;
                //onDataRecieved();
                if (reacive_t.ThreadState == ThreadState.Aborted)
                {
                    listener.Stop();
                    init();
                }
            }
        }

        }


    }

