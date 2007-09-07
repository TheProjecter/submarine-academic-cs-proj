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
		
		protected void addTilesToList(ControlCollection controlList)
		{
			foreach (Control control in controlList)
			{
				if (control.Name.StartsWith("tile"))
				{
					int tileNumber = 0;
		            try
		            {
		            	string tileNumberString = control.Name.Replace("tile","");
		                Int32.TryParse(tileNumberString,out tileNumber);
		                m_tilesList[tileNumber-1] = (Tile) control;
		            }
		            catch (ArgumentException)
		            {
		
		            }
				}
			}
		}
		
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
	}
}
