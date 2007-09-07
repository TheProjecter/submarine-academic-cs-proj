/*
 * Created by SharpDevelop.
 * User: Amitai
 * Date: 07/09/2007
 * Time: 14:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Net;


namespace Sub_Marine_Server
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Player
	{
		public Socket connection; // Socket for accepting a connection
		public NetworkStream socketStream; // network data stream
	    public BinaryWriter output; //Out buffer
        public BinaryReader input;  //in buffer
        public Player()
        {
        }
        public void setSocketConnection(ref Socket con)
        {
        	connection = con;
        }
        public void setSocketStream()
        {
        socketStream = new NetworkStream(connection);
        output = new BinaryWriter(socketStream);
		input = new BinaryReader(socketStream);
        }
	}
}