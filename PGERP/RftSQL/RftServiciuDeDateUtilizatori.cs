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
    public class RftServiciuDeDateUtilizatori<T> where T : RftModelUtilizatori
    {
        private readonly RftContextGeneratorModel rftContextGeneratorModel;

        public RftServiciuDeDateUtilizatori(RftContextGeneratorModel rftContextGeneratorModel)
        {
            this.rftContextGeneratorModel = rftContextGeneratorModel;
        }

        public async Task<bool> RftReturnareObiectUtilizator(string utilizator, string parola)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? x = await context.Set<T>().FirstOrDefaultAsync((o) => o.Utilizator == utilizator && o.Parola == parola);
            if (x is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RftReturnareObiectUtilizator(string utilizator)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? x = await context.Set<T>().FirstOrDefaultAsync((o) => o.Utilizator == utilizator);
            if (x is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<T?> RftReturnareUtilizatorAutentificat(string utilizator)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? x = await context.Set<T>().FirstOrDefaultAsync((o) => o.Utilizator == utilizator);
            if (x is not null)
            {
                return x;
            }
            else
            {
                return default;
            }
        }

        public async Task<bool> RftStergereObiect(string utilizator)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            T? obiectVechi = await context.Set<T>().FirstOrDefaultAsync((o) => o.Utilizator == utilizator);
            if (obiectVechi is not null)
            {
                context.Set<T>().Remove(obiectVechi);
            }
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<T> RftActualizareObiect(string utilizator, T obiect)
        {
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();
            obiect.Utilizator = utilizator;
            context.Set<T>().Update(obiect);
            await context.SaveChangesAsync();
            return obiect;
        }

    }
}
