using System.Windows.Input;

namespace Rftim3WPFCL.Commands
{
    internal abstract class RftCoreCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);
    }
}
