using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcesionaciaABMC.Models
{
    public class DTOAuto
    {
        public int idAuto { get; set; }
        public string patente { get; set; }
        public string nombre { get; set; }
        public int km { get; set; }
        public bool promocion { get; set; }
        public double precio { get; set; }


        public double PrecioPromocion
        {
            get
           {
            double descuentoTotal = 0;
            if (promocion) 
            { 
                 descuentoTotal = 0.1;
            }
  
                return precio - (precio * descuentoTotal);
            
            }
            
            
        }


    }
}