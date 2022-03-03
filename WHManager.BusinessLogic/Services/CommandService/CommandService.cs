using System;
using System.Windows.Input;

namespace WHManager.BusinessLogic.Services.CommandService
{
    public class CommandService : ICommand
    {
        private readonly Action _action;

        public CommandService(Action action)
        {
            _action = action;
        }

        public void Execute(object o)
        {
            _action();
        }

        public bool CanExecute(object o)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}