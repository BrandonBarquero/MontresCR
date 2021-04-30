using Montres.DAO;
using Montres.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Montres
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["allList"] = new List<Partes>();
            Session["allList3"] = new List<string>();
            Session["allList2"] = new List<Partes>();
            Session["total"] = "0";
            Session["var1"] = "";
            Session["Var2"] = "";

            Session["Eliminar"] = "";


            Session["Sesion1"] = "";
            Session["Sesion2"] = "";
            Session["cont"] = "0";

        }

        protected void click_Button(object sender, EventArgs e)

        {
            string Rol = (string)(Session["Rol"]);

            if (Rol != null)
            {
                Response.Redirect("Home.aspx");
                return;
            }

            UsuarioDAO dao_user = new UsuarioDAO();
            string nombre_usuario = dao_user.Nombre(user.Text);

            string nombre = (string)(Session["Nombre"]);

            Session["Nombre"] = nombre_usuario;



            LoginDAO dao = new LoginDAO();
            int res = dao.consultamenu(new Usuario1(user.Text, contra.Text));

            if (res == 1)
            {
                Session["Rol"] = "1";

                Response.Redirect("Home.aspx");
            }
            if (res == 2)
            {
                Session["Rol"] = "2";

                Response.Redirect("Home.aspx");
            }
            if (res == 3)
            {
                Session["Rol"] = "3";

                Response.Redirect("Home.aspx");
            }
            if (res == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_False()</script>", false);
            }




        }

   



    }
}