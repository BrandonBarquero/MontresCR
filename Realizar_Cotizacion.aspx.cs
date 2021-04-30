using Montres.DAO;
using Montres.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Montres
{
    public partial class Realizar_Cotizacion : System.Web.UI.Page
    {
        ParteDAO dao = new ParteDAO();
        Partes par = new Partes();
        public auxiliar aux = new auxiliar();

        public double cont = 0;
        public double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList"];
            if (list_Partes.Count == 0)
            {

                Cancelar_B.Visible = false;
                Finalizar_B.Visible = false;

            }
            if (list_Partes.Count != 0)
            {
                Cancelar_B.Visible = true;
                Finalizar_B.Visible = true;
            }

            Actualizar.Visible = false;
            Eliminar.Visible = false;
            Cancelar_Buton.Visible = false;
            string parametro = Request.QueryString["Parte"];

            


            if (parametro != null)
            {
                ddlPerfiles.Enabled = false;
            }

            /////////////////
            CotizacionDAO daocotizacion = new CotizacionDAO();
            int max = daocotizacion.Maximo();
            Session["Var2"] = aux.GetBadgeString(max+1);


            if (!IsPostBack)
            {
             

                if (parametro != null)
                {
                    Mostrar_Modficar(parametro);
                    ddlPerfiles.SelectedValue = Request.QueryString["Parte"];


                }



                Cliente.Text = Session["var1"].ToString();
                orden.Text = Session["Var2"].ToString();





                ddlPerfiles.DataSource = dao.MostrarPartes();
                ddlPerfiles.DataValueField = "numero_Parte";
                ddlPerfiles.DataTextField = "numero_Parte";
                ddlPerfiles.DataBind();
                ddlPerfiles.Items.Insert(0, new ListItem() { Text = "-- SELECCIONE EL NUMERO DE PARTE --", Value = "" });






            }





        }
        public void txtChanged(object sender, EventArgs e)
        {

            Session["Var2"] = Cliente.Text;
        }
      

        protected void Mostrar_Modficar(string Para)
        {
            Button1.Visible = false;
            Actualizar.Visible = true;
            Eliminar.Visible = true;
            Cancelar_Buton.Visible = true;

            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList"];

            Partes par = list_Partes.Find(x => x.Numero_Parte == Para);

            descripcion.Text = par.Descripcion;
            ubicacion.Text = par.Ubicacion;
            precio.Text = aux.transformar(par.Precio);
            cantidad.Text = par.Cantidad_Stock.ToString();




            // list_Partes.RemoveAll(x => x.Numero_Parte == Para);
        }

        protected void Redirect(object sender, EventArgs e)
        {
            Response.Redirect("Realizar_Cotizacion.aspx");
        }


            protected void Eliminar_Parte(object sender, EventArgs e)
        {

            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList"];
            list_Partes.RemoveAll(x => x.Numero_Parte == ddlPerfiles.SelectedValue);

            Button1.Visible = true;
            Actualizar.Visible = false;
            Eliminar.Visible = false;
            Cancelar_Buton.Visible = false;

            ddlPerfiles.Enabled = true;

            descripcion.Enabled = true;
            cantidad.Enabled = true;
            ubicacion.Enabled = true;
            precio.Enabled = true;

            cantidad.Text = "0";
            descripcion.Text = "";
            cantidad.Text = "";
            ubicacion.Text = "";
            precio.Text = "";
            ddlPerfiles.SelectedValue = "";

            string url = Request.Url.ToString();



            if (url.Contains("?"))
            {



                url = url.Split(new Char[] { '?' })[0];



            }

            Response.Redirect(url);

        }
        protected void Finalizar(object sender, EventArgs e)
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd");

            CotizacionDAO dao = new CotizacionDAO();
            Partes_CotizacionDAO dao2 = new Partes_CotizacionDAO();


            List<Partes> listpartes = (List<Partes>)HttpContext.Current.Session["allList"];

            double total_Partes = 0;

            foreach (Partes par in listpartes)
            {

                total_Partes = (par.Precio * par.Cantidad_Stock) + total_Partes;
            }

            Cotizaciones cot = new Cotizaciones(Date, Cliente.Text, total_Partes);
            string res = dao.insertar(cot).ToString();
            dao2.insertar(listpartes, res);


            Session["allList"] = new List<Partes>();
            Session["total"] = "0";
            Session["var1"] = "";
            Session["Var2"] = "";
            Session["cont"] = "0";
            string url = Request.Url.ToString();
            if (url.Contains("?"))
            {



                url = url.Split(new Char[] { '?' })[0];



            }

            Response.Redirect(url);


        }
        protected void Modificar_Parte(object sender, EventArgs e)
        {


            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList"];
            list_Partes.RemoveAll(x => x.Numero_Parte == ddlPerfiles.SelectedValue);


            string limpio = precio.Text.Replace("₡", "");
            string limpio2 = limpio.Replace(" ", "");




            Partes model = new Partes();
            model.Cantidad_Stock = Int32.Parse(cantidad.Text);
            model.Numero_Parte = ddlPerfiles.SelectedValue;
            model.Descripcion = descripcion.Text;
            model.Ubicacion = ubicacion.Text;
            model.Precio = Int32.Parse(limpio2);




            list_Partes.Add(model);

            Session["allList"] = list_Partes;
            ddlPerfiles.Enabled = false;

            string url = Request.Url.ToString();
            if (url.Contains("?"))
            {



                url = url.Split(new Char[] { '?' })[0];



            }

            Response.Redirect(url);


        }
        protected void ddlPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {

            string go = ddlPerfiles.SelectedValue;
            par = dao.Filtrar(go);
            descripcion.Text = par.Descripcion;
            ubicacion.Text = par.Ubicacion;
            precio.Text = aux.transformar(par.Precio);
            cantidad.Text = "0";






        }

        protected void Cancelar(object sender, EventArgs e)
        {
            Session["allList"] = new List<Partes>();
            Session["total"] = "0";
            Session["var1"] = "";
            Session["Var2"] = "";
            Session["cont"] = "0";
            string url = Request.Url.ToString();
            if (url.Contains("?"))
            {



                url = url.Split(new Char[] { '?' })[0];



            }

            Response.Redirect(url);

        }

        protected void Agregar_Parte(object sender, EventArgs e)
        {

            Cancelar_B.Visible = true;
            Finalizar_B.Visible = true;


            List<Partes> questions = (List<Partes>)HttpContext.Current.Session["allList"];


            string limpio = precio.Text.Replace("₡", "");
            string limpio2 = limpio.Replace(" ", "");


            par.Cantidad_Stock = Int32.Parse(cantidad.Text);
            par.Numero_Parte = ddlPerfiles.SelectedValue;
            par.Descripcion = descripcion.Text;
            par.Ubicacion = ubicacion.Text;
            par.Precio = Int32.Parse(limpio2);


            Session["var1"] = Cliente.Text;
            Session["Var2"] = orden.Text;






            questions.Add(par);

            Session["allList"] = questions;

            cantidad.Text = "0";
            descripcion.Text = "";
            cantidad.Text = "";
            ubicacion.Text = "";
            precio.Text = "";
            ddlPerfiles.SelectedValue = "";

        }



    }
}