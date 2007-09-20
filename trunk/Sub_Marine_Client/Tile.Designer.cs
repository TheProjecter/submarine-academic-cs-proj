namespace Sub_Marine_Client
{
    partial class Tile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.m_upperLayerImage = new System.Windows.Forms.PictureBox();
        	((System.ComponentModel.ISupportInitialize)(this.m_upperLayerImage)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// m_upperLayerImage
        	// 
        	this.m_upperLayerImage.Location = new System.Drawing.Point(0, 0);
        	this.m_upperLayerImage.Name = "m_upperLayerImage";
        	this.m_upperLayerImage.Size = new System.Drawing.Size(30, 30);
        	this.m_upperLayerImage.TabIndex = 0;
        	this.m_upperLayerImage.TabStop = false;
        	this.m_upperLayerImage.Visible = false;
        	// 
        	// Tile
        	// 
        	this.AllowDrop = true;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.Transparent;
        	this.Controls.Add(this.m_upperLayerImage);
        	this.Name = "Tile";
        	this.Size = new System.Drawing.Size(25, 25);
        	((System.ComponentModel.ISupportInitialize)(this.m_upperLayerImage)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.PictureBox m_upperLayerImage;

        #endregion
    }
}
