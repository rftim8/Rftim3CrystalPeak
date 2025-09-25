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
    internal class RftServiciuDeDateLocatii<T> where T : RftModelLocatie
    {
        private readonly RftContextGeneratorModel rftContextGeneratorModel;

        public RftServiciuDeDateLocatii(RftContextGeneratorModel rftContextGeneratorModel)
        {
            this.rftContextGeneratorModel = rftContextGeneratorModel;
        }

        public async Task<IEnumerable<T>> RftReturnareLocatii()
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            List<T>? lista = await context.Set<T>().ToListAsync();
            return lista;
        }

        public async Task<T?> RftReturnareDenumireLocatie(string rftDenumireLocatie)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? x = await context.Set<T>().FirstOrDefaultAsync((o) => o.DenumireLocatie == rftDenumireLocatie);
            if (x is not null)
            {
                return x;
            }
            else
            {
                return default;
            }
        }

        public async Task<T> RftAdaugareLocatieNoua(T obiect)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            EntityEntry<T> obiectNou = await context.Set<T>().AddAsync(obiect);
            await context.SaveChangesAsync();
            return obiectNou.Entity;
        }

        public async Task<bool> RftStergereLocatie(string locatie)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? obiectVechi = await context.Set<T>().FirstOrDefaultAsync((o) => o.DenumireLocatie == locatie);
            if (obiectVechi is not null)
            {
                context.Set<T>().Remove(obiectVechi);
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
