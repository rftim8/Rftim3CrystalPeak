using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PGERP.RftModele;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftSQL
{
    /// <summary>
    ///     Clasa pentru setarea generatorului de context, aceasta mosteneste interfata
    /// IDesignTimeDbContextFactory de tip RftContexModel pentru setarea contextelor
    /// constructorul nefiind initializat
    /// </summary>
    public class RftContextGeneratorModel : IDesignTimeDbContextFactory<RftContextModel>
    {
        /// <summary>
        ///     Initializarea constructorului mostenit
        /// </summary>
        /// <param name="args">Constructorul poate sa nu primeasca parametrii</param>
        /// <returns></returns>
        //public RftContextModel CreateDbContext(string[]? args = null)
        //{
        //    // Optiunile contextului sunt reinitializate pentru a crea o instanta noua
        //    DbContextOptionsBuilder<RftContextModel>? optiuni = new();

        //    // Setarea contextului de a utiliza baza de date de tip sqlite din string
        //    optiuni.UseSqlite($"Data Source=RFTSQlite\\PGERP.db");

        //    // Returnarea noului context care foloseste baza de date setata
        //    return new RftContextModel(optiuni.Options);
        //}

        public RftContextModel CreateDbContext(string[]? args = null)
        {
            DbContextOptionsBuilder<RftContextModel>? optiuni = new();
            string rftLocatieProiect = $"{Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString())}";
            optiuni.UseSqlite($"Data Source={rftLocatieProiect}/RftSQLite/PGERP.db");
            return new RftContextModel(optiuni.Options);
        }

        //public RftContextModel CreateDbContext(string[]? args = null)
        //{
        //    DbContextOptionsBuilder<RftContextModel>? optiuni = new();
        //    optiuni.UseSqlServer("Data Source=RFTM\\RFT;Database=PGERP;Integrated Security=True;");
        //    return new RftContextModel(optiuni.Options);
        //}
    }
}
