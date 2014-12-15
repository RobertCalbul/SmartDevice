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
    /// <summary>
    /// Class Welcome, pantalla de Bienvenida tiempo de duracion 1 seg
    /// </summary>
    public partial class Welcome : UserControl
    {
        /// <summary>
        /// main almacena instancia de MainWindows
        /// </summary>
        public Form1 main;
        /// <summary>
        /// Almacena ruta del archivo RUTAS.txt
        /// </summary>
        /// <param name="main">Recibe instancia MainWindows desde MainWindows</param>
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
        }
    }
}
