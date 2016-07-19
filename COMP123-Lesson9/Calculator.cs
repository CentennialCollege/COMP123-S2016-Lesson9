using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_Lesson9
{
    public partial class Calculator : Form
    {
        public string ActiveOperator { get; set; }

        public string FirstOperand { get; set; }
        public string SecondOperand { get; set; }

        public bool ActiveError { get; set; }

        public Calculator()
        {
            InitializeComponent();
        }

        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            if(this.ActiveError == false)
            {
                // create a reference to the sender object 
                // and tell c-sharp that it is a button
                Button buttonClicked = (Button)sender;


                // check to see if ResultTextbox has a 0 in it
                if (String.Equals(ResultTextBox.Text, "0"))
                {
                    ResultTextBox.Clear();
                }

                // read the string in the TextBox
                string currentResult = ResultTextBox.Text;

                // add the text of the button clicked to the currentResult
                currentResult += buttonClicked.Text;

                // update the ResultTextBox
                ResultTextBox.Text = currentResult;
            }
            
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "0";
            this.FirstOperand = String.Empty;
            this.SecondOperand = String.Empty;
            this.ActiveOperator = String.Empty;
            this.ActiveError = false;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            if(this.ActiveError == false)
            {
                Button operatorClicked = (Button)sender;

                this.ActiveOperator = operatorClicked.Text;


                this.FirstOperand = ResultTextBox.Text;


                ResultTextBox.Clear();
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if(this.ActiveError == false)
            {
                int firstNumber = 0;
                int secondNumber = 0;
                int result = 0;
                bool divisionByZero = false;

                this.SecondOperand = ResultTextBox.Text;


                firstNumber = Convert.ToInt32(this.FirstOperand);


                secondNumber = Convert.ToInt32(this.SecondOperand);


                switch (ActiveOperator)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "X":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            divisionByZero = true;
                        }
                        else
                        {
                            result = firstNumber / secondNumber;
                        }
                        break;
                }

                if (divisionByZero)
                {
                    ResultTextBox.Text = "DIV by Zero";
                    this.ActiveError = true;
                }
                else
                {
                    ResultTextBox.Text = result.ToString();
                }
            }
            
            
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.ClearButton_Click(sender, e);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if(ResultTextBox.Text.Length == 1)
            {
                ResultTextBox.Text = "0";
            }
            else if(ResultTextBox.Text.Length > 1)
            {
                ResultTextBox.Text = ResultTextBox.Text.Remove(ResultTextBox.Text.Length - 1);
            }
        }
    }
}
