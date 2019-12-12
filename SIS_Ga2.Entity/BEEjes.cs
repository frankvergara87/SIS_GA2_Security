using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BEEjes
    {
        public int Id_Eje { get; set; }
        public int Id_Vehiculo { get; set; }
        public string Valor { get; set; }
        public decimal Peso { get; set; }
        public int cantidadEjes { get; set; }
        public int Total_Ejes { get; set; }        
        public double FechaCreacion { get; set; }
        public double HoraCreacion { get; set; }
        public string UsrCreacion { get; set; }
        public double FechaActualizacion { get; set; }
        public double HoraActualizacion { get; set; }
        public string UsrActualizacion { get; set; }
    }
}
