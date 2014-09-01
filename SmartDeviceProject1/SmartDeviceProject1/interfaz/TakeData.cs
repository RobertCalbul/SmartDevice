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
        #region variable globales
        private Form1 main;
        private Gps objGps;
        #endregion 
        public TakeData(Form1 main)
        {
            InitializeComponent();
            this.main = main;
            #region configuraciones visuales
            int anchoPanel =Convert.ToInt32(this.Width*0.5);
            this.panel1.Width = anchoPanel;
            this.panel2.Width = anchoPanel;
            this.panel3.Width = anchoPanel;
            this.panel4.Width = anchoPanel;
            this.pSave.Width = anchoPanel;
            this.panelNodata.Width = anchoPanel;
            #endregion

            this.tDateHour.Text = this.main.dateFormat(DateTime.Now.ToString("MMddyy hh:mm"));
            #region comprueba que existan los codigos de servicio o no
            if (this.main.cod_service_auto.Count < 1) {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult dr =  MessageBox.Show("No se cargo las rutas\n¿Desea cargarlas ahora?.","",buttons,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    this.main.cargarRutas();
                }
            }
            #endregion

            #region configura y habilita gps
            objGps = this.main.objGps;//new Gps();
            objGps.Close();
            if (!objGps.Opened)
            {
                // objgps.DeviceStateChanged += new DeviceStateChangedEventHandler(gps_DeviceStateChange);
                objGps.LocationChanged += new LocationChangedEventHandler(gps_LocationChanged);
                objGps.Open();
            }
            #endregion
        }
        #region seteo y actualizacion de coordenadas por gps
        private void gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            //this.tCoordenate.Text = "";
            GpsPosition position = args.Position;
            ControlUpdater cu = UpdateControl;
            if (position.LatitudeValid && position.LongitudeValid)
            {
                String coordenadas = position.Latitude.ToString() + " " + position.Longitude.ToString();
                Invoke(cu, tCoordenate, coordenadas);
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
        #endregion 
        //pasa a la siguiente interfaz
        private void panel6_Click_1(object sender, EventArgs e)
        {
            this.main.PanelPrincipal.Controls.Clear();
            this.main.PanelPrincipal.Controls.Add(new NoAcces(this.main));
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
                else
                {
                    MessageBox.Show("Ha ocurrido un error al guardar, por favor intentelo nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else {
                MessageBox.Show("Verifique todos los campo.", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        #region auto-complete codigo servicios
        private void tCodServ_TextChanged(object sender, EventArgs e)
        {
            String typed = this.tCodServ.Text.Trim();
            List<String> autoList = new List<String>();
            autoList.Clear();
            autoList.Add("-----");
            foreach (String item in this.main.cod_service_auto)
            {
                if (!String.IsNullOrEmpty(this.tCodServ.Text.Trim())) {
                    if (item.StartsWith(typed)) {
                        
                        autoList.Add(item);
                    }
                }
            }

            if (autoList.Count > 0) {
                this.listBox1.DataSource = autoList;
                this.listBox1.Visible = true;
            }
            else if (this.tCodServ.Text.Equals(""))
            {
                this.listBox1.Visible = false;
                this.listBox1.DataSource = null;
            }
            else {
                this.listBox1.Visible = false;
                this.listBox1.DataSource = null;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.listBox1.DataSource != null)
            {
                this.listBox1.Visible = false;
                this.tCodServ.TextChanged -= new EventHandler(this.tCodServ_TextChanged);

                if (this.listBox1.SelectedIndex > 0)
                {
                    this.tCodServ.Text = this.listBox1.SelectedItem.ToString();
                }
                this.tCodServ.TextChanged += new EventHandler(this.tCodServ_TextChanged);
            }
        }
        #endregion

        #region algunas validaciones
        private Boolean validacionFormulario()
        {
            Boolean flag = false;
            flag = !this.tCodServ.Text.Equals("") ? true : false;
            flag &= !this.tDateHour.Text.Equals("") ? true : false;
            flag &= !this.tCoordenate.Text.Equals("") ? true : false;
            flag &= !this.tReadActual.Text.Equals("") ? true : false;

            return flag;
        }
        private void tCodServ_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaNumero(e);
        }

        private void tReadActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaNumero(e);
        }

        private void validaNumero(KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar)) e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar)) e.Handled = false;
            else e.Handled = true;
        }
        #endregion 
    }
}
