using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        string currentDir = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                var fb = new FolderBrowserDialog();
                if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentDir = fb.SelectedPath;
                    textBoxDirectory.Text = currentDir;


                    var dirInfo = new  DirectoryInfo(currentDir);
                    var files = dirInfo.GetFiles().Where(c => (c.Extension.Equals(".jpg") || c.Extension.Equals(".jpeg") || c.Extension.Equals(".bmp") || c.Extension.Equals(".png")));
                    foreach (var image in files)
                    {
                        listBoxImages.Items.Add(image.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message + " " + ex.Source);
                
            }
        }

        private void listBoxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedImage = listBoxImages.SelectedItems[0].ToString();
                if(!string.IsNullOrEmpty(selectedImage) && !string.IsNullOrEmpty(currentDir))
                {
                    var fullPath = Path.Combine(currentDir, selectedImage);
                    pictureBoxImagePreview.Image = Image.FromFile(fullPath); 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
