using Parcial2Prog3.AccesoDatos;
using Parcial2Prog3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial2Prog3.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Lista()
        {
            GestorBD gestor = new GestorBD();
            List<DTOPedido> lista = gestor.ListadoPedidos();

            return View(lista);
        }

        public ActionResult Alta()
        {
            GestorBD gestor = new GestorBD();
            VMPedido vm = new VMPedido();

            vm.DesayunoModel = gestor.ListadoTipoDesayuno();
            vm.DeliveryModel = gestor.ListadoTipoDelivery();
            return View(vm);
        }




        [HttpPost]
        public ActionResult Alta(VMPedido pedido)
        {
            GestorBD gestor = new GestorBD();
            gestor.InsertarPedido(pedido.PedidoModel);
            return View("Lista", gestor.ListadoPedidos());

        }

        public ActionResult Reporte()
        {
            GestorBD gestor = new GestorBD();
            List<DTOCantidadPorDelivery> lista = gestor.CantidadPorDeliver();


            VMCantidadDelivery vm = new VMCantidadDelivery();
            vm.CantidadPorDelivery = lista;


            return View(vm);
        }
    }
}