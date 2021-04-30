using Montres.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Montres
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioDAO dao = new UsuarioDAO();
            string Rol = (string)(Session["Rol"]);
            string Nombre = (string)(Session["Nombre"]);


            if (Rol == "0" || Rol == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;

            Panel1.Enabled = false;
            Panel2.Enabled = false;
            Panel3.Enabled = false;

            if (Rol == "1")
            {


                Panel1.Visible = true;
                Panel1.Enabled = true;
            }

            if (Rol == "2")
            {
                Panel2.Visible = true;
                Panel2.Enabled = true;

            }
            if (Rol == "3")
            {
                Panel3.Visible = true;
                Panel3.Enabled = true;
            }

        }

        public void Logout(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("Login.aspx");
        }

    }
}