using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sub_Marine_Client
{
    public partial class RepositoryGridPanel : GridPanelBase
    {
        private Bitmap sub1;
        private Bitmap sub2;
        private Bitmap sub3;
        private Bitmap sub4;
        private Client_Form m_parent = null;

        public RepositoryGridPanel()
        	:base(20)
        {
            InitializeComponent();
            addTilesToList(Controls);
        }
        
        public void setParent(Client_Form parent)
        {
        	m_parent = parent;
        }
        
        /// <summary>
        /// add the submarines to the repository in thier rightful places
        /// </summary>
        public void addSubs()
        {	
        	try
        	{
        		string directory = "";
#if DEBUG
            	directory = "../../Icons/";
#endif

	            sub1 = new System.Drawing.Bitmap(directory + "Submarine1.jpg");
	            sub2 = new System.Drawing.Bitmap(directory + "Submarine2.jpg");
	            sub3 = new System.Drawing.Bitmap(directory + "Submarine3.jpg");
	            sub4 = new System.Drawing.Bitmap(directory + "Submarine4.jpg");
	            
	            tile1.PutItem(sub1);
	            tile2.PutItem(sub1);
	            tile3.PutItem(sub1);
	            tile4.PutItem(sub1);
	
	            tile5.PutItem(sub2);
	            tile7.PutItem(sub2);
	            tile9.PutItem(sub2);
	
	            tile11.PutItem(sub3);
	            tile14.PutItem(sub3);
	
	            tile17.PutItem(sub4);
        	}
        	catch (Exception)
        	{
        		MessageBox.Show("Missing submarine icons from at the game folder. Closing game.",
        		                "Error", 
        		                MessageBoxButtons.OK,
        		                MessageBoxIcon.Error);
        		Application.Exit();
        	}
        }
        
        /// <summary>
        /// when tile is removed, check if the board is empty (non of the tiles is in
        /// use). if it's empty hide the repository board. 
        /// </summary>
        /// <param name="containingTile"></param>
        public override void objectInTileWasRemoved(Tile containingTile)
		{
			if (isEmptyBoard()==true)
			{
				if (m_parent != null)
				{
					m_parent.repositoryIsEmpty();
				}
			}
		}
    }
}
