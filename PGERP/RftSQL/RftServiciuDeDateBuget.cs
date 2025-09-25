using Microsoft.EntityFrameworkCore;
using PGERP.RftModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftSQL
{
    internal class RftServiciuDeDateBuget<T> where T : RftModelBuget
    {
        private readonly RftContextGeneratorModel rftContextGeneratorModel;

        public RftServiciuDeDateBuget(RftContextGeneratorModel rftContextGeneratorModel)
        {
            this.rftContextGeneratorModel = rftContextGeneratorModel;
        }

        public async Task<T> RftReturnareObiectId(int id)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? x = await context.Set<T>().FirstOrDefaultAsync((o) => o.Id == id);
            if (x is not null)
            {
                return x;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task<T> RftActualizareObiect(int id, T obiect)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            obiect.Id = id;
            context.Set<T>().Update(obiect);
            await context.SaveChangesAsync();
            return obiect;
        }

    }
}
