namespace ToolkitNFW4.XAML {
    using System;
    using System.Threading.Tasks;
    public class DelegateCommandTask : DelegateCommand {

        public DelegateCommandTask(Action<object> action, Func<object, bool> canExecuteLogic = null) : base(action, canExecuteLogic) { }

        public override void Execute(object p) {
            Task.Factory.StartNew(
                () => _command(p)
            );
        }
    }
}
