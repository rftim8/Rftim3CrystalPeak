using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftModele
{
    public class RftModelBuget : RftModelBaza
    {
        [Precision(12, 2)]
        public decimal Total { get; set; }
        [Precision(12, 2)]
        public decimal Nealocat { get; set; }
        [Precision(12, 2)]
        public decimal Cumparaturi { get; set; }
        [Precision(12, 2)]
        public decimal Divertisment { get; set; }
        [Precision(12, 2)]
        public decimal Educatie { get; set; }
        [Precision(12, 2)]
        public decimal Facturi { get; set; }
        [Precision(12, 2)]
        public decimal Sanatate { get; set; }
        [Precision(12, 2)]
        public decimal Transport { get; set; }
        [Precision(12, 2)]
        public decimal CumparaturiAlimente { get; set; }
        [Precision(12, 2)]
        public decimal CumparaturiElectronice { get; set; }
        [Precision(12, 2)]
        public decimal CumparaturiImbracaminte { get; set; }
        [Precision(12, 2)]
        public decimal DivertismentFilme { get; set; }
        [Precision(12, 2)]
        public decimal DivertismentJocuri { get; set; }
        [Precision(12, 2)]
        public decimal DivertismentMuzica { get; set; }
        [Precision(12, 2)]
        public decimal EducatieCartiElectronice { get; set; }
        [Precision(12, 2)]
        public decimal EducatieEvenimente { get; set; }
        [Precision(12, 2)]
        public decimal EducatieInvatamant { get; set; }
        [Precision(12, 2)]
        public decimal FacturiApa { get; set; }
        [Precision(12, 2)]
        public decimal FacturiCurent { get; set; }
        [Precision(12, 2)]
        public decimal FacturiTelefonie { get; set; }
        [Precision(12, 2)]
        public decimal SanatateActivitatiSportive { get; set; }
        [Precision(12, 2)]
        public decimal SanatateMedical { get; set; }
        [Precision(12, 2)]
        public decimal TransportComun { get; set; }
        [Precision(12, 2)]
        public decimal TransportPersonal { get; set; }
    }
}
