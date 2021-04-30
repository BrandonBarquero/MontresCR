using Montres.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Montres
{
    public partial class Home : System.Web.UI.Page
    {
        ContadoresDAO dao_contador = new ContadoresDAO();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int Contar_Parte()
        {
            int Contador_parte = dao_contador.Contar_Partes();

            return Contador_parte;
        }

        public int Contar_Salidas()
        {
            int Contador_salida = dao_contador.Contar_Salidas();

            return Contador_salida;
        }

        public int Contar_Devoluciones()
        {
            int Contador_devoluciones = dao_contador.Contar_Devoluciones();

            return Contador_devoluciones;
        }

        public int Contar_Minimos()
        {
            int Contador_minimos = dao_contador.Contar_Minimos();

            return Contador_minimos;
        }

        public int Contar_Cotizaciones()
        {
            int Contador_cotizaciones = dao_contador.Contar_Cotizaciones();

            return Contador_cotizaciones;
        }

        public int Contar_Usuarios()
        {
            int Contador_usuarios = dao_contador.Contar_Usuarios();

            return Contador_usuarios;
        }

    }
}