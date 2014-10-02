using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        private interfaz_NoDatos _NoIngreso;
        private interfaz_SiDatos _SiIngreso;
        public Form1()
        {
            InitializeComponent();
            _NoIngreso = new interfaz_NoDatos();
            _SiIngreso = new interfaz_SiDatos();
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.PanelPrincipal.Controls.Clear();
            this.PanelPrincipal.Controls.Add(_NoIngreso);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.PanelPrincipal.Controls.Clear();
            this.PanelPrincipal.Controls.Add(_SiIngreso);
        }
    }
}