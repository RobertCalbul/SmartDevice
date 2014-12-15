using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightMeter.interfaz
{
    /// <summary>
    /// Class Dialog()
    /// </summary>
    public partial class Dialog : Form
    {
        private Form1 main;
        /// <summary>
        /// Dialog()
        /// </summary>
        /// <param name="main">recibe instancia de MainWindows</param>
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