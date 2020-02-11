using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
 public   class BEMatrizTasaCrecimiento
    {

        public int Id_Parametro { get; set; }
        public int Id_Tasa_Crecimiento2 { get; set; }
        public int Id_Tasa_Crecimiento1 { get; set; }
        public int Id_Diseno { get; set; }
        public int Nro_Anio { get; set; }
        public int Id_Vehiculos { get; set; }
        public decimal Valor { get; set; }
        public string Vehiculo { get; set; }

        public int Id_Tipo_Vehiculo { get; set; }
        public string Tipo_Vehiculo { get; set; }


    }
}
