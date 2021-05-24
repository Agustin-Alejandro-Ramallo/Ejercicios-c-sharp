using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial2Prog3.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public int IdTipoDesayuno { get; set; }
        public int IdTipoDelivery { get; set; }
        public int Porciones { get; set; }
    }
}