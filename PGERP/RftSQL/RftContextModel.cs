using Microsoft.EntityFrameworkCore;
using PGERP.RftModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftSQL
{
    /// <summary>
    ///     Contextul model mosteneste clasa DbContext care contine actiunile de tranzactie cu baza de date
    /// </summary>
    public class RftContextModel : DbContext
    {
        /// <summary>
        ///     Setarea unei tabele de tip RftModelUtilizatori pentru tranzactionarea cu baza de date
        /// </summary>
        public DbSet<RftModelUtilizatori>? RftModelUtilizatoriSet { get; set; }

        /// <summary>
        ///     Setarea unei tabele de tip RftModelAutentificari pentru tranzactionarea cu baza de date
        /// </summary>
        public DbSet<RftModelAutentificari>? RftModelAutentificariSet { get; set; }

        /// <summary>
        ///     Setarea unei tabele de tip RftModelTemaCulori pentru tranzactionarea cu baza de date
        /// </summary>
        public DbSet<RftModelTemaCulori>? RftModelTemaCuloriSet { get; set; }

        /// <summary>
        ///     Setarea unei tabele de tip RftModelCumparaturiAlimente pentru tranzactionarea cu baza de date
        /// </summary>
        public DbSet<RftModelCumparaturiAlimente>? RftModelCumparaturiAlimenteSet { get; set; }
        public DbSet<RftModelCumparaturiElectronice>? RftModelCumparaturiElectroniceSet { get; set; }
        public DbSet<RftModelCumparaturiImbracaminte>? RftModelCumparaturiImbracaminteSet { get; set; }
        public DbSet<RftModelDivertismentFilme>? RftModelDivertismentFilmeSet { get; set; }
        public DbSet<RftModelDivertismentJocuri>? RftModelDivertismentJocuriSet { get; set; }
        public DbSet<RftModelDivertismentMuzica>? RftModelDivertismentMuzicaSet { get; set; }
        public DbSet<RftModelEducatieCartiElectronice>? RftModelEducatieCartiElectroniceset { get; set; }
        public DbSet<RftModelEducatieEvenimente>? RftModelEducatieEvenimenteSet { get; set; }
        public DbSet<RftModelEducatieInvatamant>? RftModelEducatieInvatamantSet { get; set; }
        public DbSet<RftModelFacturiApa>? RftModelFacturiApaSet { get; set; }
        public DbSet<RftModelFacturiCurent>? RftModelFacturiCurentSet { get; set; }
        public DbSet<RftModelFacturiTelefonie>? RftModelFacturiTelefonieSet { get; set; }
        public DbSet<RftModelSanatateActivitatiSportive>? RftModelSanatateActivitatiSportiveSet { get; set; }
        public DbSet<RftModelSanatateMedical>? RftModelSanatateMedicalSet { get; set; }
        public DbSet<RftModelTransportComun>? RftModelTransportComunSet { get; set; }
        public DbSet<RftModelTransportPersonal>? RftModelTransportPersonalSet { get; set; }
        public DbSet<RftModelBuget>? RftModelBugetSet { get; set; }
        public DbSet<RftModelLocatie>? RftModelLocatiiSet { get; set; }
        public DbSet<RftModelLocatieDocumente>? RftModelLocatieDocumenteSet { get; set; }

        public RftContextModel(DbContextOptions optiuni) : base(optiuni)
        {

        }
    }
}
