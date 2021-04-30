using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class Partes_Cotizacion
    {
        public int Cantidad { set; get; }
        public string Descripcion { set; get; }
        public string Numero_Parte { set; get; }
        public string Ubicacion { set; get; }
        public double Precio { set; get; }

        public Partes_Cotizacion(int cantidad, string descripcion, string numero_Parte, string ubicacion, double precio)
        {
            Cantidad = cantidad;
            Descripcion = descripcion;
            Numero_Parte = numero_Parte;
            Ubicacion = ubicacion;
            Precio = precio;
        }
    }
}