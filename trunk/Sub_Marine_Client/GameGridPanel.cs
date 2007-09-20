using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sub_Marine_Client
{
    public partial class GameGridPanel : GridPanelBase
    {    	
    	private Client_Form m_parent = null;
    	
        public GameGridPanel()
        	:base(100)
        {
            InitializeComponent();
            addTilesToList();
        }

        /// <summary>
        /// Game board title
        /// </summary>
        public override string Text
        {
            get
            {
                return m_title.Text;
            }
            set
            {
                m_title.Text = value;
            }
        }
        
        /// <summary>
		/// observer design pattern - notify containing board of an
		/// clicked tile
		/// </summary>
		/// <param name="containingTile"></param>
		public override void tileWasClicked(Tile containingTile)
		{
			int tileNumber = containingTile.getTileNumber();
			if(m_parent != null)
			{
				m_parent.sendData(Client_Form.DataType.GUESS, tileNumber.ToString());
			}
		}
		
		public void setParent(Client_Form parent)
		{
			m_parent = parent;
		}
    }
}
