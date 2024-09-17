using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string calTotal;
        int num1, num2;
        String option;
        int result;

        private void button1_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "7";
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "9";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "1";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "2";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "0";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "3";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "6";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + "8";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + ".";
        }

        private void button17_Click(object sender, EventArgs e)
        {

            option = "+";
            num1 = int.Parse(hienthi1.Text);
            hienthi1.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            option = "-";
            num1 = int.Parse(hienthi1.Text);
            hienthi1.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            option = "*";
            num1 = int.Parse(hienthi1.Text);
            hienthi1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            option = "/";
            num1 = int.Parse(hienthi1.Text);
            hienthi1.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
                num2 = int.Parse(hienthi1.Text);

                if (option == "+")
                    result = num1 + num2;

                if (option == "-")
                    result = num1 - num2;

                if (option == "*")
                    result = num1 * num2;

                if (option == "/")
                {
                    if (num2 == 0)
                    {
                        hienthi1.Text = "Cannot divide by zero";
                        return;
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                }

                hienthi1.Text = result + "";
            }

        private void button7_Click(object sender, EventArgs e)
        {
            hienthi1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
