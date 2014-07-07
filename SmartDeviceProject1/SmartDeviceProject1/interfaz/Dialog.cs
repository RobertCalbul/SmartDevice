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