using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace LightMeter.Clases
{
    class GoogleMap
    {
        public String geoURL(String address)
        {
            string geoURL = "";

            if (address != "")
            {
                address = address.Trim();
                address = address.Replace(" ", "+");

                geoURL = @"http://maps.googleapis.com/maps/api/geocode/json?address=###ADDRESS###&region=cl";

                geoURL = geoURL.Replace("###ADDRESS###", address);
            }
            return geoURL;
        }

        public String[] loadLatitudLatitud(string geoURL)
        {
            String[] point = null;
            string csvValues = "";
            try
            {
                WebRequest objWebRequest = WebRequest.Create(geoURL);
                WebResponse objWebResponse = objWebRequest.GetResponse();
                Stream objWebStream = objWebResponse.GetResponseStream();

                using (StreamReader objStreamReader = new StreamReader(objWebStream))
                {
                    csvValues = objStreamReader.ReadToEnd();
                }


                if (csvValues != null)
                {
                    csvValues = csvValues.Replace(" ", "").Replace("\n", "");
                    String res = csvValues.Substring(csvValues.IndexOf("location"), 80);
                    int start = res.IndexOf("{");
                    res = res.Substring(start + 1, (res.IndexOf("}") - start) - 1);

                    res = res.Replace("\"lat\":", "").Replace("\"lng\":", "");

                    point = res.Split(',');
                    return point;
                }
                else return point;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return point;
                
            }
        }

    }
}
