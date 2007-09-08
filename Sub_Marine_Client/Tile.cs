using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sub_Marine_Client
{
    public partial class Tile : UserControl
    {
        private Bitmap m_image;
        private GridPanelBase m_parent;
        private TileState m_state;
        private const int TILE_EDGE_LENGTH = 30;
        
        public enum TileState {Set, Freeze, Hit, Miss};

        public TileState State
        {
        	set
        	{
        		if (value != TileState.Set && 
        		    (m_state == TileState.Set || m_state == TileState.Freeze))
        		{
        			string directory = "";
        			string newBackFileName = null;
#if DEBUG
            		directory = "../../Icons/";
#endif
        			switch (value)
        			{
        				case TileState.Hit:
        					newBackFileName = directory + "hit.bmp";
        					break;
        				case TileState.Miss:
        					newBackFileName = directory + "missed.jpg";
        					break;
        			}
        			if (newBackFileName!=null)
        			{
        				Bitmap newBack = new Bitmap(newBackFileName);
        				PutItem(newBack);
        			}
        			m_state = value;
        		}
        	}
        }
        
        public Tile(GridPanelBase parent)
        {
            // Initialize
            InitializeComponent();
            
            m_parent = parent;
        }

        public bool isInUse()
        {
        	return m_image!=null;
        }
        
        private void Tile_DragDrop(object sender, DragEventArgs e)
        {   
        	Bitmap draggedImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        	
            // Switch the cursor to the arrow
            this.Cursor = Cursors.Default;

            // Put an item here
            PutItem(draggedImage);
        }

        private void Tile_DragEnter(object sender, DragEventArgs e)
        {
            if (this.BackgroundImage == null && m_state == TileState.Set)
            {
				int tileNumber = 0;
	            try
	            {
	                Int32.TryParse(this.Name.Replace("tile",""),out tileNumber);
	                Bitmap draggedImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
	                int horizImageTiles = draggedImage.Size.Width / TILE_EDGE_LENGTH;
	                
	                if (m_parent.checkOverlap(tileNumber-1, horizImageTiles)==false &&
	                    ((tileNumber-1) % 10) + horizImageTiles <= 10)
	                {
		                // Check to see if we can handle what is being dragged
		                if (e.Data.GetDataPresent(DataFormats.Bitmap))
		                {
		
		                    // Change the cursor to a hand
		                    this.Cursor = Cursors.Hand;
		
		                    // Lets it know what effects can be done
		                    e.Effect = DragDropEffects.Copy;
		
		                    this.Size = draggedImage.Size;
		                    this.BackColor = Color.Transparent;
		                    this.BackgroundImage = draggedImage;
		                    this.BringToFront();
		                }
	                }
	                else
	                {
	                	e.Effect = DragDropEffects.None;
	                }
		        }
	            catch (ArgumentException)
	            {
	
	            }
            }
            else
            {
                // Change the cursor to the arrow
                this.Cursor = Cursors.Default;
            }
        }

        private void Tile_DragLeave(object sender, EventArgs e)
        {
            // Only do something if the tile has an item
            if (this.m_image == null)
            {
                // Reset the cursor
                this.Cursor = Cursors.Default;
                
                this.BackColor = Color.Black;
                this.Size = new Size(TILE_EDGE_LENGTH, TILE_EDGE_LENGTH);
            	this.BackgroundImage = null;
            }
        }

        private void Tile_MouseDown(object sender, MouseEventArgs e)
        {
            // Only allowing dragging if there is an item
            if (m_state == TileState.Set && this.BackgroundImage != null)
            {

                // Start the dragging process
                DragDropEffects effect = DoDragDrop(this.BackgroundImage, DragDropEffects.Copy);

                // Check to see if the image was dropped somewhere
                if (effect != DragDropEffects.None)
                {

                    // It was dropped so remove the item
                    RemoveItem();
                }
            }
        }

        #region PutItem
        /// <summary>
        /// Put an item on the tile.
        /// </summary>
        public void PutItem(Bitmap image)
        {
            this.Size = image.Size;
            System.Console.Out.WriteLine(Size);
            m_image = image;
            this.BackColor = Color.Transparent;
            this.BackgroundImage = m_image;
            this.BringToFront();
        }
        #endregion

        #region RemoveItem
        /// <summary>
        /// Takes the item off the tile
        /// </summary>
        public void RemoveItem()
        {
            this.BackgroundImage = null;
            this.BackColor = Color.Black;
            this.Size = new Size(TILE_EDGE_LENGTH, TILE_EDGE_LENGTH);
            m_image = null;
        }
        #endregion


        
        void TileDoubleClick(object sender, EventArgs e)
        {
        	if (m_state == TileState.Freeze)
        	{
        		TileState result = TileState.Freeze;
        		
        		//TODO ask server instead of user
        		string message = "Is it a hit? If not, then it's a miss...";
                string caption = "Choose result";
		        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
		        DialogResult mbresult;
		
		        mbresult = MessageBox.Show(message, caption, buttons);
		
		        result = (mbresult == System.Windows.Forms.DialogResult.Yes)? TileState.Hit: TileState.Miss;
	
				this.State = result;
        	}
        }
    }
}
