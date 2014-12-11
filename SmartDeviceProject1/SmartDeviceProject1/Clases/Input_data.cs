using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LightMeter.Clases
{
    class Input_data
    {
        public String codigo { get; set; }

        public String verificacion { get; set; }

        public String n_medidor { get; set; }
        
        public String lectura_mes_cero { get; set; }
        
        public String enteros { get; set; }
        
        public String prom_consumo { get; set; }
        
        public String factor_error { get; set; }

        public Input_data() { }

        public Input_data(String codigo, String verificacion, String n_medidor, String lectura_mes_cero, String enteros, String prom_consumo, String factor_error) 
        {
            this.codigo = codigo;

            this.verificacion = verificacion;

            this.n_medidor = n_medidor;

            this.lectura_mes_cero = lectura_mes_cero;

            this.enteros = enteros;

            this.prom_consumo = prom_consumo;

            this.factor_error = factor_error;
        }

    }
}
