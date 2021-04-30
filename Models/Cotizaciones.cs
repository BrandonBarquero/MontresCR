using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class Cotizaciones
    {
        public string ID_Cotizacion { set; get; }
        public string Fecha { set; get; }
        public string Cliente { set; get; }
     
        public string Estado { set; get; }
        public double Total { set; get; }

        public Cotizaciones(string iD_Cotizacion, string fecha, string cliente, string estado, double total)
        {
            ID_Cotizacion = iD_Cotizacion;
            Fecha = fecha;
            Cliente = cliente;
           
            Estado = estado;
            Total = total;
        }

        public Cotizaciones(string fecha, string cliente, double total)
        {
            Fecha = fecha;
            Cliente = cliente;
          
            Total = total;
        }

        public Cotizaciones()
        {
        }
    }
}