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

namespace SmartDeviceProject1.interfaz
{
    public partial class NoAcces : UserControl
    {
        Form1 main;
        private String file_name;
        private Gps objGps;
        public NoAcces(Form1 main)
        {
            InitializeComponent();
            this.main = main;
            this.tDateHour.Text = DateTime.Now.ToString("MM/dd/yy hh:mm");


            objGps = this.main.objGps;// new Gps();
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
                Invoke(cu, tCoordenate, position.Latitude.ToString() + " " + position.Longitude.ToString());
                MessageBox.Show(position.Latitude.ToString() + " " + position.Longitude.ToString());
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





        private void panelSave_Click(object sender, EventArgs e)
        {
            if (validacionFormulario())
            {
                int code_service = int.Parse(this.tCodeService.Text.Trim());
                String adress = this.tAdrres.Text.Trim();
                String hour_date = this.tDateHour.Text.Trim();
                String coordenate = this.tCoordenate.Text.Trim();
                String movite = this.cMotivo.SelectedItem.ToString();

                if (new Take_Data(code_service, adress, hour_date, coordenate, movite, file_name).create_File_No_Data() > 0)
                {
                    new Dialog(this.main).ShowDialog();
                }
            }
            else MessageBox.Show("Verifique todos los campo.");
        }

        private void panelLoadPhoto_Click(object sender, EventArgs e)
        {
            this.file_name = "";
            CameraCapture(true);
        }
    /*    public bool CameraPresent()
	{
	    return SystemState.CameraPresent;
	}*/
        private void CameraCapture(bool video)
        {
            CameraCaptureDialog cameraCapture = new CameraCaptureDialog();
           
            cameraCapture.Owner = this;
            cameraCapture.InitialDirectory = @"\My Documents";
            //Header title.
            cameraCapture.Title = "Camera";
            //Video clip quality.
            cameraCapture.VideoTypes = CameraCaptureVideoTypes.Messaging;
            //Camera resolution.
            cameraCapture.Resolution = new Size(176, 144);
            // Limited to 15 seconds of video.
            cameraCapture.VideoTimeLimit = new TimeSpan(0, 0, 15);
            //Set capture mode to Video with audio if parameter video is true,
            //else set capture mode to still image.e);
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
           
            /* if (video)
             {
                 cameraCapture.Mode = CameraCaptureMode.VideoWithAudio;
                 cameraCapture.DefaultFileName = @"videotest.3gp";
             }
             else
             {
                 cameraCapture.Mode = CameraCaptureMode.Still;
                 cameraCapture.DefaultFileName = @"imagetest.jpg";
             }
         */
        }
        private void back_Click(object sender, EventArgs e)
        {
            this.main.PanelPrincipal.Controls.Clear();
            this.main.PanelPrincipal.Controls.Add(new TakeData(this.main));
        }

        private Boolean validacionFormulario() {
            Boolean flag = false;
            flag = !this.tAdrres.Text.Equals("") ? true : false;
            flag &= !this.tCodeService.Text.Equals("") ? true : false;
            flag &= !this.tCoordenate.Text.Equals("") ? true : false;
            flag &= !this.tDateHour.Text.Equals("") ? true : false;
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

    }
}
