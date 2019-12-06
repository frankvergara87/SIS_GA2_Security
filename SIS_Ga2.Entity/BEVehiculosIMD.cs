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
        public double IMD_Base { get; set; }
        public string Tipo_Eje_E1 { get; set; }
        public double Peso_Tonelada_E1 { get; set; }

        public string Tipo_Eje_E2 { get; set; }
        public double Peso_Tonelada_E2 { get; set; }

        public string Tipo_Eje_E3 { get; set; }
        public double Peso_Tonelada_E3 { get; set; }

        public string Tipo_Eje_E4 { get; set; }
        public double Peso_Tonelada_E4 { get; set; }

        public string Tipo_Eje_E5 { get; set; }
        public double Peso_Tonelada_E5 { get; set; }

        public double Valor_FVP { get; set; }
        public double Valor_EE { get; set; }

        public double FechaCreacion { get; set; }
        public double HoraCreacion { get; set; }
        public string UsrCreacion { get; set; }
        public double FechaActualizacion { get; set; }
        public double HoraActualizacion { get; set; }
        public string UsrActualizacion { get; set; }

    }
}
