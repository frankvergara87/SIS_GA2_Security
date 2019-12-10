using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BERepeticionesEqui
    {
        public int Id_Tasa_Crecimiento { get; set; }
        public int Id_Prop_Factor_Distrib { get; set; }
        public int Dias_Diseno { get; set; }
        public decimal FP { get; set; }
        public decimal Tipo_Diseno { get; set; }
        public decimal Periodo { get; set; }
        public decimal Valor_EE_Total { get; set; }
        public decimal Id_Parametro { get; set; }

        public double Fecha_Creacion { get; set; }
        public double Hora_Creacion { get; set; }
        public string Usr_Creacion { get; set; }

        public double Fecha_Actualizacion { get; set; }
        public double Hora_Actualizacion { get; set; }
        public string Usr_Actualizacion { get; set; }
    }
}
