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
    public partial class InsertarParte : System.Web.UI.Page
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

        public void txtChanged(object sender, EventArgs e)
        {

            if (numero_parte.Text == "")
            {
                numero_parte.Attributes["style"] = "border: white 5px solid";
                span_E.Visible = false;
                numero_parte.CssClass = "form-control";
                numero_parte.Attributes["class"] = "form-control";
                numero_parte.Style.Remove("border");
                //salir de metodo
                return;

            }
            ParteDAO dao = new ParteDAO();
            int resValidacion = dao.Validarparte(numero_parte.Text);
            int val = 0;
            if (resValidacion == 1)
            {

                Panel_Error_Parte.Visible = true;
                _guardar.Enabled = false;
                _guardar.CssClass = "btn btn-danger";


                numero_parte.Attributes["style"] = "border-bottom: red  solid;";

                span_error.Attributes["style"] = "color: #E86B6B";

                span_E.Visible = true;
                span_error.Attributes["class"] = "zmdi zmdi-alert-circle";

                val = 1;
            }
            else if (resValidacion == 0)
            {
                Panel_Error_Parte.Visible = false;
                _guardar.Enabled = true;
                _guardar.CssClass = "btn btn-outline-dark";

                numero_parte.Attributes["style"] = "border-bottom: green  solid;";


                span_error.Attributes["class"] = "";
                span_error.Attributes["class"] = "zmdi zmdi-check-circle-u";
                span_error.Attributes["style"] = "color: green";

            }

        }

        public void Insertar_User(object sender, EventArgs e)
        {
            string Nombre_Usuario = (string)(Session["Nombre"]);

            if (Page.IsValid)
            {


                ParteDAO dao = new ParteDAO();
                EntradaDAO dao2 = new EntradaDAO();


                   int res = dao.insertar(new Partes(
                   numero_parte.Text,
                   descripcion.Text,
                   ubicacion.Text,
                   Int32.Parse(cantidad.Text),
                   Int32.Parse(cantidad.Text),
                   Int32.Parse(minimo.Text),
                   Double.Parse(precio.Text),
                   Proveedor.Text,
                   Numero_Factura.Text,
                   DateTime.Parse(fecha.Text).ToString("yyyy/MM/dd")

                   ));


                dao2.insertarEntrada(numero_parte.Text, Nombre_Usuario, DateTime.Parse(fecha.Text), Int32.Parse(cantidad.Text), descripcion.Text, Double.Parse(precio.Text), Numero_Factura.Text, Proveedor.Text);

                    if (res == 1)
                    {
                    numero_parte.Text = "";
                    descripcion.Text = "";
                    ubicacion.Text = "";
                    cantidad.Text = "";
                    minimo.Text = "";
                    precio.Text = "";
                    fecha.Text = "";
                    Numero_Factura.Text = Numero_Factura.Text;
                    Proveedor.Text = Proveedor.Text;
                    span_E.Visible = false;

                    numero_parte.Attributes["style"] = "border: white 5px solid";
                    Panel_Error_Parte.Visible = false;
                    numero_parte.CssClass = "form-control";
                    numero_parte.Attributes["class"] = "form-control";
                    numero_parte.Style.Remove("border");
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_True()</script>", false);
                    }
                    else
                    {
                    Panel_Error_Parte.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_False()</script>", false);

                    }

            }


        }
    }
}