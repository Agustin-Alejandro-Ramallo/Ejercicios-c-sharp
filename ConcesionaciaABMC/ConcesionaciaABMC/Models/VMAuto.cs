using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcesionaciaABMC.Models
{
    public class VMAuto
    {
        public Auto AutoModel { get; set; }
        public List<Marca> TipoMarcas { get; set; }
    }
}