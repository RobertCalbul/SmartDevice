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
using LightMeter.Clases;

namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        private Welcome _welcome;
        public Gps objGps;
        public List<String> cod_service_auto = new List<string>();
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

        public String dateFormat(String date) {
            String[] data = date.Split(' ');
            return data[0].Substring(0, 2) + "/" + data[0].Substring(2, 2) + "/" + data[0].Substring(4, 2) +" "+data[1];
        }

        private void menuItemRutas_Click(object sender, EventArgs e)
        {
            cargarRutas();
        }

        public void cargarRutas()
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos txt(*.txt) | *.txt";
            ofd.InitialDirectory = "\\My Documents";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<String> listaRuta = new Archivo().readRuta(ofd.FileName);
                if (listaRuta != null)
                {
                    this.cod_service_auto = listaRuta;
                }
                else {
                    MessageBox.Show("No se puede cargar este archivo.","",MessageBoxButtons.OK,MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
                } 
            }
            else
            {

            }
        }

    }
}