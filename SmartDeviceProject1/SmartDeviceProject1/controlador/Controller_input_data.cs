using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LightMeter.Clases;

namespace LightMeter.controlador
{
    class Controller_input_data
    {
        private String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        
        /*
         * Metodo read_file encargado de leer los datos del archivo de rutas,
         * el archivo de rutas debe de ser cargado antes de realizar las primeras acciones
         * mediante el buscador de archivos del dispositivo movile.
         */
        public List<Input_data> read_file(String file_name)
        {

            String line = null;

            List<Input_data> output = null;

            StreamReader sr = null;


            try
            {

                output = new List<Input_data>();

                sr = new StreamReader(file_name);

                line = sr.ReadLine();

                //output.Add(split_token(line));

                while (line != null)
                {
                    
                    output.Add(split_token(line));

                    line = sr.ReadLine();
                }

                return output;

            }
            catch (IOException e)
            {

                MessageBox.Show("ERROR Controller_input_data.read_file() " + e.Message);

                return output;
            }
        }

        /*
         * Metodo split_token separa los datos extraidos del archivo y lo estructura
         * mediante la clase input_data.
         */
        public Input_data split_token(String line) 
        {

            /*
             * @params line, obtiene la linea actual del archivo capturando todo el contenido de esta.
             */
            Input_data _input_data = null;

            try
            {

                _input_data = new Input_data();

                String[] word = line.Split(',');

                _input_data.codigo = word[0];
                _input_data.verificacion = word[1];
                _input_data.n_medidor = word[2];
                _input_data.lectura_mes_cero = word[3];
                _input_data.enteros = word[4];
                _input_data.prom_consumo = word[5];
                _input_data.factor_error = word[6];

                return _input_data;

            }catch(Exception e)
            {

                MessageBox.Show("Error Controller_input_data.Split_token "+e.Message);

                return _input_data;

            }
        }

    }
}

