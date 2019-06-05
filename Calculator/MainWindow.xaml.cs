using System.Windows;
using System.Windows.Controls;

namespace Calculator {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    double num1 = 0;
    double num2 = 0;

    string op = "";

    public MainWindow() {
      InitializeComponent();
    }

    //number buttons
    private void btnNum_Click(object sender, RoutedEventArgs e) {
      Button btn = (Button) sender;
      if (screen.Text == "0") {
        screen.Text = btn.Content.ToString();
      }
      else {
        screen.Text += btn.Content.ToString();
      }
    }

    //operator buttons
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