﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LightMeter.utilidades;
using Microsoft.WindowsMobile.Samples.Location;
using LightMeter.controlador;
using LightMeter.Clases;

namespace LightMeter.interfaz
{
    public partial class TakeData : UserControl
    {

        #region variable globales

        private Form1 main;
        
        private Gps objGps;
        
        private Date_hour _date_hour = null;

        private String coordenateX = null;

        private String coordenateY = null;

        private Input_data datos_externos = new Input_data();

        private Controller_input_data cid = new Controller_input_data();

        private List<Input_data> list_input_data = null;
        
        #endregion 
        /// <summary>
        /// TakeData(main)
        /// </summary>
        /// <param name="main">recibe instancia de MainWindows</param>
        public TakeData(Form1 main)
        {
            InitializeComponent();
          
            this.main = main;
            
            this._date_hour = new Date_hour();

            this.tCodServ.Focus();

            #region configuraciones visuales

            int anchoPanel = Convert.ToInt32(this.Width * 0.5);
            
            this.panel1.Width = anchoPanel;
            
            this.panel2.Width = anchoPanel;
            
            this.panel3.Width = anchoPanel;
            
            this.panel4.Width = anchoPanel;
            
            this.panel5.Width = anchoPanel;
            
            this.pSave.Width = anchoPanel;
            #endregion

            #region comprueba que existan los codigos de servicio o no
           
            if (this.main.cod_service_auto.Count < 1)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            
                DialogResult dr = MessageBox.Show("Debe cargar las ahora.", "", buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                
                if (dr == DialogResult.Yes)
                {
                
                    if (this.main.cargarRutas() > 0)
                    {
                    
                        this.list_input_data = cid.read_file(this.main.filename);
                    
                    }
                    /*else
                    {
                        this.list_input_data = new List<Input_data>();
                        Input_data _ID = new Input_data("00001", "2", "000000004521", "000061869", "005", "0000194", "1.00376");
                        list_input_data.Add(_ID);

                    }*/
                }
            }
            else {
                this.list_input_data = cid.read_file(this.main.filename);
                /*
                this.list_input_data = new List<Input_data>();
                Input_data _ID = new Input_data("00001", "2", "000000004521", "000061869", "005", "0000194", "1.00376");
                list_input_data.Add(_ID);*/
            }
            #endregion

            #region configura y habilita gps
            objGps = this.main.objGps;//new Gps();
            objGps.Close();
            if (!objGps.Opened)
            {
                objGps.LocationChanged += new LocationChangedEventHandler(gps_LocationChanged);
                objGps.Open();
            }
            #endregion
        } 
        //pasa a la siguiente interfaz
        private void panel6_Click_1(object sender, EventArgs e)
        {
            String codigo = this.tCodServ.Text.Trim();
           
            String actual = this.tReadActual.Text.Trim();
            
            String n_medidor = this.tN_medidor.Text.Trim();
            
            String verificador = this.tverificador.Text.Trim();

            try
            {
                if (this.list_input_data.Count > 0)
                {
            
                    this.main.PanelPrincipal.Controls.Clear();
                    
                    this.main.PanelPrincipal.Controls.Add(new NoAcces(this.main, codigo,actual,n_medidor,verificador));
                
                }
                else 
                {
                
                    MessageBox.Show("Para acceder a la siguiente pantalla debe de tener cargadas las rutas."); 
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Ocurrio un error al intentar cargar la pantalla\nPorfavor reinicie la aplicación.");
            }
        }
       
        private void pSave_Click(object sender, EventArgs e)
        {
            save_data();            
        }

        private void  save_data()
        {
            if (validacionFormulario())
            {

                Controller_output_data cod = new Controller_output_data();

                Output_data od = null;

                String codigo = this.tCodServ.Text.Trim();

                String verificador = this.tverificador.Text.Trim();

                String n_medidor = this.tN_medidor.Text.Trim();

                String lectura_mes_cero = this.datos_externos.lectura_mes_cero;

                String prom_consumo = this.datos_externos.prom_consumo;

                String lectura_actual = this.tReadActual.Text.Trim();

                String consumo = cod.get_consumo(lectura_actual, lectura_mes_cero);

                String fecha = this._date_hour.get_date();

                String hora = this._date_hour.get_hour();

                String error = cod.get_error_factor(prom_consumo, lectura_mes_cero);

                String nombre_foto = "";

                String coordX = this.coordenateX == "" ? "0" : this.coordenateX;

                String CoordY = this.coordenateY == "" ? "0" : this.coordenateY;


                od = new Output_data(codigo, verificador, n_medidor, lectura_mes_cero, prom_consumo, lectura_actual,
                                     consumo, fecha, hora, error, nombre_foto, coordX, CoordY);


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
                    String selectedItem = this.listBox1.SelectedItem.ToString();
                
                    this.tCodServ.Text = selectedItem;
                    
                    this.datos_externos = this.get_data(selectedItem);
                    
                    this.tN_medidor.Text = datos_externos.n_medidor;
                
                }
                
                this.tCodServ.TextChanged += new EventHandler(this.tCodServ_TextChanged);
            }
        }

        private Input_data get_data(String selectedItem)
        {
            Input_data idd = null;

            foreach (Input_data id in this.list_input_data)
            {
                if (id.codigo.Equals(selectedItem))
                {
            
                    idd = id;
                    
                    return idd;
                }
            }
            return idd;
        }
        #endregion

        #region seteo y actualizacion de coordenadas por gps
        private void gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            GpsPosition position = args.Position;
            ControlUpdater cu = UpdateControl;
            
            if (position.LatitudeValid && position.LongitudeValid)
            {
                String coordenadas = position.Latitude.ToString() + " " + position.Longitude.ToString();
                this.coordenateX = position.Latitude.ToString("000000.00");
                this.coordenateY = position.Longitude.ToString("000000.00");
            }
        }
        private delegate void ControlUpdater(Control c, string s);
        private void UpdateControl(Control con, string strdata)
        {
            con.Text = strdata;
        }
        #endregion 

        #region algunas validaciones
        
        private Boolean validacionFormulario()
        {
            Boolean flag = false;
          
            flag = !this.tCodServ.Text.Equals("") ? true : false;
            
            flag &= !this.tN_medidor.Text.Equals("") ? true : false;
            
            flag &= !this.tReadActual.Text.Equals("") ? true : false;
            
            flag &= !this.tverificador.Text.Equals("") ? true : false;

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

        private void tObservacion_KeyDown(object sender, KeyEventArgs e)
        {           
            String codigo = this.tCodServ.Text.Trim();
            
            String actual = this.tReadActual.Text.Trim();
            
            String n_medidor = this.tN_medidor.Text.Trim();
            
            String verificador = this.tverificador.Text.Trim();

            if ((e.KeyCode == System.Windows.Forms.Keys.Right)) {
            
                this.main.PanelPrincipal.Controls.Clear();
                
                this.main.PanelPrincipal.Controls.Add(new NoAcces(this.main, codigo,actual,n_medidor,verificador));
            
            }
        }

        private void tGuardar_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Print))
            {

                save_data();

            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Down)) {
                this.listBox1.SelectedIndex = this.listBox1.SelectedIndex < this.listBox1.Items.Count ? this.listBox1.SelectedIndex + 1 : this.listBox1.SelectedIndex ;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Up)) 
            {
                this.listBox1.SelectedIndex = this.listBox1.SelectedIndex > 0 ? this.listBox1.SelectedIndex - 1 : this.listBox1.SelectedIndex;
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter)) 
            {
                listBox1_SelectedValueChanged(sender, e);
            }
        }
      
    }
}
