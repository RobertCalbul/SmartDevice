using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProject1.interfaz
{
    public partial class Dialog : Form
    {
        Form1 main;
        public Dialog(Form1 main)
        {
            InitializeComponent();
            this.main = main;

            int dif_width = this.main.Width - this.Width;
            int dif_height = this.main.Height - this.Height;

            this.Location = new Point((dif_height / 2), (dif_width / 2));

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dialog_Load(object sender, EventArgs e)
        {

        }
    }
}