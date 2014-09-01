using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace LightMeter.Clases
{
    class Archivo
    {
        private String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public List<String> readRuta(String fileName) {
            String line = null;
            List<String> output = null;
            StreamReader sr = null;
            try {
                output = new List<string>();
                sr = new StreamReader(fileName);
                line = sr.ReadLine();
                while (line != null) {
                    output.Add(line);
                    line = sr.ReadLine();
                }
                return output;
                //sr.Close();
            }catch(IOException e){
                Console.WriteLine("ERROR archivo.read() "+e.Message);
                return output;
            }
        }

        public byte write(StringBuilder sb, String fileName)
        {
            byte output = 0;
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                StreamWriter out_file = new StreamWriter(path + @"\" + fileName, true);
                
                out_file.Write(sb.ToString());
                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error archivo.write() " + e.Message);
                return output;
            }
        }
    }
}
