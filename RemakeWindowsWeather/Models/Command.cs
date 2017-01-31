using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RemakeWindowsWeather.Models
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Func<object, bool> canExecuteMethod;
        Action<object> executeMethod;


        public Command(Func<object, bool> canExecuteMethod, Action<object> executeMethod)
        {
            this.canExecuteMethod = canExecuteMethod;
            this.executeMethod = executeMethod;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
            
        }
    }
}
