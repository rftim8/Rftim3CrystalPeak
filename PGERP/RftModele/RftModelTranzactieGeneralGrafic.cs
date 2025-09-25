using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftModele
{
    public class RftModelTranzactieGeneralGrafic
    {
        public string? Categorie { get; set; }
        public string? SubCategorie { get; set; }
        [Precision(12, 2)]
        public decimal Pret { get; set; }
        public DateTime Data { get; set; }
    }
}
