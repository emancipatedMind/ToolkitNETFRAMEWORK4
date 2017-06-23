namespace ToolkitNFW4.XAML {
    using System;
    using System.Windows.Input;
    public class DelegateCommand : ICommand {
        protected readonly Action<object> _command;
        protected Predicate<object> _canExecuteMethod;

        public DelegateCommand(Action<object> action, Predicate<object> canExecuteLogic = null) {
            _command = action;
            _canExecuteMethod = canExecuteLogic;
        }

        public DelegateCommand(Action action, Predicate<object> canExecuteLogic = null) : this(new Action<object>(o => action()), canExecuteLogic) { } 

        public virtual void Execute(object p) {
            _command(p);
        }

        public bool CanExecute(object parameter) {
            return _canExecuteMethod?.Invoke(parameter) ?? true;
        }

        #pragma warning disable 67
        public event EventHandler CanExecuteChanged {
            add {
                CommandManager.RequerySuggested += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
            }
        }
        #pragma warning restore 67
    }
}
