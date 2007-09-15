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
        	
        	try
        	{
        		int portNumber = 0;
        		Int32.TryParse(port.Text,out portNumber);
        		if ( 0 >= portNumber || portNumber >= 65535 )
        		{
        			throw new ArgumentException();
        		}
        		game = new GameClient(ip.Text, portNumber);
	            game.r_Command = reaciveEvent;
	            init = new Thread(new ThreadStart(game.start));
	            init.Start();
	            Connect.Enabled = false;
        	}
        	catch (ArgumentException)
        	{
        		MessageBox.Show("Port number is invalid. Please choose a different port",
        		                "Error", 
        		                MessageBoxButtons.OK, 
        		                MessageBoxIcon.Error);
        	}
        }

        private void send_Click(object sender, EventArgs e)
        {
        	game.SendData(outData.Text);
        }
        
        private void reaciveEvent(string str)
        {
        	input.Text = str;
        }

        
        void Client_FormLoad(object sender, EventArgs e)
        {
        	resetGame();
        }
        
        public void resetGame()
        {
        	//submarine hanger reset
        	m_submarineHanger.resetBoard();
        	m_submarineHanger.addSubs();
        	m_submarineHanger.setAllTilesDragable(true);
        	m_submarineHanger.setParent(this);
        	
        	//opponent reset
        	m_opponentBoard.resetBoard();
        	m_opponentBoard.Text = "Opponent Board";
        	
        	//my reset
        	m_opponentBoard.resetBoard();
        	m_myBoard.Text = "My Board";
        	m_myBoard.setAllTilesDragable(true);
        }
        
        public void repositoryIsEmpty()
        {
        	m_submarineHanger.Hide();
        	m_startGame.Show();
        }
        
        void M_startGameClick(object sender, EventArgs e)
        {
        	//TODO check if player 1
        	
        	m_startGame.Text = "Waiting for the worthy opponent to connect...";
        	m_startGame.Enabled = false;
 
        	//TODO wait for other side
        	
        	m_startGame.Text = "Fight for your life!";
        	
        	m_myBoard.setAllTilesDragable(false);
        	m_opponentBoard.setAllTilesClickable(true);
        	
     		//TODO start game
        }
        
        void Client_FormFormClosing(object sender, FormClosingEventArgs e)
        {
        	if (game != null)
        	{
        		game.stop();
        	}
        }
    }
}
