using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PGERP.RftModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftSQL
{
    internal class RftServiciuDeDateLocatieDocumente<T> where T : RftModelLocatieDocumente
    {
        private readonly RftContextGeneratorModel rftContextGeneratorModel;

        public RftServiciuDeDateLocatieDocumente(RftContextGeneratorModel rftContextGeneratorModel)
        {
            this.rftContextGeneratorModel = rftContextGeneratorModel;
        }

        public async Task<IEnumerable<T>> RftReturnareLocatii()
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            List<T>? lista = await context.Set<T>().ToListAsync();
            return lista;
        }

        public async Task<T> RftAdaugareLocatie(T obiect)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            EntityEntry<T> obiectNou = await context.Set<T>().AddAsync(obiect);
            await context.SaveChangesAsync();
            return obiectNou.Entity;
        }

        public async Task<T?> RftReturnareLocatieDenumire(string denumire)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? x = await context.Set<T>().FirstOrDefaultAsync((o) => o.Denumire == denumire);
            if (x is not null)
            {
                return x;
            }
            else
            {
                return default;
            }
        }

        public async Task<bool> RftStergereLocatieDocumente(int id)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? obiectVechi = await context.Set<T>().FirstOrDefaultAsync((o) => o.Id == id);
            if (obiectVechi is not null)
            {
                context.Set<T>().Remove(obiectVechi);
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
