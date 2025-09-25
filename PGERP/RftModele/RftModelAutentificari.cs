using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftModele
{
    public class RftModelAutentificari : RftModelBaza
    {
        public DateTime DataAutentificare { get; set; }
        public string? Utilizator { get; set; }
        public string? IP { get; set; }
        public string? DNS { get; set; }
        public bool Stare { get; set; }
    }
}
