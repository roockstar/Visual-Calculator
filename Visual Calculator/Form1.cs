using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWasClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string output;
            if (this.is_operator(btn.Text))
            {
                output = " " + btn.Text + " ";
            }
            else
            {
                output = btn.Text;
            }

            updateDisplay(output);

        }
        private void updateDisplay(string update, Boolean replace = false)
        {
            if (display.Text == "0" || replace)
            {
                display.Text = update;
            }
            else
            {
                display.Text += update;
            }

        }
        private void addToScreenClicked(object sender, EventArgs e)
        {
            updateDisplay(Convert.ToString(numericUpDown1.Value));
        }

        public bool is_operator(string thing)
        {
            string[] operands = new String[] { "+", "-", "^", "*", "/" };
            return operands.Contains(thing);
        }

        private void calculateBtn(object sender, EventArgs e)
        {
            String input = display.Text;
            if (input.Contains('^'))
            {
                int index = input.IndexOf('^');
                try
                {
                    double num1 = Convert.ToDouble(input.Substring(0, index));
                    double num2 = Convert.ToDouble(input.Substring(index + 1));
                    display.Text = Convert.ToString(Math.Pow(num1, num2));
                }
                catch (Exception error)
                {
                    MessageBox.Show("Die Eingabe konnte nicht verarbeitet werden");
                }
            }
            else
            {
                try
                {
                    var something = new DataTable().Compute(input, null);
                    display.Text = Convert.ToString(something);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Die Eingabe konnte nicht verarbeitet werden");
                }
            }

        }


        public void deleteWasClicked(object sender, EventArgs e)
        {
            bool actually_deleted_something = false;
            while (display.Text.Length > 0)
            {
                string nextChar = display.Text.Substring(display.Text.Length - 1);
                if (nextChar != " ")
                {
                    if (actually_deleted_something)
                    {
                        break;
                    }
                    actually_deleted_something = true;
                }
                display.Text = display.Text.Substring(0, display.Text.Length - 1);
            }


            if (display.Text.Length == 0)
            {
                display.Text = "0";
            }
        }

    }
}
