using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sub_Marine_Client
{
    public partial class RepositoryGridPanel : UserControl
    {
        private Bitmap sub1;
        private Bitmap sub2;
        private Bitmap sub3;
        private Bitmap sub4;

        public RepositoryGridPanel()
        {
            InitializeComponent();

            sub1 = new System.Drawing.Bitmap("Submarine1.jpg");
            sub2 = new System.Drawing.Bitmap("Submarine2.jpg");
            sub3 = new System.Drawing.Bitmap("Submarine3.jpg");
            sub4 = new System.Drawing.Bitmap("Submarine4.jpg");

            tile1.PutItem(sub1);
            tile2.PutItem(sub1);
            tile3.PutItem(sub1);
            tile4.PutItem(sub1);

            tile5.PutItem(sub2);
            tile6.PutItem(sub2);
            tile7.PutItem(sub2);

            tile8.PutItem(sub3);
            tile9.PutItem(sub3);

            tile10.PutItem(sub4);
        }
    }
}
