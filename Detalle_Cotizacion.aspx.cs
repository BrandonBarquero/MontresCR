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
    public partial class Detalle_Cotizacion : System.Web.UI.Page
    {
        public auxiliar aux = new auxiliar();
        ParteDAO dao = new ParteDAO();
        Partes par = new Partes();
        Partes_CotizacionDAO dao3 = new Partes_CotizacionDAO();
        CotizacionDAO dao4 = new CotizacionDAO();
        public double cont = 0;
        public double total = 0;
        public string parametro3 = "";
         protected void Page_Load(object sender, EventArgs e)
             {

            string parametro = Request.QueryString["Parte"];
            parametro3 = Request.QueryString["Detallado"];

           



            Actualizar.Visible = false;
            Eliminar.Visible = false;
            Session["allList3"] = new List<string>();

            if (parametro != null)
            {
                ddlPerfiles.Enabled = false;
            }
            


            orden.Text = Session["Sesion1"].ToString();
            Cliente.Text = Session["Sesion2"].ToString();

            if (parametro3 == null)
            {
                //redireccionar
            }



            if (!IsPostBack)
            {
                ddlPerfiles.DataSource = dao.MostrarPartes();
                ddlPerfiles.DataValueField = "numero_Parte";
                ddlPerfiles.DataTextField = "numero_Parte";
                ddlPerfiles.DataBind();
                ddlPerfiles.Items.Insert(0, new ListItem() { Text = "-- SELECCIONE EL NUMERO DE PARTE --", Value = "" });

                if (parametro3 != null)
                {
                    Session["Eliminar"] = parametro3;


                    //    Session["allLis2t"] = new List<Partes>();




                    List<Partes> list = dao3.MostrarCotizacion(parametro3);




                    Session["allList2"] = list;

                    Cotizaciones cot2 = dao4.MostrarCotizacion(parametro3);


                    Session["Sesion1"] = cot2.ID_Cotizacion;
                    Session["Sesion2"] = cot2.Cliente;


                    orden.Text = Session["Sesion1"].ToString();
                    Cliente.Text = Session["Sesion2"].ToString();



                }


                if (parametro != null)
                {
                    Mostrar_Modficar(parametro);
                    ddlPerfiles.SelectedValue = Request.QueryString["Parte"];


                }

               

            }


            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList2"];

            if (list_Partes.Count == 0)
            {

                Cancelar_B.Visible = false;
                Procesar_B.Visible = false;

            }
            if (list_Partes.Count != 0)
            {
                Cancelar_B.Visible = true;
                Procesar_B.Visible = true;
            }

        }

        protected void Procesar(object sender, EventArgs e)
        {
        
           
            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList2"];
            List<string> listError = (List<string>)HttpContext.Current.Session["allList3"];


            Session["allList3"] = new List<string>();
            foreach (Partes entidad in list_Partes)
            {

                ParteDAO dao = new ParteDAO();

                Partes par = dao.Filtrar(entidad.Numero_Parte);

                if (par.Cantidad_Stock < entidad.Cantidad_Stock)
                {

                    listError.Add(entidad.Numero_Parte);
                }


            }

            if (listError.Count != 0)
            {

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>Alert_Error()</script>", false);

                Panel1.Visible = true;
                Session["allList3"] = listError;
             

            }
            if (listError.Count == 0)
            {

                Panel1.Visible = false;
                string var = Session["Eliminar"].ToString();
                dao3.Eliminar(var);
                dao3.insertar(list_Partes, var);
                dao3.actualizar(var);

                  

            

                foreach (Partes entidad in list_Partes)
                {

                    ParteDAO dao = new ParteDAO();

                    Partes par = dao.Filtrar(entidad.Numero_Parte);

                    int total = par.Cantidad_Stock - entidad.Cantidad_Stock;

                    dao.Retiro(total, entidad.Numero_Parte);

                    string Nombre_Encargado = (string)(Session["Nombre"]);

                    string Date = DateTime.Now.ToString("yyyy-MM-dd");

                    UsuarioDAO dao_user = new UsuarioDAO();

                  dao_user.insertarSalida(Cliente.Text, par.Descripcion, entidad.Cantidad_Stock, Nombre_Encargado, Nombre_Encargado, DateTime.Parse(Date), par.Numero_Parte, par.Numero_Factura);



                }



                Mail mail = new Mail();
                mail.Enviar_Cotizacion_Correo(Cliente.Text, orden.Text);



                Procesar_B.Visible = false;
                Cancelar_B.Visible = false;
                Button1.Visible = false;
                Panel3.Visible = true;
              
                ddlPerfiles.Enabled = false;


            }



        }

        protected void Mostrar_Modficar(string Para)
        {
            Button1.Visible = false;
            Actualizar.Visible = true;
            Eliminar.Visible = true;
            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList2"];

            Partes par = list_Partes.Find(x => x.Numero_Parte == Para);

            descripcion.Text = par.Descripcion;
            ubicacion.Text = par.Ubicacion;
            precio.Text = aux.transformar( par.Precio);
            cantidad.Text = par.Cantidad_Stock.ToString();

            orden.Text = Session["Sesion1"].ToString();
            Cliente.Text = Session["Sesion2"].ToString();


            // list_Partes.RemoveAll(x => x.Numero_Parte == Para);
        }
        protected void Eliminar_Parte(object sender, EventArgs e)
        {

            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList2"];
            list_Partes.RemoveAll(x => x.Numero_Parte == ddlPerfiles.SelectedValue);

            Button1.Visible = true;
            Actualizar.Visible = false;
            Eliminar.Visible = false;

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
        protected void Modificar_Parte(object sender, EventArgs e)
        {


            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList2"];
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

            Session["allList2"] = list_Partes;
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
            Session["allList2"] = new List<Partes>();



            Response.Redirect("Historial_Cotizaciones.aspx");

        }

        protected void Agregar_Parte(object sender, EventArgs e)
        {
            if (ddlPerfiles.SelectedValue == "") {
                return;
            }

            Cancelar_B.Visible = true;
            Procesar_B.Visible = true;
            ddlPerfiles.Attributes["Required"] = "false";
            ddlPerfiles.Attributes.Remove("Required");

            List<Partes> questions = (List<Partes>)HttpContext.Current.Session["allList2"];



            string limpio = precio.Text.Replace("₡", "");
            string limpio2 = limpio.Replace(" ", "");


            par.Cantidad_Stock = Int32.Parse(cantidad.Text);
            par.Numero_Parte = ddlPerfiles.SelectedValue;
            par.Descripcion = descripcion.Text;
            par.Ubicacion = ubicacion.Text;
            par.Precio = Int32.Parse(limpio2);


            questions.Add(par);

            Session["allList2"] = questions;

            cantidad.Text = "0";
            descripcion.Text = "";
            cantidad.Text = "";
            ubicacion.Text = "";
            precio.Text = "";
            ddlPerfiles.SelectedValue = "";

        }
    }
}