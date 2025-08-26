using System.Windows.Input;

namespace Rftim3WPFCL.Commands
{
    public class RftRelayCommand(Action<object> executeObj, Predicate<object> canExecute) : ICommand
    {
        private readonly Action<object> executeObj = executeObj;
        private readonly Predicate<object> canExecute = canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object? parameter) => executeObj(parameter!);

        public bool CanExecute(object? parameter) => canExecute(parameter!);
    }
}
