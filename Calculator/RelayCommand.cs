using System;
using System.Windows.Input;

namespace Calculator {
  //This class is a generic template used to help implement MVVM
  //It is a very good working example, though it may not always accomodate all needs
  public class RelayCommand : ICommand {
    public event EventHandler CanExecuteChanged {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    private readonly Action<object> methodToExecute;
    private readonly Func<bool> canExecuteEvaluator;

    public RelayCommand(Action<object> methodToExecute, Func<bool> canExecuteEvaluator) {
      this.methodToExecute = methodToExecute;
      this.canExecuteEvaluator = canExecuteEvaluator;
    }

    public RelayCommand(Action<object> methodToExecute) : this(methodToExecute, null) { }

    public bool CanExecute(object parameter) {
      if (canExecuteEvaluator == null) {
        return true;
      }
      else {
        bool result = canExecuteEvaluator.Invoke();
        return result;
      }
    }

    public void Execute(object parameter) {
      methodToExecute(parameter);
    }
  }
}