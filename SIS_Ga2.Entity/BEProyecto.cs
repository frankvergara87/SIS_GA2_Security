using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS_Ga2.Entity
{
  public  class BEProyecto
    {
             public string NumProyecto { get; set; }
        public string Proyecto { get; set; }
        public double Fecha_Proyecto { get; set; }
        public DateTime Fecha_Proyecto_Date { get; set; }

        public double Fecha_Contrato { get; set; }
        public DateTime Fecha_Contrato_Date { get; set; }

        public string Ingeniero { get; set; }
   
        public int id_Usuario { get; set; }
        public bool Estado { get; set; }
        public string Aplicacion { get; set; }   
        public double FechaCreacion { get; set; }
        public double HoraCreacion { get; set; }
        public string UsrCreacion { get; set; }
        public double FechaActualizacion { get; set; }
        public double HoraActualizacion { get; set; }
        public string UsrActualizacion { get; set; }


        public int Id_Proyecto { get; set; }
        public string Num_Proyecto { get; set; }  //Por Regularizar
       
        public string Dni { get; set; }
        public string Cargo { get; set; }
        public string Num_Diseno { get; set; }
        public string Tipo_Diseno { get; set; }
        public string Tramo { get; set; }
        public string Ubigeo { get; set; }




    }


}
