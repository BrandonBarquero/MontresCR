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
    public partial class Modificar_Usuario : System.Web.UI.Page
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


            if (!IsPostBack)
            {
                nombre.Text = detalle_usuario.Nombre;
                cedula.Text = detalle_usuario.Cedula;
                correo.Text = detalle_usuario.Correo;
                telefono.Text = detalle_usuario.Telefono;
                rol.SelectedValue = detalle_usuario.Rol.ToString();
                estado.SelectedValue = detalle_usuario.Estado.ToString();
            }

     

        }

        public void Modificar_User(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                UsuarioDAO dao = new UsuarioDAO();

                   int res = dao.actualizar(
                           nombre.Text,
                           correo.Text,
                           telefono.Text,
                           Int32.Parse(rol.SelectedValue),
                           estado.SelectedValue,
                           cedula.Text          
                   );

                    if (res == 1)
                    {
                        
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
