using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class Entrada
    {
        public Entrada()
        {
        }

        public Entrada(string numero_Parte, string responsable, string fecha, int cantidad_Ingresada, string descripcion, string proveedor, string numero_Factura, double precio)
        {
            Numero_Parte = numero_Parte;
            Responsable = responsable;
            Fecha = fecha;
            Cantidad_Ingresada = cantidad_Ingresada;
            Descripcion = descripcion;
            Proveedor = proveedor;
            Numero_Factura = numero_Factura;
            Precio = precio;
        }

        public string Numero_Parte { set; get; }
        public string Responsable { set; get; }
        public string Fecha { set; get; }
        public int Cantidad_Ingresada { set; get; }
        public string Descripcion { set; get; }
        public double Precio { set; get; }
        public string Numero_Factura { set; get; }
        public string Proveedor { set; get; }
    }
}