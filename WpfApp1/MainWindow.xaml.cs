using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private string previousInput = "";
        private string currentOperator = null;
        private bool isNewOperation = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumber(object sender, RoutedEventArgs e)
        {
            if (isNewOperation)
            {
                currentInput = "";
                isNewOperation = false;
            }

            Button button = (Button)sender;
            currentInput += button.Content.ToString();
            UpdateDisplay();
        }

        private void OperatorClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string selectedOperator = button.Content.ToString();

            if (!string.IsNullOrEmpty(currentInput))
            {
                if (!string.IsNullOrEmpty(previousInput) && currentOperator != null)
                {
                    CalculateResult();
                }
                else
                {
                    previousInput = currentInput;
                }

                currentOperator = selectedOperator;
                currentInput = "";
                isNewOperation = false;
                UpdateDisplay(true);
            }
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(previousInput) && !string.IsNullOrEmpty(currentInput) && currentOperator != null)
            {
                CalculateResult();
                currentOperator = null;
                isNewOperation = true;

                // İşleme devam edebilmek için önceki sonucu koruyoruz.
                currentInput = previousInput;
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            ResetCalculator();
        }

        private void ResetCalculator()
        {
            currentInput = "";
            previousInput = "";
            currentOperator = null;
            isNewOperation = false;
            UpdateDisplay();
        }

        private void CalculateResult()
        {
            double num1 = double.Parse(previousInput);
            double num2 = double.Parse(currentInput);
            double result = 0;

            switch (currentOperator)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        Display.Text = "Hatalı bölme işlemi.";
                        ResetCalculator();
                        return;
                    }
                    break;
            }

            previousInput = result.ToString();
            currentInput = "";
            Display.Text = result.ToString();
        }

        private void UpdateDisplay(bool isOperatorClicked = false)
        {
            if (isOperatorClicked)
                Operator.Text = $"{previousInput} {currentOperator} ";
            else
                Operator.Text = $"{previousInput} {currentOperator} {currentInput}";

            if (!string.IsNullOrEmpty(currentInput))
                Display.Text = currentInput;
        }
    }
}
