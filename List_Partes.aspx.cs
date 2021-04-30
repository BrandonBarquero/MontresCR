using Montres.DAO;
using Montres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Montres
{
    public partial class List_Partes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Rol = (string)(Session["Rol"]);

            if (Rol == "3")
            {
                Response.Redirect("Error_403.aspx");
                return;
            }

        }
    }
}