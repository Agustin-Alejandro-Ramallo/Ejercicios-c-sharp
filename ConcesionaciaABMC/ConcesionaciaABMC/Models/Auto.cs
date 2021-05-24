using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcesionaciaABMC.Models
{
    public class Auto
    {
        public int idAuto { get; set; }
        public string patente { get; set; }
        public int idMarca { get; set; }
        public int km { get; set; }
        public bool promocion { get; set; }
        public double precio { get; set; }

    }
}