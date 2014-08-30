using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SmartDeviceProject1.interfaz;
using System.Threading;
using Microsoft.WindowsMobile.Samples.Location;

namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        private Welcome _welcome;
        public Gps objGps;
        public Form1()
        {
            InitializeComponent();
            _welcome = new Welcome(this);
            this.PanelPrincipal.Controls.Clear();
            this.PanelPrincipal.Controls.Add(_welcome);
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            objGps = new Gps();
            
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                this.PanelPrincipal.Controls.Clear();
                this.PanelPrincipal.Controls.Add(new TakeData(this));
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            if (Timer.Interval >= 1000) {
                this.Timer.Dispose();
                this.PanelPrincipal.Controls.Clear();
                this.PanelPrincipal.Controls.Add(new TakeData(this));
            }
        }


        private void menuItem3_Click(object sender, EventArgs e)
        {
            this.objGps.Close();
            this.Close();
        }

    }
}