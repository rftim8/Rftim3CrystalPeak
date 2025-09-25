using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftVederiModele
{
    /// <summary>
    ///     Clasa care mosteneste interfata INotifyPropertyChanged pentru a 
    /// putea fi mostenita de alte clase de tip vedere model
    /// </summary>
    public class RftVedereModelBaza : INotifyPropertyChanged
    {
        /// <summary>
        ///     Gestionar de eveniment care notifica schimbarea unei proprietati
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Functie care primeste drept parametru o proprietate care trebuie schimbata
        /// </summary>
        /// <param name="rftProprietate">Parametrul care trebuie schimbat</param>
        protected void RftSchimbareProprietate(string rftProprietate)
        {
            // Daca functia este solicitata gestionarul de eveniment este apelat iar proprietatea este schimbata
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(rftProprietate));
        }
    }
}
