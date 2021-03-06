﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LightMeter.Clases
{
    class Take_Data
    {
        public int code_service { get; set; }
        public String adress { get; set; }
        public String hour_date { get; set; }
        public String coordenate { get; set; }
        public String motives { get; set; }
        public String file_name { get; set; }
        public int actual_read { get; set; }

        public Take_Data() { }

        public Take_Data(int code_service, String adress, String hour_date, String coordenate, String motive, String file_name)
        {
            this.code_service = code_service;
            this.adress = adress;
            this.hour_date = hour_date;
            this.coordenate = coordenate;
            this.motives = motive;
            this.file_name = file_name;
        }

        public Take_Data(int code_service, int actual_read, String hour_date, String coordenate)
        {
            this.code_service = code_service;
            this.actual_read = actual_read;
            this.hour_date = hour_date;
            this.coordenate = coordenate;
        }

        public int create_File_No_Data()
        {
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("");
                sb.AppendLine("*------------------------*");
                sb.AppendLine("NUMERO_DE_SERVICIO " + this.code_service);
                sb.AppendLine("FECHA_DE_ESTADO " + this.hour_date);
                sb.AppendLine("HORA_DEL_ESTADO "+ this.hour_date);
                sb.AppendLine("OBSERVACION " + this.motives);          
                sb.AppendLine("NOMBRE_FOTO " + this.file_name);
                sb.AppendLine("COORDENADA " + this.coordenate);
                sb.AppendLine("DIRECCION" + this.adress);      
                sb.AppendLine("*------------------------*");


                using (StreamWriter out_file = new StreamWriter(path + @"\lecturas.txt", true))
                {
                    out_file.Write(sb.ToString());
                }
                using (StreamWriter out_file = new StreamWriter(path + @"\lecturas.dat", true))
                {
                    out_file.Write(sb.ToString());
                }

                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Take_Data.create_File_No_Data() " + e.Message);
                return 0;
            }
        }

        public int create_file_take_data() {
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("");
                sb.AppendLine("*------------------------*");
                sb.AppendLine("NUMERO_DE_SERVICIO " + this.code_service);
                sb.AppendLine("LECTURA_ACTUAL " + this.actual_read);
                sb.AppendLine("FECHA_DE_ESTADO " + this.hour_date);
                sb.AppendLine("ESTADO " + this.coordenate);
                sb.AppendLine("*------------------------*");
                using (StreamWriter out_file = new StreamWriter(path + @"\Resultado.txt", true))
                {
                    out_file.Write(sb.ToString());
                }
                using (StreamWriter out_file = new StreamWriter(path + @"\Resultado.dat", true))
                {
                    out_file.Write(sb.ToString());
                }
                return 1;
            }
            catch (Exception e) {
                Console.WriteLine("ERROR Take_Data.create_file_take_data() " + e.Message);
                return 0;
            }
        }
    }
}
