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

namespace SmartDeviceProject1.interfaz
{
    public partial class NoAcces : UserControl
    {
        Form1 main;
        public NoAcces(Form1 main)
        {
            InitializeComponent();
            this.main = main;
            this.tDateHour.Text = DateTime.Now.ToString("MM/dd/yy hh:mm");
        }

        private void panelSave_Click(object sender, EventArgs e)
        {
            new Dialog(this.main).ShowDialog();
        }

        private void panelLoadPhoto_Click(object sender, EventArgs e)
        {
            this.pTakePhoto.Visible = true;
            this.lblUploadPhoto.Visible = false;
            //MessageBox.Show(CameraPresent().ToString());
            CameraCapture(true);
        }
        public bool CameraPresent()
	{
	    return SystemState.CameraPresent;
	}
        private void CameraCapture(bool video)
        {
            CameraCaptureDialog cameraCapture = new CameraCaptureDialog();

            //Control that owns the CameraCaptureDialog.
            cameraCapture.Owner = this;
            //Directory to save the captured media.
            cameraCapture.InitialDirectory = @"\My Documents";
            //Header title.
            cameraCapture.Title = "Camera Demo";
            //Video clip quality.
            cameraCapture.VideoTypes = CameraCaptureVideoTypes.Messaging;
            //Camera resolution.
            cameraCapture.Resolution = new Size(176, 144);
            // Limited to 15 seconds of video.
            cameraCapture.VideoTimeLimit = new TimeSpan(0, 0, 15);
            //Set capture mode to Video with audio if parameter video is true,
            //else set capture mode to still image.
            if (video)
            {
                cameraCapture.Mode = CameraCaptureMode.VideoWithAudio;
                cameraCapture.DefaultFileName = @"videotest.3gp";
            }
            else
            {
                cameraCapture.Mode = CameraCaptureMode.Still;
                cameraCapture.DefaultFileName = @"imagetest.jpg";
            }

            if (DialogResult.OK == cameraCapture.ShowDialog())
            {
                //CameraCaptureDialog is completed and will return to
                //your application.
                //If you want to do something special when returning
                //from CameraCaptureDialog you can do it here.
            }
        }
      private void back_Click(object sender, EventArgs e)
       {
            this.main.PanelPrincipal.Controls.Clear();
            this.main.PanelPrincipal.Controls.Add(new TakeData(this.main));
        }
    }
}
