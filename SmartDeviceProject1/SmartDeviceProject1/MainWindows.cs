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


namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        private Welcome _welcome;
        public Form1()
        {
            InitializeComponent();
            _welcome = new Welcome(this);
            this.PanelPrincipal.Controls.Clear();
            this.PanelPrincipal.Controls.Add(new NoAcces(this));
            
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
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //this.PanelPrincipal.Controls.Clear();
            //this.PanelPrincipal.Controls.Add(new aaa().getPagel());
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (PanelPrincipal.Controls.Equals("Welcome")) MessageBox.Show("HOLA");
        }
    }
}