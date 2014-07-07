using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProject1.interfaz
{
    public partial class TakeData : UserControl
    {
        Form1 main;
        public TakeData(Form1 main)
        {
            InitializeComponent();
            this.main = main;
            int anchoPanel =Convert.ToInt32(this.Width*0.5);
            this.panel1.Width = anchoPanel;
            this.panel2.Width = anchoPanel;
            this.panel3.Width = anchoPanel;
            this.panel4.Width = anchoPanel;
            this.panel5.Width = anchoPanel;
            this.panelNodata.Width = anchoPanel;
            this.tDateHour.Text = DateTime.Now.ToString("MM/dd/yy hh:mm");
            this.tDateHour.ForeColor = Color.FromArgb(250, 128, 113);
        }

        private void TakeData_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Click_1(object sender, EventArgs e)
        {
            this.main.PanelPrincipal.Controls.Clear();
            this.main.PanelPrincipal.Controls.Add(new NoAcces(this.main));
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.main.PanelPrincipal.Controls.Clear();
            this.main.PanelPrincipal.Controls.Add(new Welcome(this.main));
        }

    }
}
