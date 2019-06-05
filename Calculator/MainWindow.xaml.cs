using System.Windows;
using System.Windows.Controls;

namespace Calculator {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    #region Properties

    //this is an example of a region... 
    //why not to use it?
    //it's only purpose is to hide bad code
    //use a comment line if it's absolutely necessary to break up different pieces of code
    //i will remove these on my next commit

    double num1 = 0;
    double num2 = 0;

    string op = "";
    
    #endregion

    #region Constructor
    public MainWindow() {
      InitializeComponent();
    }
    #endregion

    //number buttons - see?... you don't need a region
    private void btnNum_Click(object sender, RoutedEventArgs e) {
      Button btn = (Button) sender;
      if (screen.Text == "0") {
        screen.Text = btn.Content.ToString();
      }
      else {
        screen.Text += btn.Content.ToString();
      }
    }

    //operator buttons - and you don't need one here either... which perfectly illustrates my previous point of using comment lines instead
    private void btnOp_Click(object sender, RoutedEventArgs e) {
      Button btn = (Button) sender;
      op = btn.Content.ToString();
      num1 = double.Parse(screen.Text);
      screen.Text = "0";
    }

    private void BEqu_Click(object sender, RoutedEventArgs e) {
      num2 = double.Parse(screen.Text);
      switch (op) {
        case "+":
          screen.Text = (num1 + num2).ToString();
          break;
        case "-":
          screen.Text = (num1 - num2).ToString();
          break;
        case "*":
          screen.Text = (num1 * num2).ToString();
          break;
        case "/":
          screen.Text = (num1 / num2).ToString();
          break;
      }
    }

    private void BCE_Click(object sender, RoutedEventArgs e) {
      if (op == "") {
        num1 = 0;
        screen.Text = "0";
      }
      else {
        num2 = 0;
        screen.Text = "0";
      }
    }

    private void BDec_Click(object sender, RoutedEventArgs e) {
      screen.Text = screen.Text + ".";
    }

    private void BC_Click(object sender, RoutedEventArgs e) {
      num1 = 0;
      num2 = 0;
      op = "";
      screen.Text = "0";
    }

    private void BPosNeg_Click(object sender, RoutedEventArgs e) {
      if (screen.Text.StartsWith("-")) {
        screen.Text = screen.Text.Substring(1);
      }
      else if (!string.IsNullOrEmpty(screen.Text) && double.Parse(screen.Text) != 0) {
        screen.Text = "-" + screen.Text;
      }
    }
  }
}