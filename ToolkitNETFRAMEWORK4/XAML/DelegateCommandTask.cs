namespace ToolkitNFW4.XAML {
    using System;
    using System.Threading.Tasks;
    public class DelegateCommandTask : DelegateCommand {

        public DelegateCommandTask(Action<object> action, Predicate<object> canExecuteLogic = null) : base(action, canExecuteLogic) { }

        public DelegateCommandTask(Action action, Predicate<object> canExecuteLogic = null) : this(new Action<object>(o => action()), canExecuteLogic) { } 

        public override void Execute(object p) {
            Task.Factory.StartNew(() => _command(p));
        }
    }
}