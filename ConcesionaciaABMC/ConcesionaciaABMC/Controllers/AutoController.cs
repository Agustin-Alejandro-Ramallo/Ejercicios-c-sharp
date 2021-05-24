using ConcesionaciaABMC.AccesoDatos;
using ConcesionaciaABMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConcesionaciaABMC.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        public ActionResult Principal()
        {
            GestorBD gestor = new GestorBD();
            List<DTOAuto> lista = gestor.ListadoAutos();

           
            return View(lista);
        }

        public ActionResult Alta()
        {
            GestorBD gestor = new GestorBD();
            VMAuto vm = new VMAuto();

            vm.TipoMarcas = gestor.ListadoMarcas();
            return View (vm);
        }

        [HttpPost]
        public ActionResult Alta(VMAuto auto)
        {
            GestorBD gestor = new GestorBD();
            gestor.InsertarAuto(auto.AutoModel);

            return View("Principal", gestor.ListadoAutos());

        }

        public ActionResult Reporte()
        {
            GestorBD gestor = new GestorBD();
            DTOAuto auto = gestor.UsadoMasNuevo();

            VMReporte rep = new VMReporte();
            rep.UsadoMasNuevo = auto;

            return View(rep);
        }

    }
}