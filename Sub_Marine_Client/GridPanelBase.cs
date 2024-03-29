/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 07/09/2007
 * Time: 23:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sub_Marine_Client
{
	/// <summary>
	/// Description of GridPanelBase.
	/// </summary>
	public partial class GridPanelBase : UserControl
	{
				
		private Tile[] m_tilesList = null;
		
		/// <summary>
		/// used for internal purposes by the !@!!@#!@# form desinger
		/// </summary>
		private GridPanelBase()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		/// <summary>
		/// GridPanelBase c'tor
		/// </summary>
		/// <param name="numOfTiles">number of tiles in board</param>
		public GridPanelBase(int numOfTiles)
		{
			m_tilesList = new Tile[numOfTiles];
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/// <summary>
		/// add all tiles from the given controlList in to the internal m_tilesList 
		/// </summary>
		/// <param name="controlList">a list of the controls in the inherited child</param>
		protected void addTilesToList()
		{
			foreach (Control control in Controls)
			{
				if (control.Name.StartsWith("tile"))
				{
	            	Tile tile = (Tile) control;
	            	int tileNumber = tile.getTileNumber();
	                m_tilesList[tileNumber] = tile;
				}
			}
		}
		
		/// <summary>
		/// check for overlapping tiles in a specific tile and for horizSize length
		/// </summary>
		/// <param name="tileNumber">tile number to check</param>
		/// <param name="horizSize">size of the tile object in default tiles</param>
		/// <returns>true if overlap, false otherwise</returns>
		public bool checkOverlap(int tileNumber, int horizSize)
		{
			bool rc = false;
			for (int i=1; !rc && i<horizSize; ++i)
			{
				Tile tile = m_tilesList[tileNumber+i];
				if (tile.isInUse())
				{
					rc = true;
				}
			}
			return rc;
		}
		
		/// <summary>
		/// mark a specific tile with a specific state
		/// </summary>
		/// <param name="tileNumber">the number of the tile in the tile array.
		/// usuablly the number in the tiles name minus one</param>
		/// <param name="state"></param>
		public void markTile(int tileNumber, Tile.TileState state)
		{
			Tile tile = m_tilesList[tileNumber];
			tile.State = state;
		}
		
		/// <summary>
		/// mark all tiles on board with a specific state
		/// look in Tile.TileState for list of possible states
		/// </summary>
		/// <param name="state"></param>
		public void markAllTiles(Tile.TileState state)
		{
			foreach(Tile tile in m_tilesList)
			{
				tile.State = state;
			}
		}
		
		/// <summary>
		/// check if none of the tiles on the board contains an object 
		/// </summary>
		/// <returns>true if board is empty, false otherwise</returns>
		public bool isEmptyBoard()
		{
			bool rc = true;
			foreach(Tile tile in m_tilesList)
			{
				rc &= !tile.isInUse();
			}
			return rc;
		}
		
		/// <summary>
		/// check if a specific tile is in use (contain a submarine or a bomb)
		/// </summary>
		/// <param name="tileNumber">the number of the tile in the tile array.
		/// usuablly the number in the tiles name minus one</param>
		/// <returns>true if tile is not in use, false otherwise</returns>
		public bool isEmptyTile(int tileNumber)
		{
			
			Tile tile = m_tilesList[tileNumber];
			bool rc = !tile.isInUse();
			//check if relevent neighbours are in use
			if (rc && tileNumber >= 1 && m_tilesList[tileNumber-1].isInUse() == true && m_tilesList[tileNumber-1].getTileHorizSize()>1)
			{
				rc = false;
			}
			if (rc && tileNumber >= 2 && m_tilesList[tileNumber-2].isInUse() == true && m_tilesList[tileNumber-2].getTileHorizSize()>2)
			{
				rc = false;
			}
			if (rc && tileNumber >= 3 && m_tilesList[tileNumber-3].isInUse() == true && m_tilesList[tileNumber-3].getTileHorizSize()>3)
			{
				rc = false;
			}
			
			return rc;
		}
		
		/// <summary>
		/// observer design pattern - notify containing board of a
		/// removed submarine
		/// </summary>
		/// <param name="containingTile"></param>
		public virtual void objectInTileWasRemoved(Tile containingTile)
		{
			
		}
		
		/// <summary>
		/// observer design pattern - notify containing board of an
		/// added submarine
		/// </summary>
		/// <param name="containingTile"></param>
		public virtual void objectInTileWasAdded(Tile containingTile)
		{
			
		}
		
		/// <summary>
		/// observer design pattern - notify containing board of an
		/// clicked tile
		/// </summary>
		/// <param name="containingTile"></param>
		public virtual void tileWasClicked(Tile containingTile)
		{
			
		}
		
		/// <summary>
		/// Set all tiles on grid as Dragable according to isDragable
		/// </summary>
		/// <param name="isDragable"></param>
		public void setAllTilesDragable(bool isDragable)
		{
			foreach(Tile tile in m_tilesList)
			{
				tile.Dragable = isDragable;
			}
		}
		
		/// <summary>
		/// Set all tiles on grid as Clickable according to isClickable
		/// </summary>
		/// <param name="isClickable"></param>
		public void setAllTilesClickable(bool isClickable)
		{
			foreach(Tile tile in m_tilesList)
			{
				tile.Clickable = isClickable;
			}
		}
		
		/// <summary>
		/// reset all of the board tile's state
		/// </summary>
		public void resetBoard()
		{
			foreach(Tile tile in m_tilesList)
			{
				tile.resetTile();
			}
		}
		
		public int countTilesOfState(Tile.TileState state)
		{
			int rc = 0;
			foreach(Tile tile in m_tilesList)
			{
				if (tile.State == state)
				{
					rc++;
				}
			}
			return rc;
		}
	}
}
