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
    public partial class Cambio_Contrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Rol = (string)(Session["Rol"]);

            if (Rol == "2" || Rol == "3")
            {
                Response.Redirect("Error_403.aspx");
                return;
            }

            string parametro = Request.QueryString["ID"];

            UsuarioDAO dao = new UsuarioDAO();

            Usuario detalle_usuario = new Usuario();

            detalle_usuario = dao.listaUsuarios(parametro);

                nombre.Text = detalle_usuario.Nombre;
                cedula.Text = detalle_usuario.Cedula;

        }

        public void Modificar_Contra(object sender, EventArgs e)
        {
            string id = Request.QueryString["ID"];

            if (Page.IsValid)
            {


                UsuarioDAO dao = new UsuarioDAO();



                if (Contrasena1.Text == contrasena.Text)
                {
                    Panel_Error_Contrasena.Visible = false;

                }
                else if (Contrasena1.Text != contrasena.Text)
                {
                    Panel_Error_Contrasena.Visible = true;

                }

                if (Contrasena1.Text == contrasena.Text)
                {

                    int res = dao.Contrasena(
                    id,
                    contrasena.Text
                   );

                    if (res == 1)
                    {
                        Contrasena1.Text = "";
                        contrasena.Text = "";

                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_True()</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_False()</script>", false);

                    }

                }






            }

        }
    }
}