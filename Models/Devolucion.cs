using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class Devolucion
    {
        public Devolucion(string numero_Parte, string responsable, string fecha, int cantidad_Ingresada, string descripcion)
        {
            Numero_Parte = numero_Parte;
            Responsable = responsable;
            Fecha = fecha;
            Cantidad_Ingresada = cantidad_Ingresada;
            Descripcion = descripcion;
        }

        public string Numero_Parte { set; get; }
        public string Responsable { set; get; }
        public string Fecha { set; get; }
        public int Cantidad_Ingresada { set; get; }
        public string Descripcion { set; get; }
    }


}