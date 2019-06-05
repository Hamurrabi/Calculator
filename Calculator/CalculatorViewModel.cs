using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Calculator.Annotations;

namespace Calculator {
  public class CalculatorViewModel : INotifyPropertyChanged {
    private double _num1;
    private double _num2;
    private string _operation; //note, varible names matter - had to search to figure out what op meant
    private string _answer;

    public double Num1 {
      get { return _num1; }
      set {
        _num1 = value;
        OnPropertyChanged(nameof(Num1));
      }
    }

    public double Num2 {
      get { return _num2; }
      set {
        _num2 = value;
        OnPropertyChanged(nameof(Num2));
      }
    }

    public string Operation {
      get { return _operation; }
      set {
        _operation = value;
        OnPropertyChanged(nameof(Operation));
      }
    }

    public string Answer {
      get { return _answer; }
      set {
        _answer = value;
        OnPropertyChanged(nameof(Answer));
      }
    }

    public ICommand ButtonCommand;

    public CalculatorViewModel() {
      RegisterCommands();
    }

    private void RegisterCommands() {
      ButtonCommand = new RelayCommand(ExecuteButtonCommand);
    }

    private void ExecuteButtonCommand(object parameter) {
      var key = (string) parameter;
      switch (key) {
        case "CE":
          if (Operation == string.Empty) {
            Num1 = 0;
          }
          else {
            Num2 = 0;
          }
          Answer = "0";
          break;

      }
    }

    //Stuff needed for INotifyPropertyChanged to work
    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}