using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormHomework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getResultButton_Click(object sender, EventArgs e)
        {
            double operand1 = double.Parse(operand1TextBox.Text);
            double operand2 = double.Parse(operand2TextBox.Text);
            int index = listBox1.SelectedIndex;
            double result;
            if (index == 0)
                result = operand1 + operand2;
            else if (index == 1)
                result = operand1 - operand2;
            else if (index == 2)
                result = operand1 * operand2;
            else
                result = operand1 / operand2;
            MessageBox.Show($"result: {result}");
        }

    }
}
