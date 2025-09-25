using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftModele
{
    public class RftModelUtilizatori : RftModelBaza
    {
        public DateTime DataInregistrare { get; set; }
        public string? Utilizator { get; set; }
        public string? Parola { get; set; }
        public string? Prenume { get; set; }
        public string? Nume { get; set; }
        public string? Email { get; set; }
    }
}
