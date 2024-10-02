using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class ClientForm : Form
    {
        private Socket clientSocket = null;
        public ClientForm()
        {
            InitializeComponent();
            clientSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public void SendFile(string filePath)
        {
            try
            {
                if (clientSocket.Connected) // Kiểm tra socket đã kết nối chưa
                {
                    byte[] fileData = File.ReadAllBytes(filePath);

                    string fileName = Path.GetFileName(filePath);
                    string header = $"FILE:{fileName}:{fileData.Length}";

                    byte[] headerData = Encoding.UTF8.GetBytes(header);
                    clientSocket.Send(headerData);  // Gửi header

                    clientSocket.Send(fileData);    // Gửi file

                    MessageBox.Show("File sent successfully!");
                }
                else
                {
                    MessageBox.Show("Socket is not connected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending file: " + ex.Message);
            }
        }


        public void SendMessage(string message)
        {
            try
            {
                string header = "TEXT:" + message.Length;
                byte[] headerData = Encoding.UTF8.GetBytes(header);

                clientSocket.Send(headerData);

                byte[] messageData = Encoding.UTF8.GetBytes(message);
                clientSocket.Send(messageData);

                MessageBox.Show("Message sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress serverIp = IPAddress.Parse(textBox1.Text);
                int serverPort = int.Parse(textBox2.Text);
                IPEndPoint serverEp = new IPEndPoint(serverIp, serverPort);
                clientSocket.Connect(serverEp);
                richTextBox1.Text += "Connected to " + serverEp.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientSocket.Connected)
                {
                    clientSocket.Send(Encoding.UTF8.GetBytes(richTextBox2.Text));  // Gửi tin nhắn
                    richTextBox2.Text = "";  // Xóa nội dung sau khi gửi
                }
                else
                {
                    MessageBox.Show("Socket is not connected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending message: " + ex.Message);
            }
        }

    }
}
