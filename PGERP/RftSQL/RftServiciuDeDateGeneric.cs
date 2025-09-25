using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PGERP.RftModele;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftSQL
{
    public class RftServiciuDeDateGeneric<T> : IRftServiciuDeDate<T> where T : RftModelBaza
    {
        private readonly RftContextGeneratorModel rftContextGeneratorModel;

        public RftServiciuDeDateGeneric(RftContextGeneratorModel rftContextGeneratorModel)
        {
            this.rftContextGeneratorModel = rftContextGeneratorModel;
        }

        public async Task<T> RftActualizareObiect(int id, T obiect)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            obiect.Id = id;
            context.Set<T>().Update(obiect);
            await context.SaveChangesAsync();
            return obiect;
        }

        public async Task<T> RftAdaugareObiect(T obiect)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            EntityEntry<T> obiectNou = await context.Set<T>().AddAsync(obiect);
            await context.SaveChangesAsync();
            return obiectNou.Entity;
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

        public async Task<IEnumerable<T>> RftReturnareObiecte()
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            List<T>? lista = await context.Set<T>().ToListAsync();
            return lista;
        }

        public async Task<bool> RftStergereObiect(int id)
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
