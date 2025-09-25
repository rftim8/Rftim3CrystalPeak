using Microsoft.Maps.MapControl.WPF;
using PGERP.RftComenzi.RftAccesareVederi;
using PGERP.RftComenzi.RftLocatiiDocumente;
using PGERP.RftComenzi.RftTabela;
using PGERP.RftModele;
using PGERP.RftSQL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PGERP.RftVederiModele
{
    internal class RftVedereModelSetariLocatii : RftVedereModelBaza
    {
        private readonly RftServiciuDeDateLocatieDocumente<RftModelLocatieDocumente> rftServiciuDeDateLocatieDocumente = new(new RftContextGeneratorModel());

        private ObservableCollection<RftModelLocatieDocumente>? rftLocatii = new();

        public ObservableCollection<RftModelLocatieDocumente> RftLocatii
        {
            get
            {
                if (rftLocatii is not null)
                {
                    return rftLocatii;
                }
                else
                {
                    return new ObservableCollection<RftModelLocatieDocumente>();
                }
            }
            set
            {
                rftLocatii = value;
                RftSchimbareProprietate(nameof(RftLocatii));
            }
        }

        private ICollectionView? rftLocatiiFiltrate;

        public ICollectionView? RftLocatiiFiltrate
        {
            get { return rftLocatiiFiltrate; }
            set
            {
                rftLocatiiFiltrate = value;
                RftSchimbareProprietate(nameof(RftLocatiiFiltrate));
            }
        }

        private string? rftFiltruLocatii = string.Empty;

        public string? RftFiltruLocatii
        {
            get { return rftFiltruLocatii; }
            set
            {
                rftFiltruLocatii = value;
                RftSchimbareProprietate(nameof(RftFiltruLocatii));
                RftLocatiiFiltrate.Refresh();
            }
        }

        private RftModelLocatieDocumente? rftLocatieSelectata;

        public RftModelLocatieDocumente? RftLocatieSelectata
        {
            get { return rftLocatieSelectata; }
            set
            {
                rftLocatieSelectata = value;
                RftSchimbareProprietate(nameof(RftLocatieSelectata));
            }
        }

        private string? rftDenumire;

        public string? RftDenumire
        {
            get { return rftDenumire; }
            set
            {
                rftDenumire = value;
                RftSchimbareProprietate(nameof(RftDenumire));
            }
        }

        private string? rftLocatie;

        public string? RftLocatie
        {
            get { return rftLocatie; }
            set
            {
                rftLocatie = value;
                RftSchimbareProprietate(nameof(RftLocatie));
            }
        }

        private string? rftMesajStareModificareLocatie;

        public string? RftMesajStareModificareLocatie
        {
            get { return rftMesajStareModificareLocatie; }
            set
            {
                rftMesajStareModificareLocatie = value;
                RftSchimbareProprietate(nameof(RftMesajStareModificareLocatie));
            }
        }

        public ICommand RftComandaAccesareVedereContinut { get; }
        public ICommand RftComandaAdaugareLocatieDocumente { get; }
        public ICommand RftComandaSelectareLocatie { get; }
        public ICommand RftComandaStergereRand { get; }

        public RftVedereModelSetariLocatii(RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala)
        {
            RftColectareDate();
            RftComandaAccesareVedereContinut = new RftComandaAccesareVedereContinut(rftVedereModelFereastraPrincipala);
            RftComandaAdaugareLocatieDocumente = new RftComandaAdaugareLocatieDocumente(this);
            RftComandaSelectareLocatie = new RftComandaSelectareLocatie(this);
            RftComandaStergereRand = new RftComandaStergereRandLocatieDocumente(this);

            RftLocatiiFiltrate = CollectionViewSource.GetDefaultView(RftLocatii);
            RftLocatiiFiltrate.Filter = RftFiltrareLocatii;
        }

        private bool RftFiltrareLocatii(object obj)
        {
            if (obj is RftModelLocatieDocumente rftModelLocatieDocumente)
            {
                return rftModelLocatieDocumente.Denumire.Contains(RftFiltruLocatii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        private void RftColectareDate()
        {
            List<RftModelLocatieDocumente> x = rftServiciuDeDateLocatieDocumente.RftReturnareLocatii().Result.ToList();

            foreach (RftModelLocatieDocumente item in x)
            {
                RftLocatii.Add(item);
            }
        }

    }
}
