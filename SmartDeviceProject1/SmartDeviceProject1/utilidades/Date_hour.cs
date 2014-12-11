using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LightMeter.utilidades
{
    class Date_hour
    {
        public String get_date()
        {
            
            return DateTime.Now.ToString("MM/dd/yyyy");
        }


        public String get_hour() 
        {

            return  DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
