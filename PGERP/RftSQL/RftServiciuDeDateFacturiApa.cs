using Microsoft.EntityFrameworkCore;
using PGERP.RftModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftSQL
{
    public class RftServiciuDeDateFacturiApa<T> where T : RftModelFacturiApa
    {
        private readonly RftContextGeneratorModel rftContextGeneratorModel;

        public RftServiciuDeDateFacturiApa(RftContextGeneratorModel rftContextGeneratorModel)
        {
            this.rftContextGeneratorModel = rftContextGeneratorModel;
        }

        public async Task<IEnumerable<T>> RftReturnareObiecteContinutPrincipala()
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            List<T>? lista = await context.Set<T>().ToListAsync();
            return lista;
        }
    }
}
