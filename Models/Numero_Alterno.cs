using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class Numero_Alterno
    {
        public Numero_Alterno(string numero_Parte, string partes_Numeros)
        {
            Numero_Parte = numero_Parte;
            Partes_Numeros = partes_Numeros;
        }

        public string Numero_Parte { set; get; }
        public string Partes_Numeros { set; get; }
    }
}