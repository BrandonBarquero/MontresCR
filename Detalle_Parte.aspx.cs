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

    public partial class Detalle_Parte : System.Web.UI.Page
    {

        Partes detalle = new Partes();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            string Rol = (string)(Session["Rol"]);

            if (Rol == "3")
            {
                Panel_Insertar_Alterno.Visible = false;
                Panel_borrar_boton.Visible = false;
             
            }



            string parametro = Request.QueryString["ID"];
            string parametro2 = Request.QueryString["Numero_Alterno"];

            if (parametro != null)
            {
                List<Numero_Alterno> list_alterno = new List<Numero_Alterno>();

                ParteDAO dao = new ParteDAO();


                Numero_AlternoDAO dao2 = new Numero_AlternoDAO();


                list_alterno = dao2.MostrarAlternoFiltrado(parametro);

                if (list_alterno.Count != 0)
                {
                    foreach (Numero_Alterno data in list_alterno)
                    {

                        campo_alterno_div.Controls.Add(new LiteralControl("<input value='" + data.Partes_Numeros + "' type='text' class='form-control' readonly/><br/>"));

                        campo_alterno_div2.Controls.Add(new LiteralControl("<a href='Detalle_Parte.aspx?Numero_Alterno=" + data.Partes_Numeros + "&ID="+parametro+ "' class='btn btn-outline-dark' role='button'>Borrar</a><br/><br/>"));

                      
                    }


                }


                detalle = dao.Filtrar(parametro);
                auxiliar aux = new auxiliar();
                Numero_Parte.Text = detalle.Numero_Parte ;
                Descripcion.Text = detalle.Descripcion;
                Ubicacion.Text = detalle.Ubicacion;
                Precio.Text = aux.transformar(detalle.Precio)+ " + IVA";
                Cantidad_Inicial.Text = detalle.Cantidad_Inicial.ToString();
                Cantidad_Stock.Text = detalle.Cantidad_Stock.ToString();
                Minimo.Text = detalle.Cantidad_Minima.ToString();
                Fecha_Entrada.Text = detalle.Fecha_Entrada.ToString();
                Numero_Factura.Text = detalle.Numero_Factura;
                Proveedor.Text = detalle.Proveedor;
            } 
                if(parametro2 != null)
                  {

                Borrar_Alterno(parametro, parametro2);
              
                   }
   
            
        }

        public void Insertar_Alterno(Object sender, EventArgs e)
        {

            string parametro = Request.QueryString["ID"];
            string numero_alterno = Numero_Alternativo.Text;
            Numero_AlternoDAO dao = new Numero_AlternoDAO();
            dao.insertar(parametro, numero_alterno);

            Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void Borrar_Alterno(string parametro, string parametro2)
        {

            Numero_AlternoDAO dao = new Numero_AlternoDAO();
            dao.Eliminar(parametro, parametro2);

            string url = Request.Url.ToString();

                url = url.Split(new Char[] { '?' })[0];

            Response.Redirect(url+"?ID="+parametro);


        }

    }
}