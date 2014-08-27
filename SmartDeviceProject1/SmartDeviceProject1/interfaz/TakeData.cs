using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LightMeter.Clases;
using Microsoft.WindowsMobile.Samples.Location;
namespace SmartDeviceProject1.interfaz
{
    public partial class TakeData : UserControl
    {
        Form1 main;
        private Gps objGps;
        public TakeData(Form1 main)
        {
            InitializeComponent();
            this.main = main;
            int anchoPanel =Convert.ToInt32(this.Width*0.5);
            this.panel1.Width = anchoPanel;
            this.panel2.Width = anchoPanel;
            this.panel3.Width = anchoPanel;
            this.panel4.Width = anchoPanel;
            this.pSave.Width = anchoPanel;
            this.panelNodata.Width = anchoPanel;
            this.tDateHour.Text = DateTime.Now.ToString("MM/dd/yy hh:mm");
            //this.tDateHour.ForeColor = Color.FromArgb(250, 128, 113);

            MessageBox.Show("ZZ");
            objGps = this.main.objGps;//new Gps();
            if (!objGps.Opened)
            {
                // objgps.DeviceStateChanged += new DeviceStateChangedEventHandler(gps_DeviceStateChange);
                objGps.LocationChanged += new LocationChangedEventHandler(gps_LocationChanged);
                objGps.Open();
            }
        }
        private void gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            //this.tCoordenate.Text = "";
            GpsPosition position = args.Position;
            ControlUpdater cu = UpdateControl;
            if (position.LatitudeValid && position.LongitudeValid)
            {
                //position.Latitude.ToString() + " " + position.Longitude.ToString()
                MessageBox.Show(position.Latitude.ToString() + " " + position.Longitude.ToString());
                Invoke(cu, tCoordenate, "Hola " + "que " + "hace");
            }
            //if (position.LongitudeValid)
            //Invoke(cu, txtgpslong, position.Longitude.ToString());
            //tCoordenate.Text =position.Latitude.ToString()+"  "+position.Longitude.ToString();
            /*if (position.HeadingValid)
                Invoke(cu, txtgpsheading, position.Heading.ToString());
            if (position.SatellitesInViewCountValid)
                Invoke(cu, txtgpssatellite, position.SatellitesInViewCount.ToString());*/


        }

        private delegate void ControlUpdater(Control c, string s);
        private void UpdateControl(Control con, string strdata)
        {
            con.Text = strdata;
        } 
        private void panel6_Click_1(object sender, EventArgs e)
        {
            this.main.PanelPrincipal.Controls.Clear();
            this.main.PanelPrincipal.Controls.Add(new NoAcces(this.main));
        }

        private Boolean validacionFormulario(){
            Boolean flag = false;

            flag = !this.tCodServ.Text.Equals("") ? true : false;
            flag &= !this.tDateHour.Text.Equals("") ? true : false;
            flag &= !this.tCoordenate.Text.Equals("") ? true : false;
            flag &= !this.tReadActual.Text.Equals("") ? true : false;
            
            return flag;
        }

        private void pSave_Click(object sender, EventArgs e)
        {   
            if (validacionFormulario())
            {
                int code = int.Parse(this.tCodServ.Text.Trim());
                int read_actual = int.Parse(this.tReadActual.Text.Trim());
                String date = this.tDateHour.Text.Trim();
                String coordenate = this.tCoordenate.Text.Trim();

                if (new Take_Data(code, read_actual, date, coordenate).create_file_take_data() > 0)
                {
                    new Dialog(this.main).ShowDialog();
                }
            }
            else {
                MessageBox.Show("Verifique todos los campos.");
            }
        }

        private void tCodServ_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaNumero(e);
        }

        private void tReadActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaNumero(e);
        }

        private void validaNumero(KeyPressEventArgs e){

            if (Char.IsDigit(e.KeyChar)) e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar)) e.Handled = false;
            else e.Handled = true;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            this.main.objGps.Close();
            this.main.Close();
        }
    }
}
