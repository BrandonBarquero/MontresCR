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
    public partial class Salida_Parte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Rol = (string)(Session["Rol"]);

            if (Rol == "3")
            {
                Response.Redirect("Error_403.aspx");
                return;
            }

            string parametro = Request.QueryString["ID"];

            Partes detalle_parte = new Partes();

            ParteDAO dao = new ParteDAO();

            detalle_parte = dao.Filtrar(parametro);

            numero_parte.Text = detalle_parte.Numero_Parte;
            numero_factura.Text = detalle_parte.Numero_Factura;
            descripcion.Text = detalle_parte.Descripcion;
            stock.Text = detalle_parte.Cantidad_Stock.ToString();

      
        }

        public void Retirar_Parte(object sender, EventArgs e)
        {

            UsuarioDAO dao_user = new UsuarioDAO();
            ParteDAO dao_parte = new ParteDAO();

            if (Int32.Parse(cantidad_retirar.Text) <= Int32.Parse(stock.Text))
            {

                Panel_Error.Visible = false;

                int cantidad_salida = Int32.Parse(stock.Text) - Int32.Parse(cantidad_retirar.Text);

                dao_user.insertarSalida(cliente.Text, descripcion.Text, Int32.Parse(cantidad_retirar.Text), encargado.Text, despachador.Text, DateTime.Parse(fecha_salida.Text), numero_parte.Text, numero_factura.Text);

                int res = dao_parte.Retirar_Parte(cantidad_salida, numero_parte.Text);

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
            else {

                Panel_Error.Visible = true;
            }

 

        }

  

        
    }
}