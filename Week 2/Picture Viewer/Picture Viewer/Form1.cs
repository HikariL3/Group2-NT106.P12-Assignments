using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_Viewer
{ 
    public partial class Form1 : Form
    {
        string imgdr = "";
        float zoomFactor = 1.0f;
        Image originalImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            try
            {
                var fld = new FolderBrowserDialog();
                if(fld.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                {
                    imgdr = fld.SelectedPath;
                    textBox1.Text = imgdr;
                    var dinfo = new DirectoryInfo(imgdr);
                    var files = dinfo.GetFiles().Where(a => (a.Extension.Equals(".jpg") || a.Extension.Equals(".png") || a.Extension.Equals(".jpeg") || a.Extension.Equals(".bmp") || a.Extension.Equals(".ico")));
                    foreach (var image in files)
                    {
                        imgList.Items.Add(image.Name);
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi kìa :D", ex.Message);
            }
        }

        private void imgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedimg = imgList.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(selectedimg) && !string.IsNullOrEmpty(imgdr))
                {
                    var fullpath = Path.Combine(imgdr, selectedimg);
                    originalImage = Image.FromFile(fullpath);
                    pictureBox1.Image = new Bitmap(originalImage);
                    zoomFactor = 1.0f;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi kìa :D",ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Chọn ảnh đi rồi tính sau, lmao");
                return;  
            }
            if (imgList.SelectedIndex == 0)
            {
                imgList.SelectedIndex = imgList.Items.Count - 1;
            }
            else 
                imgList.SelectedIndex--;
            imgList_SelectedIndexChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Chọn ảnh đi rồi dùng nút này ha .-.");
                return;  
            }
            if (imgList.SelectedIndex == imgList.Items.Count - 1)
            {
                imgList.SelectedIndex = 0;
            }
            else
                imgList.SelectedIndex++;
            imgList_SelectedIndexChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                MessageBox.Show("Chọn ảnh đi rồi mới xoay được chứ, lmao");
            else
            {
                pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox1.Refresh();
            }
        }

        private void ApplyZoom()
        {
            if (originalImage != null)
            {
                int newWidth = (int)(originalImage.Width * zoomFactor);
                int newHeight = (int)(originalImage.Height * zoomFactor);
                Bitmap bmp = new Bitmap(originalImage, newWidth, newHeight);
                pictureBox1.Image = bmp;  // Update the PictureBox with the scaled image
            }
        }

            private void button4_Click(object sender, EventArgs e) //zoom in 
        {
            if (originalImage != null)
            {
                zoomFactor += 0.1f;  // Increase zoom factor
                ApplyZoom();
            }
            else
                MessageBox.Show("Chọn ảnh đi rồi zoom sau, sao vội thế .-.");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e) 
        {
            if (originalImage != null && zoomFactor > 0.1f)  
            {
                zoomFactor -= 0.1f;  
                ApplyZoom();
            }
            else
                MessageBox.Show("Chọn ảnh đi rồi zoom sau, vội gì .-.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            zoomFactor = 1.0f;
            imgList.ClearSelected();
            textBox1.Text = string.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này chưa được code, nút đó chỉ được thêm cho đẹp chứ tôi chả biết nó tính năng gì :(");
        }
    }
}
