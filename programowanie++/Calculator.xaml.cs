using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace programowanie__
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {



        public Calculator()
        {
            InitializeComponent();
        }

        private List<Button> lastClickedButtons = new List<Button>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Content.ToString();
                Output.Text += $"{buttonText}";
                lastClickedButtons.Add(button);
            }

        }

        private void ButtonZnak_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string buttonText = button.Content.ToString();
                if (lastClickedButtons.Count == 0)
                {
                    switch (buttonText)
                    {
                        case "*":
                        case "/":
                        case "+":
                            return;
                        case "-":
                            Output.Text += $"{buttonText}";
                            break;
                    }
                }
                //refactoring
                else
                {
                    if (!(/*lastClickedButtons.Count > 0 &&*/ lastClickedButtons[lastClickedButtons.Count - 1].Tag.ToString() == "Znak"))
                    {
                        Output.Text += $"{buttonText}";
                        lastClickedButtons.Add(button);
                    }
                    else
                    {
                        return;
                    }
                }



            }
        }

        public static string BalanceBrackets(string input)
        {
            int bracketCount = 0;
            StringBuilder balancedStringBuilder = new StringBuilder(input);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracketCount++;
                }
                else if (input[i] == ')')
                {
                    bracketCount--;
                    if (bracketCount < 0)
                    {
                        // Insert a closing bracket at the appropriate position
                        balancedStringBuilder.Insert(i, ")");
                        bracketCount = 0; // Reset bracket count
                    }
                }
            }

            // Add any missing closing brackets at the end
            for (int i = 0; i < bracketCount; i++)
            {
                balancedStringBuilder.Append(")");
            }

            return balancedStringBuilder.ToString();
        }

        private void Button_Calc(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = Output.Text;
                expression = BalanceBrackets(expression);
                DataTable table = new DataTable();
                table.Columns.Add("expression", typeof(string), expression);
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                double result = double.Parse((string)row["expression"]);
                Output.Text = result.ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Division by zero!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected exception");
            }


        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            string toEr1char = Output.Text;
            if (toEr1char.Length == 0)
            {
                return;
            }
            else
            {
                Output.Text = toEr1char.Remove(toEr1char.Length - 1);
                lastClickedButtons.RemoveAt(lastClickedButtons.Count - 1);

            }
        }

        private void Button_floatPoint(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (lastClickedButtons.Count == 0 || (lastClickedButtons[lastClickedButtons.Count - 1].Tag.ToString() != "Numer" && lastClickedButtons[lastClickedButtons.Count - 1].Tag.ToString() != "floatPoint"))
                {
                    Output.Text += "0.";
                    lastClickedButtons.Add(num);
                    lastClickedButtons.Add(button);
                }
                //refactoring too
                else
                {
                    bool metFloatPoint = false;
                    for (int i = lastClickedButtons.Count - 1; i >= 0; i--)
                    {
                        if (lastClickedButtons[i].Tag.ToString() == "Znak")
                        {
                            break;
                        }
                        else
                        if (lastClickedButtons[i].Tag.ToString() == "floatPoint")
                        {
                            metFloatPoint = !metFloatPoint;
                            break;
                        }
                    }

                    if (metFloatPoint)
                    {
                        return;
                    }
                    else
                    {
                        lastClickedButtons.Add(button);
                        Output.Text += ".";
                    }


                }



            }
        }

        private void braket_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Output.Text += button.Content.ToString();
            }

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = "";
            lastClickedButtons.Clear();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                    Output.Text += e.Key.ToString()[1];
                    lastClickedButtons.Add(num);
                    break;
            }
        }
    }
}
