using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
     
    public class BETipoVehiculos
    {
        public int Id_Tipo_Vehiculo { get; set; }

        public string Tipo_Vehiculo { get; set; }
        public int Estado { get; set; }
        public double FechaCreacion { get; set; }
        public double HoraCreacion { get; set; }
        public string UsrCreacion { get; set; }
        public double FechaActualizacion { get; set; }
        public double HoraActualizacion { get; set; }
        public string UsrActualizacion { get; set; }
    }
}
