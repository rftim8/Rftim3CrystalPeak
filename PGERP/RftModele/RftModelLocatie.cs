using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftModele
{
    public class RftModelLocatie : RftModelBaza
    {
        public string? DenumireLocatie { get; set; }
        public double Latitudine { get; set; }
        public double Longitudine { get; set; }
    }
}
