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
            this.pSave.Width = anchoPanel;
            this.panelNodata.Width = anchoPanel;
            this.tDateHour.Text = DateTime.Now.ToString("MM/dd/yy hh:mm");
            //this.tDateHour.ForeColor = Color.FromArgb(250, 128, 113);
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
        {   //MessageBox.Show("click "+ validacionFormulario());
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
    }
}
