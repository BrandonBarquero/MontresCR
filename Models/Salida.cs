using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class Salida
    {
        public Salida(int ID_salida, string cliente, string descripcion, int cantidad, string encargado, string despacho, string fecha, string numero_Parte)
        {
            ID_Salida = ID_salida;
            Cliente = cliente;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Encargado = encargado;
            Despacho = despacho;
            Fecha = fecha;
            Numero_Parte = numero_Parte;
        }

        public string Cliente { set; get; }
        public string Descripcion { set; get; }
        public int Cantidad { set; get; }
        public string Encargado { set; get; }
        public string Despacho { set; get; }
        public string Numero_Factura { set; get; }
        public string Fecha { set; get; }
        public string Numero_Parte { set; get; }

        public int ID_Salida { set; get; }
      
    }
}