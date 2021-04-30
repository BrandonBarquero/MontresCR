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
    public partial class Retirar_Parte : System.Web.UI.Page
    {
        ParteDAO daoparte = new ParteDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            string Rol = (string)(Session["Rol"]);

            if (Rol == "3")
            {
                Response.Redirect("Error_403.aspx");
                return;
            }

            if (!IsPostBack) {
                ddlPerfiles.DataSource = daoparte.MostrarPartes();
                ddlPerfiles.DataValueField = "numero_Parte";
                ddlPerfiles.DataTextField = "numero_Parte";
                ddlPerfiles.DataBind();
                ddlPerfiles.Items.Insert(0, new ListItem() { Text = "-- SELECCIONE EL NUMERO DE PARTE --", Value = "" });
            }
            

        }

        public void consultar_detalle_Parte(object sender, EventArgs e)
        {

            Partes detalle_parte = new Partes();

            ParteDAO dao = new ParteDAO();

           detalle_parte = dao.Filtrar(ddlPerfiles.SelectedValue);

            ddlPerfiles.SelectedValue = detalle_parte.Numero_Parte;
            numero_factura.Text = detalle_parte.Numero_Factura;
            descripcion.Text = detalle_parte.Descripcion;
            stock.Text = detalle_parte.Cantidad_Stock.ToString();

        }

        public void Retirar_Parte_Automatico(object sender, EventArgs e)
        {

            UsuarioDAO dao_user = new UsuarioDAO();
            ParteDAO dao_parte = new ParteDAO();

            if (Int32.Parse(cantidad_retirar.Text) <= Int32.Parse(stock.Text))
            {

                Panel_Error.Visible = false;

                int cantidad_salida = Int32.Parse(stock.Text) - Int32.Parse(cantidad_retirar.Text);

                dao_user.insertarSalida(cliente.Text, descripcion.Text, Int32.Parse(cantidad_retirar.Text), encargado.Text, despachador.Text, DateTime.Parse(fecha_salida.Text), ddlPerfiles.SelectedValue, numero_factura.Text);

                int res = dao_parte.Retirar_Parte(cantidad_salida, ddlPerfiles.SelectedValue);

                if (res == 1)
                {

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_True()</script>", false);
                    cliente.Text = "";
                    cantidad_retirar.Text = "";
                    encargado.Text = "";
                    despachador.Text = "";
                    fecha_salida.Text = "";

                    stock.Text = cantidad_salida.ToString();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_False()</script>", false);

                }

            }
            else
            {

                Panel_Error.Visible = true;
            }



        }




    }
}