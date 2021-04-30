using Montres.DAO;
using Montres.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montres.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult listSalidas()
        {
            SalidaDAO dao = new SalidaDAO();
            List<Salida> salidas = new List<Salida>();
            salidas = dao.MostrarSalidas();

            return Json(salidas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult listEntradas()
        {
            EntradaDAO dao = new EntradaDAO();
            List<Entrada> entradas = new List<Entrada>();
            entradas = dao.MostrarEntradas();

            return Json(entradas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult listDevolucion()
        {
            DevolucionDAO dao = new DevolucionDAO();
            List<Devolucion> devoluciones = new List<Devolucion>();
            devoluciones = dao.MostrarDevolucion();

            return Json(devoluciones, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult listNumeroAlterno()
        {
            Numero_AlternoDAO dao = new Numero_AlternoDAO();
            List<Numero_Alterno> alternos = new List<Numero_Alterno>();
            alternos = dao.MostrarPartesAlternativo();

            return Json(alternos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listPartes()
        {
            ParteDAO dao = new ParteDAO();
            List<Partes> alternos = new List<Partes>();
            alternos = dao.MostrarPartes();

            return Json(alternos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listMinimos()
        {
            Numero_AlternoDAO dao = new Numero_AlternoDAO();
            List<Partes> alternos = new List<Partes>();
            alternos = dao.listaMinimos2();

            return Json(alternos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listPartesVacias()
        {
            Numero_AlternoDAO dao = new Numero_AlternoDAO();
            List<Partes> alternos = new List<Partes>();
            alternos = dao.listaMinimosVacio();

            return Json(alternos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listUsuarios()
        {
            UsuarioDAO dao = new UsuarioDAO();
            List<Usuario> alternos = new List<Usuario>();
            alternos = dao.MostrarUsuarios();

            return Json(alternos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListaCotizacionesAPROBADAS()
        {
            CotizacionDAO dao = new CotizacionDAO();
            List<Cotizaciones> alternos = new List<Cotizaciones>();
            alternos = dao.MostrarCotizacionesAceptadas();

            return Json(alternos, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ListaCotizaciones()
        {
            CotizacionDAO dao = new CotizacionDAO();
            List<Cotizaciones> alternos = new List<Cotizaciones>();
            alternos = dao.MostrarCotizaciones();

            return Json(alternos, JsonRequestBehavior.AllowGet);
        }

    }
}