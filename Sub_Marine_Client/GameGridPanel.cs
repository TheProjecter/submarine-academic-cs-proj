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
        public GameGridPanel()
        	:base(100)
        {
            InitializeComponent();
            addTilesToList(Controls);
        }
    }
}
