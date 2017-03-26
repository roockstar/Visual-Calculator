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
    }
}
