using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
    public class BETasaCrecimiento
    {
        public int IdTasaCrecimiento { get; set; }
        public string TasaCrecimiento { get; set; }
        public bool Estado { get; set; }
        public double FechaCreacion { get; set; }
        public double HoraCreacion { get; set; }
        public string UsrCreacion { get; set; }
        public double FechaActualizacion { get; set; }
        public double HoraActualizacion { get; set; }
        public string UsrActualizacion { get; set; }
        public int Id_Parametro { get; set; }
        public int Id_Tipo_Vehiculo { get; set; }

        public int NroAnio { get; set; }
        public decimal Valor{ get; set; }
        public string Vehiculo { get; set; }

        // TASA DE CRECIMIENTO POR TIEMPO y VEHICULO
        public int Id_Tasa_Crec_X_Tiempo { get; set; }
        public int Id_Tasa_Crec_X_Vehiculo { get; set; }
        public int Id_Tasa_Crec_Constante { get; set; }
        public int Id_Diseno { get; set; }
        


    }
}
