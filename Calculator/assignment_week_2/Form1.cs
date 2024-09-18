using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_week_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }





        float data1, data2;
        string phepTinh = null;
        bool item = false;
        private void button0_Click(object sender, EventArgs e)
        {
            if((phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            if(hienthi1.Text != "0")
            {
                hienthi1.Text = hienthi1.Text + "0";
            }
            item = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "1";
            item = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "2";
            item = false;   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "3";
            item = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "4";
            item = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "5";
            item = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "6";
            item = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "7";
            item = false;   
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "8";
            item = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (hienthi1.Text == "0" || (phepTinh != null && item == true))
            {
                hienthi1.Clear();
            }
            hienthi1.Text = hienthi1.Text + "9";
            item = false;
        }

        private void buttonCham_Click(object sender, EventArgs e)
        {
            hienthi1.Text = hienthi1.Text + ".";
        }

        private void buttonXoaHet_Click(object sender, EventArgs e)
        {
            hienthi1.Clear();
            hienthi2.Clear();
            hienthi1.Text = hienthi1.Text + "0";
            phepTinh = null;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if(hienthi1.Text != "0")
            {
                hienthi1.Clear();
                hienthi1.Text = "0"; 
            }
        }

        private void buttonBang_Click(object sender, EventArgs e)
        {
            if(phepTinh == "cong")
            {
                data2 = data1 + float.Parse(hienthi1.Text);
                hienthi2.Text = hienthi2.Text + hienthi1.Text + " = ";
                hienthi1.Text = data2.ToString();
            }
            if (phepTinh == "tru")
            {
                data2 = data1 - float.Parse(hienthi1.Text);
                hienthi2.Text = hienthi2.Text + hienthi1.Text + " = ";
                hienthi1.Text = data2.ToString();
            }
            if (phepTinh == "nhan")
            {
                data2 = data1 * float.Parse(hienthi1.Text);
                hienthi2.Text = hienthi2.Text + hienthi1.Text + " = ";
                hienthi1.Text = data2.ToString();
            }
            if (phepTinh == "chia")
            {
                if(float.Parse(hienthi1.Text) == 0)
                {
                    hienthi1.Text = "Cannot divide by zero";
                }
                else
                {
                    data2 = data1 / float.Parse(hienthi1.Text);
                    hienthi2.Text = hienthi2.Text + hienthi1.Text + " = ";
                    hienthi1.Text = data2.ToString();
                }
            }
            phepTinh = null;
        }

        private void buttonCong_Click(object sender, EventArgs e)
        {
            item = true;
            phepTinh = "cong";
            hienthi2.Text = hienthi1.Text + " + ";
            data1 = float.Parse(hienthi1.Text);
        }

        private void buttonTru_Click(object sender, EventArgs e)
        {
            item = true;
            phepTinh = "tru";
            hienthi2.Text = hienthi1.Text + " - ";
            data1 = float.Parse(hienthi1.Text);
        }

        private void buttonNhan_Click(object sender, EventArgs e)
        {
            item = true;
            phepTinh = "nhan";
            hienthi2.Text = hienthi1.Text + " * ";
            data1 = float.Parse(hienthi1.Text);
        }

        private void buttonChia_Click(object sender, EventArgs e)
        {
            item = true;
            phepTinh = "chia";
            hienthi2.Text = hienthi1.Text + " / ";
            data1 = float.Parse(hienthi1.Text);
        }
    }
}
