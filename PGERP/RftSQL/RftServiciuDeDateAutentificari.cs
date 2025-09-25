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
    /// <summary>
    ///    Clasa pentru transferul de date de tip RftModelAutentificari
    /// </summary>
    /// <typeparam name="T">Parametru care mosteneste modelul RftModelAutentificari</typeparam>
    public class RftServiciuDeDateAutentificari<T> where T : RftModelAutentificari
    {
        /// <summary>
        ///     Camp pentru stocarea referintei de tip context generator din constructor
        /// </summary>
        private readonly RftContextGeneratorModel rftContextGeneratorModel;

        /// <summary>
        ///     Constructor cu parametrul de tip context generator
        /// </summary>
        /// <param name="rftContextGeneratorModel">Parametru pentru apelarea contextului generator</param>
        public RftServiciuDeDateAutentificari(RftContextGeneratorModel rftContextGeneratorModel)
        {
            // Stocarea referintei in campul predefinit in momentul initializarii
            this.rftContextGeneratorModel = rftContextGeneratorModel;
        }

        /// <summary>
        ///     Task asincron de tip RftModelAutentificari pentru inregistrarea unui nou
        /// obiect in baza de date
        /// </summary>
        /// <param name="obiect">Obiectul adaugat trebuie sa fie de tip RftModelAutentificari</param>
        /// <returns></returns>
        public async Task<T> RftAdaugareObiect(T obiect)
        {
            // Initializare context si utilizare pe parcursul inregistrarii
            using RftContextModel context = rftContextGeneratorModel.CreateDbContext();

            // Stocare obiect nou in mod asincron, asteptare stocare
            EntityEntry<T> obiectNou = await context.Set<T>().AddAsync(obiect);

            // Salvare schimbarii in mod asincron
            await context.SaveChangesAsync();

            // Returnare obiect nou pentru inregistrare in baza de date
            return obiectNou.Entity;
        }

    }
}
