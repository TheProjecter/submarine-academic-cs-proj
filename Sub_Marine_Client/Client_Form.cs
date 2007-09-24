using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace Sub_Marine_Client
{
	public partial class Client_Form : Form
	{
		private Thread init = null;
		private GameClient game;
		public enum DataType {HIT, MISS, GUESS, GOVER};
		private const int NUMBER_OF_CHARS_IN_HEADER = 2;
		
		public Client_Form()
		{
			InitializeComponent();

		}

		private void changeBoardstatus(bool status)
		{
			m_opponentBoard.setAllTilesClickable(status);
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
				IPAddress ipAdder = new IPAddress(0);
				if(IPAddress.TryParse(ip.Text,out ipAdder)==true)
				{
					game = new GameClient(ip.Text, portNumber);
					game.r_Command = reaciveEvent;
					init = new Thread(new ThreadStart(game.start));
					init.Start();
					Connect.Enabled = false;
					changeBoardstatus(true);
				}
				else
				{
					MessageBox.Show("Bad IP Address. Please choose a different ip",
				                "Error",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
				}
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Port number is invalid or empty. Please choose a different port",
				                "Error",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
			}
			m_myBoard.setAllTilesDragable(true);
		}

		public void sendData(DataType type, string data)
		{
			Type DataTypes = typeof(DataType);
			string header = DataType.GetName(DataTypes, type).Substring(0,NUMBER_OF_CHARS_IN_HEADER);
			game.SendData(header+data);
		}
		delegate void EditTextBoxDelegate(string msg);
		
		private void editTurnTextBox(string msg)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new EditTextBoxDelegate(editTurnTextBox), new object[] {msg});
				return;
			}
			turn.Text = msg;
		}
		private void reaciveEvent(string str)
		{
			if (str=="ut")
			{
				editTurnTextBox("It is your's turn");
				changeBoardstatus(true);
				return;
			}
			if(str=="nut")
			{
				editTurnTextBox("It is not you'r turn");
				changeBoardstatus(false);
				return;
			}
			if (str=="wj")
			{
				editTurnTextBox("Waiting for other \n player to join");
				return;
			}
			if (str=="WA")
			{
				editTurnTextBox("Waiting for other player \n to  arrange his subs");
				return;
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
						if (isGameLost()==true)
						{
							sendData(DataType.GOVER,"");
							displayGameOverMessageBox("Game Over, you lose!");
							resetGame();
						}
					}
				}
				catch (ArgumentException)
				{
					
				}
			}
			else if (str.StartsWith(types[3].Substring(0,NUMBER_OF_CHARS_IN_HEADER))==true)
			{
				//Game Over event
				displayGameOverMessageBox("Game Over, you won!");
				resetGame();
			}
		}

		delegate void DisplayMessageBoxDelegate(string msg);
		
		private void displayGameOverMessageBox(string msg)
		{
			if (this.InvokeRequired)
			{
				BeginInvoke(new DisplayMessageBoxDelegate(displayGameOverMessageBox),new object[] {msg});
				return;
			}
			MessageBox.Show(this,msg,
				                "Game Over",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Exclamation);
		}
		
		/// <summary>
		/// return true if the player lost the game, false otherwise
		/// </summary>
		/// <returns></returns>
		private bool isGameLost()
		{
			bool rc = false;
			
			//if the player suffered 20 hits (the sum of tiles of all of the subs)
			//then he/she lost
			if (m_myBoard.countTilesOfState(Tile.TileState.Hit) == 20)
			{
				rc = true;
			}
			return rc;
		}
		
		
		void Client_FormLoad(object sender, EventArgs e)
		{
			resetGame();
			changeBoardstatus(false);
			m_myBoard.setAllTilesDragable(false);
		}
		
		public delegate void ResetGameDelegate();
		
		public void resetGame()
		{
			if(InvokeRequired)
			{
				this.BeginInvoke(new ResetGameDelegate(resetGame));
				return;
			}
			//submarine hanger reset
			m_submarineHanger.resetBoard();
			m_submarineHanger.addSubs();
			m_submarineHanger.setAllTilesDragable(true);
			m_submarineHanger.setParent(this);
			
			//opponent reset
			m_opponentBoard.resetBoard();
			m_opponentBoard.setParent(this);
			m_opponentBoard.setAllTilesClickable(false);
			
			//my reset
			m_myBoard.resetBoard();
			m_myBoard.setAllTilesDragable(true);
			
			m_startGame.Hide();
		}
		
		public void repositoryIsEmpty()
		{
			m_submarineHanger.Hide();
			m_startGame.Show();
			m_startGame.Text = "My submarines are all in place!        Give me a worthy opponent to crush!";
			m_startGame.Enabled = true;
			game.SendData("SU");
			m_submarineHanger.setAllTilesDragable(false);
			m_myBoard.setAllTilesDragable(false);
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
