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
        private string m_IP;
        private int m_port;
        private Thread reacive_t, send_t; //Reavice and send data thread
        private BinaryWriter output; //Out buffer
        private BinaryReader input;  //in buffer
        private TcpClient connection; //Connection
        private NetworkStream stream; // network data stream    
        public GameClient(String ip, int port)
	    {
        m_IP = ip;
        m_port = port;
        try
        {
            connection = new TcpClient("localhost", port);
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
        public void start()
        {
            
        }
    }


}
