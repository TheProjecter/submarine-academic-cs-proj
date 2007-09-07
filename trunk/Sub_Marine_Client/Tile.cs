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

        public Tile()
        {
            // Initialize
            InitializeComponent();
        }

        private void Tile_DragDrop(object sender, DragEventArgs e)
        {
            int tileNumber = 0;
            try
            {
                Int32.TryParse(this.Name.Replace("tile",""),out tileNumber);
                Bitmap draggedImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                int vertImageTiles = draggedImage.Size.Height / 30;
                int horizImageTiles = draggedImage.Size.Width / 30;
                
                if ((tileNumber % 10) + horizImageTiles < 10)
                {
                    // Switch the cursor to the arrow
                    this.Cursor = Cursors.Default;

                    // Put an item here
                    PutItem(draggedImage);
                }
            }
            catch (ArgumentException)
            {

            }
        }

        private void Tile_DragEnter(object sender, DragEventArgs e)
        {
            if (this.BackgroundImage == null)
            {

                // Check to see if we can handle what is being dragged
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                {

                    // Change the cursor to a hand
                    this.Cursor = Cursors.Hand;

                    // Lets it know what effects can be done
                    e.Effect = DragDropEffects.Copy;

                    this.BackgroundImage = (Bitmap) e.Data.GetData(DataFormats.Bitmap);
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
            if (this.BackgroundImage == null)
            {
                // Reset the cursor
                this.Cursor = Cursors.Default;
            }

            this.BackgroundImage = null;
        }

        private void Tile_MouseDown(object sender, MouseEventArgs e)
        {
            // Only allowing dragging if there is an item
            if (this.BackgroundImage != null)
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
            m_image = image;
            this.BackColor = Color.Transparent;
            this.BackgroundImage = m_image;
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
            this.Size = new Size(30, 30);
        }
        #endregion


    }
}
