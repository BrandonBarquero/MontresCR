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
    public partial class Devolucion_Parte : System.Web.UI.Page
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
            string parametro2 = Request.QueryString["Cantidad"];
            string Nombre = (string)(Session["Nombre"]);

            ParteDAO dao = new ParteDAO();



            if (!IsPostBack)
            {
                numero_parte.Text = parametro;
                cantidad_salida.Text = parametro2;
                responsable.Text = Nombre;
                
            }

        }

        public void Realizar_Devolucion(object sender, EventArgs e)
        {

            if (Int32.Parse(cantidad_devuelta.Text) <= Int32.Parse(cantidad_salida.Text))
            {

                Panel_Error.Visible = false;


                DevolucionDAO dao_devolucion = new DevolucionDAO();

                Partes parte = new Partes();
                ParteDAO dao_parte = new ParteDAO();
                SalidaDAO dao_salida = new SalidaDAO();

                string Nombre = (string)(Session["Nombre"]);
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                string ID_Salida = Request.QueryString["ID_Salida"];


                dao_devolucion.insertarDevolucion(numero_parte.Text, Nombre, DateTime.Parse(Date),Int32.Parse(cantidad_devuelta.Text), motivo.Text);

               parte = dao_parte.Filtrar(numero_parte.Text);

               int cantidad_stock_parte = parte.Cantidad_Stock;

                int nueva_cantidad_stock = Int32.Parse(cantidad_devuelta.Text) + cantidad_stock_parte;


                int res = dao_parte.UpdCantidadStock(nueva_cantidad_stock, numero_parte.Text);

                int nueva_cantidad_salida = Int32.Parse(cantidad_salida.Text) - Int32.Parse(cantidad_devuelta.Text);

                dao_salida.actualizar_salida(Int32.Parse(ID_Salida), nueva_cantidad_salida);

                if (res == 1)
                {
             
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_True()</script>", false);

                    motivo.Text = "";
                    fecha.Text = "";
                    cantidad_devuelta.Text = "";
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