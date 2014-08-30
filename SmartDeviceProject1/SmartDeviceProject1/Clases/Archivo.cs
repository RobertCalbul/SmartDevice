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
        public String read(String fileName) {
            String line = null;
            String output = null;
            StreamReader sr = null;
            try {
                sr = new StreamReader(path + @"\" + fileName);
                line = sr.ReadLine();
                while (line != null) {
                    output += line;
                    line = sr.ReadLine();
                }
                return output;
                sr.Close();
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
