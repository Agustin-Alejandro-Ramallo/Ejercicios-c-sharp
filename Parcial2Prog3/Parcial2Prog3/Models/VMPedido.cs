using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial2Prog3.Models
{
    public class VMPedido
    {
        public Pedido PedidoModel { get; set; }
        public List<TipoDesayuno> DesayunoModel { get; set; }
        public List<TipoDelivery> DeliveryModel { get; set; }
    }
}