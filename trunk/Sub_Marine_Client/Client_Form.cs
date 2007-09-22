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
		public enum DataType {HIT, MISS, GUESS};
		private const int NUMBER_OF_CHARS_IN_HEADER = 2;
		
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

		public void sendData(DataType type, string data)
		{
			Type DataTypes = typeof(DataType);
			string header = DataType.GetName(DataTypes, type).Substring(0,NUMBER_OF_CHARS_IN_HEADER);
			game.SendData(header+data);
		}
		
		private void reaciveEvent(string str)
		{
			if (str=="ut")
			{
				turn.Text= "It is your's turn";
				return;
			}
			if(str=="nut")
			{
				turn.Text="It is not you'r turn";
			}
			Type DataTypes = typeof(DataType);
			string[] types = DataType.GetNames(DataTypes);
			if (str.StartsWith(types[0].Substring(0,NUMBER_OF_CHARS_IN_HEADER))==true)
			{
				//Hit event
				try
				{
					int tileNumber = 0;
					int.TryParse(str.Substring(NUMBER_OF_CHARS_IN_HEADER), out tileNumber);
					m_opponentBoard.markTile(tileNumber, Tile.TileState.Hit);
				}
				catch (ArgumentException)
				{
					
				}
			}
			else if (str.StartsWith(types[1].Substring(0,NUMBER_OF_CHARS_IN_HEADER))==true)
			{
				//Miss event
				try
				{
					int tileNumber = 0;
					int.TryParse(str.Substring(NUMBER_OF_CHARS_IN_HEADER), out tileNumber);
					m_opponentBoard.markTile(tileNumber, Tile.TileState.Miss);
				}
				catch (ArgumentException)
				{
					
				}
			}
			else if (str.StartsWith(types[2].Substring(0,NUMBER_OF_CHARS_IN_HEADER))==true)
			{
				//guess request
				try
				{
					int tileNumber = 0;
					int.TryParse(str.Substring(NUMBER_OF_CHARS_IN_HEADER), out tileNumber);
					if(m_myBoard.isEmptyTile(tileNumber) == true)
					{
						m_myBoard.markTile(tileNumber,Tile.TileState.Miss);
						sendData(DataType.MISS, tileNumber.ToString());
					}
					else
					{
						m_myBoard.markTile(tileNumber,Tile.TileState.Hit);
						sendData(DataType.HIT, tileNumber.ToString());
					}
				}
				catch (ArgumentException)
				{
					
				}
			}
			else //If a players asks to play even when it is not his turn
			{
				MessageBox.Show("It is not you'r turn");
			}
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
			m_opponentBoard.setParent(this);
			m_submarineHanger.setAllTilesClickable(false);
			
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
