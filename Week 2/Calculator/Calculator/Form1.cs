using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        decimal res = 0;
        string opr = "";
        bool check = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e) //CE button
        {
            textBox1.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || check)
                textBox1.Text = "";
            check = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + button.Text;
            }
            else
                textBox1.Text = textBox1.Text + button.Text;
        }

        private void opr_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (res != 0)
            {
                equal.PerformClick();
                opr = button.Text;
                current.Text = res + " " + opr;
                check = true;
            }
            else
            {
                opr = button.Text;
                res = decimal.Parse(textBox1.Text);
                current.Text = res + " " + opr;
                check = true;
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            res = 0;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            switch (opr)
            {
                case "+":
                    textBox1.Text = (res + decimal.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (res - decimal.Parse(textBox1.Text)).ToString();
                    break;
                case "×":
                    textBox1.Text = (res * decimal.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                        if (double.Parse(textBox1.Text) == 0)
                        {
                            textBox1.Text = "Cannot divide by 0";
                            return;
                        }
                        textBox1.Text = (res / decimal.Parse(textBox1.Text)).ToString();
                        break;
                default:
                    break;
            }
            res = decimal.Parse(textBox1.Text);
            res = Math.Round(res, 2);
            current.Text = "";
        }

        private void sign_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("-"))
            {
                textBox1.Text = "-" + textBox1.Text;
            }
            else
                textBox1.Text = textBox1.Text.Trim('-');
        }

        private void percent_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text)/100).ToString();
        }
    }
}
