using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class auxiliar
    {

        public string transformar(double value)
        {


            System.Globalization.NumberFormatInfo formato = new System.Globalization.CultureInfo("es-AR").NumberFormat;

            formato.CurrencyGroupSeparator = " ";
            formato.NumberDecimalSeparator = ",";
            formato.CurrencySymbol = "₡";

            return value.ToString("C", formato).Split(',')[0];

        }

        public  string GetBadgeString(int badgeNum)
        {
            return string.Format("{0:000000000}", badgeNum);
            // alternate
            // return string.Format("{0:d6}", badgeNum);
        }

    }
}