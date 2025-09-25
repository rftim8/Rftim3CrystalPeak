using PGERP.RftComenzi;
using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using PGERP.RftVederiModele.RftVederiModeleMeniuStanga;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PGERP.RftVederiModele
{
    internal class RftVedereModelFereastraPrincipala : RftVedereModelBaza
    {
        private readonly RftVedereModelMeniuStanga rftVedereModelMeniuStanga = new();
        private readonly RftVedereModelContinut rftVedereModelContinut = new();

        public RftVedereModelContinut RftVedereModelContinut
        {
            get { return rftVedereModelContinut; }
            set { }
        }

        private RftVedereModelSetariCont? rftVedereModelSetariCont;

        public RftVedereModelSetariCont? RftVedereModelSetariCont
        {
            get
            {
                if (rftVedereModelSetariCont is not null)
                {
                    return rftVedereModelSetariCont;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                rftVedereModelSetariCont = value;
                RftSchimbareProprietate(nameof(RftVedereModelSetariCont));
            }
        }

        private RftVedereModelSetariLocatii? rftVedereModelSetariLocatii;

        public RftVedereModelSetariLocatii? RftVedereModelSetariLocatii
        {
            get
            {
                if (rftVedereModelSetariLocatii is not null)
                {
                    return rftVedereModelSetariLocatii;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                rftVedereModelSetariLocatii = value;
                RftSchimbareProprietate(nameof(RftVedereModelSetariLocatii));
            }
        }

        public RftVedereModelFereastraPrincipala(RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat)
        {
            RftVedereModelSetariCont = new RftVedereModelSetariCont(this, rftModelUtilizatorAutentificat);
            RftVedereModelSetariLocatii = new RftVedereModelSetariLocatii(this);
            RftVedereModelMeniuTopCurent = new RftVedereModelMeniuTop(
                rftVedereModelContinut,
                rftVedereModelMeniuStanga,
                this,
                rftModelUtilizatorAutentificat,
                RftVedereModelSetariCont,
                RftVedereModelSetariLocatii
                );
            RftVedereModelMeniuBottomCurent = new RftVedereModelMeniuBottom();
            RftVedereModelContinutCurent = rftVedereModelContinut;
            RftVedereModelMeniuStangaCurent = rftVedereModelMeniuStanga;
            RftTextCategorieCurenta = "Acasa";
        }

        private RftVedereModelBaza? rftVedereModelMeniuBottomCurent;
        public RftVedereModelBaza RftVedereModelMeniuBottomCurent
        {
            get
            {
                if (rftVedereModelMeniuBottomCurent is not null)
                {
                    return rftVedereModelMeniuBottomCurent;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            set
            {
                rftVedereModelMeniuBottomCurent = value;
                RftSchimbareProprietate(nameof(RftVedereModelMeniuBottomCurent));
            }
        }


        private RftVedereModelBaza? rftVedereModelMeniuTopCurent;
        public RftVedereModelBaza RftVedereModelMeniuTopCurent
        {
            get
            {
                if (rftVedereModelMeniuTopCurent is not null)
                {
                    return rftVedereModelMeniuTopCurent;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            set
            {
                rftVedereModelMeniuTopCurent = value;
                RftSchimbareProprietate(nameof(RftVedereModelMeniuTopCurent));
            }
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


        private RftVedereModelBaza? rftVedereModelContinutCurent;
        public RftVedereModelBaza RftVedereModelContinutCurent
        {
            get
            {
                if (rftVedereModelContinutCurent is not null)
                {
                    return rftVedereModelContinutCurent;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            set
            {
                rftVedereModelContinutCurent = value;
                RftSchimbareProprietate(nameof(RftVedereModelContinutCurent));
            }
        }


        private string? rftTextCategorieCurenta;
        public string RftTextCategorieCurenta
        {
            get
            {
                if (rftTextCategorieCurenta is not null)
                {
                    return rftTextCategorieCurenta;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            set
            {
                rftTextCategorieCurenta = value;
                RftSchimbareProprietate(nameof(rftTextCategorieCurenta));
            }
        }

    }
}
