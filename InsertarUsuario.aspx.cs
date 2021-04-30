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
    public partial class InsertarUsuario : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string Rol = (string)(Session["Rol"]);

            if (Rol == "2" || Rol == "3")
            {
                Response.Redirect("Error_403.aspx");
                return;
            }
        }

        public void txtChanged(object sender, EventArgs e)
        {
            
            if (cedula.Text == "") {
                cedula.Attributes["style"] = "border: white 5px solid";
                span_E.Visible = false;
                cedula.CssClass = "form-control";
                cedula.Attributes["class"] = "form-control";
                cedula.Style.Remove("border");
                //salir de metodo
                return;

            }
            UsuarioDAO dao = new UsuarioDAO();
            int resValidacion = dao.ValidarUser(cedula.Text);
            int val = 0;
            if (resValidacion == 1)
            {

                Panel_Error_Cedula.Visible = true;
                _guardar.Enabled = false;
                _guardar.CssClass = "btn btn-danger";

             
                cedula.Attributes["style"] = "border-bottom: red  solid;";

                span_error.Attributes["style"] = "color: #E86B6B";
                
                span_E.Visible = true;
                span_error.Attributes["class"] = "zmdi zmdi-alert-circle";

                val = 1;
            }
           else if (resValidacion == 0)
            {
                Panel_Error_Cedula.Visible = false;
                _guardar.Enabled = true;
                _guardar.CssClass = "btn btn-outline-dark";
              
                cedula.Attributes["style"] = "border-bottom: green  solid;";
              

                span_error.Attributes["class"] = "";
                span_error.Attributes["class"] = "zmdi zmdi-check-circle-u";
                span_error.Attributes["style"] = "color: green";
                
            }
            
        }

        public void Insertar_User( object sender, EventArgs e ) {
            if (Page.IsValid)
            {


                UsuarioDAO dao = new UsuarioDAO();



                if (Contrasena.Text == Contrasena2.Text)
                {
                    Panel_Error_Contrasena.Visible = false;

                }
                else if (Contrasena.Text != Contrasena2.Text)
                {
                    Panel_Error_Contrasena.Visible = true;

                }

                if (Contrasena.Text == Contrasena2.Text)
                {
                    int res = dao.insertar(new Usuario(
                   cedula.Text,
                   nombre.Text,
                   correo.Text,
                   telefono.Text,
                   Int32.Parse(rol.SelectedValue),
                   "Activo",
                   Contrasena.Text

                   ));

                    if (res == 1)
                    {
                        cedula.Text = "";
                        nombre.Text = "";
                        telefono.Text = "";
                        correo.Text = "";
                        Contrasena.Text = "";
                        Contrasena2.Text = "";

                        cedula.Attributes["style"] = "border: white 5px solid";
                        span_E.Visible = false;
                        cedula.CssClass = "form-control";
                        cedula.Attributes["class"] = "form-control";
                        cedula.Style.Remove("border");
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