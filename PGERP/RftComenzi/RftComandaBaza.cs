using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PGERP.RftComenzi
{
    /// <summary>
    ///     Clasa abstracta care mosteneste interfata ICommand, 
    /// care este folosita pentru a fi mostenita de clase pentru 
    /// a putea executa comenzi
    /// </summary>
    public abstract class RftComandaBaza : ICommand
    {
        // Gestionar de eveniment care verifica daca comanda poate fi executata
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        ///     Functie care decide daca comanda poate fi executata
        /// </summary>
        /// <param name="parameter">Parametrul care trebuie revizuit</param>
        /// <returns>Executia aprobata in mod implicit, deoarece verificari sunt implementate in momentul apelarii</returns>
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        ///     Functie de executie abstracta pentru a putea decide la implementare ce
        /// ar trebui acesta functie sa execute
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object? parameter);

        /// <summary>
        ///     Functie care este apelata in momentul schimbarii starii
        /// de executie si paseaza comenzii noile argumente
        /// </summary>
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
