using System.Diagnostics.Contracts;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private  string firstNumber= null;
        private string secondNumber = null;
        private string currentOp = null;
        private bool isSetOperator = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ButtonNumber(object sender, RoutedEventArgs e)
        {
            Button button= (Button)sender;

            if (!isSetOperator) 
            {
                firstNumber += button.Content.ToString();
                Display.Text=firstNumber.ToString();
            }
            else
            {
                secondNumber += button.Content.ToString(); 
                Display.Text=firstNumber+currentOp+secondNumber;
            }



        }
       
        private void OperatorClick(object sender, RoutedEventArgs e)
        {
            if (firstNumber == null)
                return;
            Button button= (Button)sender;
            currentOp=button.Content.ToString();
            Operator.Text=currentOp;
            if(firstNumber !=null && secondNumber !=null)
            {
                Display.Text = firstNumber + currentOp+secondNumber  ;

            }else if(firstNumber != null && secondNumber == null)
            {
                Display.Text = firstNumber + currentOp;

            }else
            {
                Display.Text = " " + currentOp + " ";
            }
            isSetOperator = true;
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            Calculate calculate = new Calculate();
            if (!isSetOperator || firstNumber ==null || secondNumber ==null)
                return;

            double conclusion = 0;
            switch (currentOp)
            {
                case "+":
                    conclusion=calculate.add(Double.Parse(firstNumber), Double.Parse(secondNumber));
                    break;
                case "-":
                    conclusion=calculate.subtraction(Double.Parse(firstNumber), Double.Parse(secondNumber));
                    break;
                case "*":
                    conclusion=calculate.times(Double.Parse(firstNumber), Double.Parse(secondNumber));
                    break;
                case "/":
                    if (!Double.Parse(secondNumber).Equals(0))
                    {
                    conclusion=calculate.divide(Double.Parse(firstNumber), Double.Parse(secondNumber));
                    }
                    else
                    {
                        Display.Text= "Hatalı bölme işlemi.";
                        firstNumber = "";
                        secondNumber = "";
                        currentOp = null;
                        isSetOperator = false;
                        return;
                    }
                    break;
            }
            firstNumber = conclusion.ToString();
            secondNumber = "";
            Display.Text = conclusion.ToString()+currentOp;

            
        }
        private void Clear(object sender,RoutedEventArgs e)
        {
            ResetCalculator();
        }
        private void ResetCalculator()
        {
            firstNumber = "";
            secondNumber = "";
            currentOp = null;
            isSetOperator = false;
            Display.Text = "";
        }














        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}