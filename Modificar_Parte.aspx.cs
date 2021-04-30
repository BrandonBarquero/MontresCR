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
    public partial class Modificar_Parte : System.Web.UI.Page
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

            inicial.Text = detalle_parte.Cantidad_Inicial.ToString();
            stock.Text = detalle_parte.Cantidad_Stock.ToString();

            if (!IsPostBack)
            {

                numero_parte.Text = detalle_parte.Numero_Parte;
                descripcion.Text = detalle_parte.Descripcion;
                ubicacion.Text = detalle_parte.Ubicacion;
                precio.Text = detalle_parte.Precio.ToString();
                numero_factura.Text = detalle_parte.Numero_Factura;
                proveedor.Text = detalle_parte.Proveedor;
                minimo.Text = detalle_parte.Cantidad_Minima.ToString();
                
            }
            

        }

        public void Modificar_datos_parte(object sender, EventArgs e)
        {

            string parametro = Request.QueryString["ID"];

            string Nombre_Usuario = (string)(Session["Nombre"]);

            string Date = DateTime.Now.ToString("yyyy-MM-dd");

            EntradaDAO dao2 = new EntradaDAO();

                ParteDAO dao = new ParteDAO();

                int res = dao.actualizar(
                        descripcion.Text,
                        ubicacion.Text,
                        Int32.Parse(inicial.Text),
                        Int32.Parse(stock.Text),
                        Int32.Parse(minimo.Text),
                        Double.Parse(precio.Text),
                        proveedor.Text,
                        numero_factura.Text,
                        numero_parte.Text
                );



                int cantidad_stock_nueva = Int32.Parse(stock.Text) + Int32.Parse(cantidad_nueva.Text);

                int cantidad_inicial_nueva = Int32.Parse(inicial.Text) + Int32.Parse(cantidad_nueva.Text);

                dao.UpdCantidadStock(cantidad_stock_nueva, parametro);

                dao.UpdCantidadInicial(cantidad_inicial_nueva, parametro);

                dao2.insertarEntrada(numero_parte.Text, Nombre_Usuario, DateTime.Parse(Date), Int32.Parse(cantidad_nueva.Text), descripcion.Text, Double.Parse(precio.Text), numero_factura.Text, proveedor.Text);


                if (res == 1)
                {

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_True()</script>", false);
                    cantidad_nueva.Text = "";

                    stock.Text = cantidad_stock_nueva.ToString();

                   // Response.Redirect("List_Partes.aspx");
            }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_False()</script>", false);

                }

            }

        }


    }
