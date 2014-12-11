using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Forms;
using Microsoft.WindowsMobile.Status;
using LightMeter.Clases;
using Microsoft.WindowsMobile.Samples.Location;
using LightMeter.controlador;
using LightMeter.utilidades;

namespace LightMeter.interfaz
{
    public partial class NoAcces : UserControl
    {
        #region variables globales

        
        private Form1 main;
        
        private String file_name;
        
        private Gps objGps;

        private Date_hour _date_hour = null;

        private String coordenateX = null;

        private String coordenateY = null;

        private Input_data datos_externos = new Input_data();

        Controller_input_data cid = new Controller_input_data();

        List<Input_data> list_input_data = null;

        #endregion
        public NoAcces(Form1 main)
        {
        
            InitializeComponent();
            
            this.main = main;

            this.tCodeService.Focus();
            
            this._date_hour = new Date_hour();
            
            this.list_input_data = cid.read_file(this.main.filename);
            
            #region comprueba que los codigos de servicio o rutas esten cargados
            
            
            if (this.main.cod_service_auto.Count < 1)
            {
            
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                
                DialogResult dr = MessageBox.Show("No se cargo las rutas\n¿Desea cargarlas ahora?.", "", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                
                if (dr == DialogResult.Yes)
                
                {
                
                    this.main.cargarRutas();
                }

            }

            #endregion
            #region configuracio y activacion gps
            objGps = this.main.objGps;// new Gps();
            objGps.Close();
            if (!objGps.Opened)
            {
                // objgps.DeviceStateChanged += new DeviceStateChangedEventHandler(gps_DeviceStateChange);
                objGps.LocationChanged += new LocationChangedEventHandler(gps_LocationChanged);
                objGps.Open();
            }
            #endregion
        }

        private void panelSave_Click(object sender, EventArgs e)
        {

            if (validacionFormulario())
            {

                Controller_output_data cod = new Controller_output_data();

                Output_data od = null;

                String codigo = this.tCodeService.Text.Trim();

                String verificador = this.tVerificador.Text.Trim();

                String n_medidor = this.tN_medidor.Text.Trim();

                String lectura_mes_cero = this.datos_externos.lectura_mes_cero;

                String prom_consumo = this.datos_externos.prom_consumo;

                String lectura_actual = this.tReadActual.Text.Trim();

                String consumo = cod.get_consumo(lectura_actual, lectura_mes_cero);

                String fecha = this._date_hour.get_date();

                String hora = this._date_hour.get_hour();

                String error = cod.get_error_factor(prom_consumo, lectura_mes_cero);

                String observacion = this.cMotivo.SelectedItem.ToString();

                String nombre_foto = this.file_name;

                String coordX = this.coordenateX;

                String CoordY = this.coordenateY;


                od = new Output_data(codigo, verificador, n_medidor, lectura_mes_cero, prom_consumo, lectura_actual,
                                     consumo, fecha, hora, error, observacion, nombre_foto, coordX, CoordY);


                if (cod.write_file(od) > 0)
                {
                    new Dialog(this.main).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al guardar, por favor intentelo nuevamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Verifique todos los campo.", "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        private void panelLoadPhoto_Click(object sender, EventArgs e)
        {
            this.file_name = "";
            CameraCapture(true);
        }

        private void CameraCapture(bool video)
        {
            
            CameraCaptureDialog cameraCapture = new CameraCaptureDialog();
            
            cameraCapture.Owner = this;
            
            cameraCapture.InitialDirectory = @"\My Documents";
            
            cameraCapture.Title = "Camera";
            
            cameraCapture.VideoTypes = CameraCaptureVideoTypes.Messaging;
            
            cameraCapture.Resolution = new Size(176, 144);
            
            cameraCapture.VideoTimeLimit = new TimeSpan(0, 0, 15);
            
            cameraCapture.Mode = CameraCaptureMode.Still;
            
            cameraCapture.DefaultFileName = @"Photo "+DateTime.Now.ToString("MMddyyhhmm")+".jpg";
            
            if (DialogResult.OK == cameraCapture.ShowDialog())
            {
            
                if (!cameraCapture.FileName.Equals(""))
                {
                
                    this.pTakePhoto.Image = new Bitmap(cameraCapture.FileName);
                    
                    this.lblUploadPhoto.Visible = false;
                    
                    this.pTakePhoto.Visible = true;
                    
                    this.file_name = cameraCapture.FileName;
                }

                else
                {
    
                    this.lblUploadPhoto.Visible = false;
                    
                    this.pTakePhoto.Visible = true;
                    
                    MessageBox.Show("Presione la tecla ENT para capturar foto");
                
                }

            }           
            /* if (video){cameraCapture.Mode = CameraCaptureMode.VideoWithAudio;cameraCapture.DefaultFileName = @"videotest.3gp";
             }else{cameraCapture.Mode = CameraCaptureMode.Still;cameraCapture.DefaultFileName = @"imagetest.jpg";}
            */
        }
        private void back_Click(object sender, EventArgs e)
        {

            this.main.PanelPrincipal.Controls.Clear();
            
            this.main.PanelPrincipal.Controls.Add(new TakeData(this.main));
        }

        #region validaciones
        private Boolean validacionFormulario() {
            
            Boolean flag = false;
            
            flag = !this.tReadActual.Text.Equals("") ? true : false;
            
            flag &= !this.tCodeService.Text.Equals("") ? true : false;
            
            
            flag &= !this.tVerificador.Text.Equals("") ? true : false;
            
            flag &= !this.tN_medidor.Text.Equals("") ? true : false;
            
            flag &= this.cMotivo.SelectedItem!=null ? true : false;
            
            flag &= this.pTakePhoto.Image != null ? true : false;
            
            return flag;
        }
        private void validaNumero(KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar)) e.Handled = false;
            
            else if (Char.IsControl(e.KeyChar)) e.Handled = false;
            
            else if (Char.IsSeparator(e.KeyChar)) e.Handled = false;
            
            
            else e.Handled = true;
        }
        private void tCodeService_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaNumero(e);
        }
        #endregion

        #region auto-Complete codigo servicio
        private void tCodeService_TextChanged(object sender, EventArgs e)
        {
            String typed = this.tCodeService.Text.Trim();
            List<String> autoList = new List<String>();
            autoList.Clear();
            autoList.Add("-----");
            foreach (String item in this.main.cod_service_auto)
            {
                if (!String.IsNullOrEmpty(this.tCodeService.Text.Trim()))
                {
                    if (item.StartsWith(typed))
                    {

                        autoList.Add(item);
                    }
                }
            }

            if (autoList.Count > 0)
            {
                this.listBox1.DataSource = autoList;
                this.listBox1.Visible = true;
            }
            else if (this.tCodeService.Text.Equals(""))
            {
                this.listBox1.Visible = false;
                this.listBox1.DataSource = null;
            }
            else
            {
                this.listBox1.Visible = false;
                this.listBox1.DataSource = null;
            }
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.listBox1.DataSource != null)
            {
                this.listBox1.Visible = false;
                this.tCodeService.TextChanged -= new EventHandler(this.tCodeService_TextChanged);

                if (this.listBox1.SelectedIndex > 0)
                {
                    String selectedItem = this.listBox1.SelectedItem.ToString();
                    this.tCodeService.Text = selectedItem;
                    this.datos_externos = this.get_data(selectedItem);
                    this.tN_medidor.Text = datos_externos.n_medidor;
                }
                this.tCodeService.TextChanged += new EventHandler(this.tCodeService_TextChanged);
            }
        }


        private Input_data get_data(String selectedItem)
        {

            foreach (Input_data id in this.list_input_data)
            {
                if (id.codigo.Equals(selectedItem))
                {
                    return id;
                }
                else return new Input_data();
            }
            return new Input_data();
        }
        #endregion

        #region seteo y actualizacion coordenadas por GPS
        private void gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            //this.tCoordenate.Text = "";
            GpsPosition position = args.Position;
            ControlUpdater cu = UpdateControl;
            if (position.LatitudeValid && position.LongitudeValid)
            {
                String coordenadas = position.Latitude.ToString() + " " + position.Longitude.ToString();
                this.coordenateX = position.Latitude.ToString("000000.00");
                this.coordenateY = position.Longitude.ToString("000000.00");
                //Invoke(cu, tCoordenate, coordenadas);
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

        private void NoAcces_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                MessageBox.Show("UP");
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





    }
}
