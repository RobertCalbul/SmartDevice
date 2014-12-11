using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using Microsoft.WindowsMobile.Sample.Location;

namespace LightMeter.interfaz
{
    public partial class Welcome : UserControl
    {
        public Form1 main;
        public Welcome(Form1 main)
        {
            InitializeComponent();
            this.main = main;
            int wl = Convert.ToInt32(this.Width * 0.2);
            this.panel1.Width = wl;
            this.panel2.Width = wl;
            this.panel3.Width = wl;
            this.panel4.Width = wl;
            this.panel5.Width = wl;
            this.panel6.Width = wl;
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            this.main.PanelPrincipal.Controls.Clear();
            this.main.PanelPrincipal.Controls.Add(new TakeData(main));

           // Gps gps = new Gps();

        }
    }
}
