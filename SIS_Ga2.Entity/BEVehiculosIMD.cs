using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BEVehiculosIMD
    {
        public int Id_Vehiculos_IMD { get; set; }
        public int Id_Vehiculos { get; set; }
        public int Id_Repet_Equivalentes { get; set; }
        public int Estado { get; set; }
        public double IMD_Base { get; set; }
        public string Tipo_Eje_E1 { get; set; }
        public double Peso_Tonelada_E1 { get; set; }

        public string Tipo_Eje_E2 { get; set; }
        public string Vehiculos  { get; set; }
        public string Ruta_imagen { get; set; }
        public double Peso_Tonelada_E2 { get; set; }

        public string Tipo_Eje_E3 { get; set; }
        public double Peso_Tonelada_E3 { get; set; }

        public string Tipo_Eje_E4 { get; set; }
        public double Peso_Tonelada_E4 { get; set; }

        public string Tipo_Eje_E5 { get; set; }
        public double Peso_Tonelada_E5 { get; set; }

        public double Valor_FVP { get; set; }
        public double Valor_EE { get; set; }


        public double Fecha_Creacion { get; set; }
        public double Hora_Creacion { get; set; }
        public string Usr_Creacion { get; set; }

        public double Fecha_Actualizacion { get; set; }
        public double Hora_Actualizacion { get; set; }
        public string Usr_Actualizacion { get; set; }

    }
}
