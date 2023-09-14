using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWPProjekt.ViewModel
{
    public class CommandsViewModel : ICommand
    {
        //Fields
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        //Constructors
        public CommandsViewModel(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public CommandsViewModel(Action<object> executeAction,
                                Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction != null ? true : _canExecuteAction(parameter);
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
           throw new NotImplementedException();
        }
    }
}
