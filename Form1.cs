using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private string operation = "";
        private bool isNewCalculation = false;
        public Form1()
        {
            InitializeComponent();
            ZeroButton.Click += Number_Click;
            OneButton.Click += Number_Click;
            TwoButton.Click += Number_Click;
            ThreeButton.Click += Number_Click;
            FourButton.Click += Number_Click;
            FiveButton.Click += Number_Click;
            SixButton.Click += Number_Click;
            SevenButton.Click += Number_Click;
            EightButton.Click += Number_Click;
            NineButton.Click += Number_Click;

            AddButton.Click += Operator_Click;
            SubButton.Click += Operator_Click;
            MulButton.Click += Operator_Click;
            DivButton.Click += Operator_Click;

            ClearOneButton.Click += Function_Click;
            ClearButton.Click += Function_Click;
            EqualButton.Click += Function_Click;

            DotButton.Click += DotButton_Click;

        }

        private void Function_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Text)
            {
                case "CE":
                    if (DisplayTextBox.Text.Length > 1)
                    {
                        DisplayTextBox.Text = DisplayTextBox.Text.Substring(0, DisplayTextBox.Text.Length - 1);
                    }
                    else
                    {
                        DisplayTextBox.Text = "0"; 
                    }
                    break;

                case "C": 
                    DisplayTextBox.Text = "0";
                    firstNumber = 0;
                    operation = "";
                    isNewCalculation = true;
                    break;

                case "=": 
                    if (double.TryParse(DisplayTextBox.Text, out double secondNumber))
                    {
                        double result = 0;

                        switch (operation)
                        {
                            case "+":
                                result = firstNumber + secondNumber;
                                break;
                            case "-":
                                result = firstNumber - secondNumber;
                                break;
                            case "*":
                                result = firstNumber * secondNumber;
                                break;
                            case "/":
                                if (secondNumber != 0)
                                    result = firstNumber / secondNumber;
                                else
                                {
                                    MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                break;
                        }

                        DisplayTextBox.Text = result.ToString();
                        operation = "";
                        isNewCalculation = true;
                    }
                    break;
            }
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            
            if (!string.IsNullOrEmpty(operation))
            {
                EqualButton.PerformClick();
            }

            
            if (double.TryParse(DisplayTextBox.Text, out firstNumber))
            {
                operation = button.Text;
                isNewCalculation = true;
            }
        }

        private void Number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            
            if (DisplayTextBox.Text == "0" || isNewCalculation)
            {
                DisplayTextBox.Text = button.Text;
                isNewCalculation = false;
            }
            else
            {
                DisplayTextBox.Text += button.Text;
            }
        }
        private void DotButton_Click(object sender, EventArgs e)
        {
            if (isNewCalculation)
            {
                DisplayTextBox.Text = "0.";
                isNewCalculation = false;
            }
            else if (!DisplayTextBox.Text.Contains("."))
            {
                DisplayTextBox.Text += ".";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void DotButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
