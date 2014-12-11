using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LightMeter.Clases
{
    class Output_data
    {
        public String codigo { get; set; }

        public String verificacion { get; set; }

        public String n_medidor { get; set; }
        
        public String lectura_mes_cero { get; set; }
        
        public String prom_consumo { get; set; }

        public String lectura_actual{get; set;}

        public String consumo { get; set; }

        public String fecha { get; set; }

        public String hora { get; set; }
        
        public String factor_error { get; set; }

        public String observacion { get; set; }

        public String ruta_foto { get; set; }

        public String coordenadaX { get; set; }

        public String coordenadaY { get; set; }

        public Output_data() { }

        public Output_data( String codigo, String verificacion, String n_medidor, String lectura_mes_cero, 
                            String prom_consumo, String lectura_actual, String consumo, String fecha, 
                            String hora, String factor_error, String observacion, String ruta_foto, 
                            String coordenadaX, String coordenadaY ) 
        {
            this.codigo = codigo;

            this.verificacion = verificacion;

            this.n_medidor = n_medidor;

            this.lectura_mes_cero = lectura_mes_cero;

            this.prom_consumo = prom_consumo;

            this.lectura_actual = lectura_actual;

            this.consumo = consumo;

            this.fecha = fecha;

            this.hora = hora;

            this.factor_error = factor_error;

            this.observacion = observacion;

            this.ruta_foto = ruta_foto;

            this.coordenadaX = coordenadaX;

            this.coordenadaY = coordenadaY;
        }


    }
}
