using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftVederiModele.RftVederiModeleContinut.RftVedereModelActivitatiSportive
{
    internal class RftVedereModelActivitatiSportiveAdaugare : RftVedereModelBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;

        private ObservableCollection<string>? rftLocatii;

        public ObservableCollection<string> RftLocatii
        {
            get
            {
                if (rftLocatii is not null)
                {
                    return rftLocatii;
                }
                else
                {
                    return new ObservableCollection<string>();
                }
            }
            set
            {
                rftLocatii = value;
                RftSchimbareProprietate(nameof(RftLocatii));
            }
        }

        private string? rftLocatieSelectata;

        public string RftLocatieSelectata
        {
            get
            {
                if (!string.IsNullOrEmpty(rftLocatieSelectata))
                {
                    return rftLocatieSelectata;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                rftLocatieSelectata = value;
                RftSchimbareProprietate(nameof(RftLocatieSelectata));
            }
        }

        public RftVedereModelActivitatiSportiveAdaugare(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
            RftColectareDate();
        }

        private void RftColectareDate()
        {
            List<string> x = new();

            foreach (Pushpin item in rftVedereModelContinut.RftLocatii)
            {
                x.Add(item.ToolTip.ToString());
            }
            x.Sort((a, b) => a.CompareTo(b));

            RftLocatii = new ObservableCollection<string>(x);
        }
    }
}
