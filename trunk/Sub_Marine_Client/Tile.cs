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
        
        /// <summary>
        /// possible tile states
        /// </summary>
        public enum TileState {Empty, Hit, Miss};

        #region Tile Properties
        /// <summary>
        /// set a tile state.
        /// Possible new states are (TileState.Empty, TileState.Hit & TileState.Miss)
        /// </summary>
        public TileState State
        {
        	set
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
        
        public bool Dragable
        {
        	set
        	{	
        		if (value)
        		{
        			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tile_MouseDown);
	        		this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Tile_DragDrop);
	        		this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Tile_DragEnter);
	        		this.DragLeave += new System.EventHandler(this.Tile_DragLeave);
        		}
        		else
        		{
    			   	this.MouseDown -= new System.Windows.Forms.MouseEventHandler(this.Tile_MouseDown);
		        	this.DragDrop -= new System.Windows.Forms.DragEventHandler(this.Tile_DragDrop);
		        	this.DragEnter -= new System.Windows.Forms.DragEventHandler(this.Tile_DragEnter);
		        	this.DragLeave -= new System.EventHandler(this.Tile_DragLeave);
        		}
        	}
        }
        
        public bool Clickable
        {
        	set
        	{
        		if (value)
        		{
        			this.DoubleClick += new System.EventHandler(this.TileDoubleClick);
        		}
        		else
        		{
        			this.DoubleClick -= new System.EventHandler(this.TileDoubleClick);
        		}
        	}
        }
        #endregion
        
        /// <summary>
        /// Tile c'tor
        /// </summary>
        /// <param name="parent">containing grid</param>
        public Tile(GridPanelBase parent)
        {
            // Initialize
            InitializeComponent();
            m_parent = parent;
        }

        /// <summary>
        /// check if tile is in use
        /// </summary>
        /// <returns>true if it does not contain an image, false otherwise</returns>
        public bool isInUse()
        {
        	return m_image!=null;
        }
        
        /// <summary>
        /// Drop event occured. An image was dropped in this tile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_DragDrop(object sender, DragEventArgs e)
        {   
        	Bitmap draggedImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        	
            // Switch the cursor to the arrow
            this.Cursor = Cursors.Default;

            // Put an item here
            PutItem(draggedImage);
        }

        /// <summary>
        /// Dragged Entered event occured. A dragged image entered this tile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_DragEnter(object sender, DragEventArgs e)
        {
            if (this.BackgroundImage == null)
            {
            	//retrieve the tile number
            	int tileNumber = getTileNumber();
                Bitmap draggedImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                
                //number of default tiles which fit current tile
                int horizImageTiles = draggedImage.Size.Width / TILE_EDGE_LENGTH;
                
                //check if the grabed image can be placed in this tab
                if (m_parent.checkOverlap(tileNumber, horizImageTiles)==false &&
                    (tileNumber % 10) + horizImageTiles <= 10)
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
	        else
	        {
	            // Change the cursor to the arrow
	            this.Cursor = Cursors.Default;
	        }
        }

        /// <summary>
        /// Dragged Leave event occured. A dragged image left this tile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_DragLeave(object sender, EventArgs e)
        {
            // Only do something if the tile has an item
            if (isInUse() == false)
            {
                // Reset the cursor
                this.Cursor = Cursors.Default;
                
                this.BackColor = Color.Black;
                this.Size = new Size(TILE_EDGE_LENGTH, TILE_EDGE_LENGTH);
            	this.BackgroundImage = null;
            }
        }

        /// <summary>
        /// Mouse down event occured. User started a drag event from this tile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_MouseDown(object sender, MouseEventArgs e)
        {
            // Only allowing dragging if it is in use
            if (isInUse() == true)
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

        private delegate void PutItemDelegate(Bitmap image);
                
		/// <summary>
		/// put an image in the current tile
		/// </summary>
		/// <param name="image">image to put in the current tile</param>
        public void PutItem(Bitmap image)
        {
        	if (m_image==null)
        	{
        		if (InvokeRequired)
        		{
        			this.BeginInvoke(new PutItemDelegate(PutItem),new object []{image});
        			return;
        		}
        		m_parent.objectInTileWasAdded(this);
            	this.Size = image.Size;
	            System.Console.Out.WriteLine(Size);
	            m_image = image;
	            this.BackColor = Color.Transparent;
	            this.BackgroundImage = m_image;
	            this.BringToFront();
        	}
        	else
        	{
        		if (InvokeRequired)
        		{
        			this.BeginInvoke(new PutItemDelegate(PutItem),new object []{image});
        			return;
        		}
        		m_upperLayerImage.Image = image;
        		m_upperLayerImage.Show();
        	}
        }

        private delegate void RemoveItemDelegate();
        
        /// <summary>
        /// Takes the image off the tile
        /// </summary>
        public void RemoveItem()
        {
        	if (InvokeRequired)
    		{
    			this.BeginInvoke(new RemoveItemDelegate(RemoveItem));
    			return;
    		}
            this.BackgroundImage = null;
            this.BackColor = Color.Black;
            this.Size = new Size(TILE_EDGE_LENGTH, TILE_EDGE_LENGTH);
            m_image = null;
            m_parent.objectInTileWasRemoved(this);
        }
        
        /// <summary>
        /// Tile double click event occured. User double clicked on the current tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TileDoubleClick(object sender, EventArgs e)
        {	
        	//only allow double clicking on a tile if it is not in use
        	if (isInUse() == false)
        	{
        		m_parent.tileWasClicked(this);
        	}
        }
        
        public void resetTile()
        {
        	this.BackgroundImage = null;
        	m_image = null;
        	this.Dragable = false;
        	this.Clickable = true;
        	this.State = TileState.Empty;
        	m_upperLayerImage.Image = null;
        	m_upperLayerImage.Hide();
        }
        
        public int getTileNumber()
        {
        	int tileNumber = 0;
        	try
        	{
        		Int32.TryParse(this.Name.Replace("tile",""),out tileNumber);
        	}
        	catch (ArgumentException)
        	{
        		MessageBox.Show("Invalid tile name - tile cannot be numbered");
        	}
        	return tileNumber-1;
        }
        
        public int getTileHorizSize()
        {
        	if (BackgroundImage!=null)
        	{
        		return BackgroundImage.Size.Width / TILE_EDGE_LENGTH;
        	}
        	return TILE_EDGE_LENGTH;
        }
    }
}
