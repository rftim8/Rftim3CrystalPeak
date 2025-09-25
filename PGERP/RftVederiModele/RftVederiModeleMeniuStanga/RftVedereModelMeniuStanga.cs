using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftVederiModele.RftVederiModeleMeniuStanga
{
    internal class RftVedereModelMeniuStanga : RftVedereModelBaza
    {
        public RftVedereModelMeniuStanga()
        {
            RftVedereModelMeniuStangaCurent = new RftVedereModelMeniuStangaPrincipala();
        }

        private RftVedereModelBaza? rftVedereModelMeniuStangaCurent;

        public RftVedereModelBaza RftVedereModelMeniuStangaCurent
        {
            get
            {
                if (rftVedereModelMeniuStangaCurent is not null)
                {
                    return rftVedereModelMeniuStangaCurent;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            set
            {
                rftVedereModelMeniuStangaCurent = value;
                RftSchimbareProprietate(nameof(RftVedereModelMeniuStangaCurent));
            }
        }
    }
}
