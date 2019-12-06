using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BEPropFactorDistribucion
    {

        public int Id_Prop_Factor_Distrib { get; set; }
        public int Id_Factor_Distribucion { get; set; }
        public int Numero_Calzada { get; set; }
        public int Numero_Sentido { get; set; }
        public int Numero_Carril_x_Sentido { get; set; }
        public decimal Valor_Distrib_Calculado { get; set; }
        public decimal Valor_Distrib_Ingresado { get; set; }

        public double Fecha_Creacion { get; set; }
        public double Hora_Creacion { get; set; }
        public string Usr_Creacion { get; set; }
      
    }
}
