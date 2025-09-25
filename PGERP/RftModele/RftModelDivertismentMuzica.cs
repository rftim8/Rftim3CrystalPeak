using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftModele
{
    public class RftModelDivertismentMuzica : RftModelBaza
    {
        public string? Categorie { get; set; }
        public string? SubCategorie { get; set; }
        public DateTime Data { get; set; }
        [Precision(12, 2)]
        public decimal Pret { get; set; }
        public int Cantitate { get; set; }
        public string? Tranzactie { get; set; }
        public string? FirmaProducatoare { get; set; }
        public string? DenumireMagazin { get; set; }
        public string? AdresaPaginaInternet { get; set; }
        public string? MetodaPlata { get; set; }
        public string? InstitutiaFinanciara { get; set; }
        public string? LocatieDocumente { get; set; }
        public string? Notite { get; set; }
    }
}
