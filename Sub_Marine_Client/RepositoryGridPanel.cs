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

        public RepositoryGridPanel()
        	:base(20)
        {
            InitializeComponent();
            addTilesToList(Controls);
        }
        
        public void addSubs()
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
    }
}
