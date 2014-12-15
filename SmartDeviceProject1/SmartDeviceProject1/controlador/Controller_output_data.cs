using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LightMeter.Clases;
using System.IO;

namespace LightMeter.controlador
{
    class Controller_output_data
    {

        private String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        /*
         * Metodo write_file encargado de crear el archivo de salida de datos
         * del caputador Dolphin 99Ex en fotmato *.txt.
         */
        public int write_file(Output_data _output_data)
        {

            try
            {                                                
                StringBuilder sb = new StringBuilder();

                sb.AppendLine();
                sb.Append(_output_data.codigo);
                sb.Append(",");
                sb.Append(_output_data.verificacion);
                sb.Append(",");
                sb.Append(_output_data.n_medidor);
                sb.Append(",");
                sb.Append(_output_data.lectura_mes_cero);
                sb.Append(",");
                sb.Append(_output_data.prom_consumo);
                sb.Append(",");
                sb.Append(_output_data.lectura_actual);
                sb.Append(",");
                sb.Append(_output_data.consumo);
                sb.Append(",");
                sb.Append(_output_data.fecha);
                sb.Append(",");
                sb.Append(_output_data.hora);
                sb.Append(",");
                sb.Append(_output_data.factor_error);
                sb.Append(","); 
                sb.Append(_output_data.ruta_foto);
                sb.Append(","); 
                sb.Append(_output_data.coordenadaX);
                sb.Append(","); 
                sb.Append(_output_data.coordenadaY);

                using (StreamWriter out_file = new StreamWriter(path + @"\LECTURAS.txt", true))
                {
                    out_file.Write(sb.ToString());
                }

                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Controller_output_data.write_file() " + e.Message);
                return 0;
            }
        }
        

        public String get_error_factor(params String[] args) 
        {
            /*
             * @params args[0] promedio consumo en kWh.
             * @params args[1] lectura anterior en kWh.
             */

            try
            {

                int prom_consumo = Convert.ToInt32(args[0]);

                int lectura_mes_cero = Convert.ToInt32(args[1]);

                double error = (((prom_consumo / lectura_mes_cero) * 1.2) + 1);

                return error.ToString();
            }
            catch (Exception e) 
            {

                MessageBox.Show("Error Controller_output_data.get_error_factor() "+e.Message);

                return "";
            }
        }
        public String get_consumo(params String[] args) 
        {
            /*
             * @params args[0] lectura actual del medidor.
             * @params args[1] lectura mes anterior del medidor.
             */
            try
            {

                int lectura_actual = Convert.ToInt32(args[0]);

                int lectura_mes_cero = Convert.ToInt32(args[1]);

                int consumo = lectura_actual - lectura_mes_cero;

                return consumo.ToString();

            }
            catch (Exception e) 
            {

                MessageBox.Show("Error Controller_output_data.get_consumo() "+e.Message);

                return "";
            }

        }
    }
}
