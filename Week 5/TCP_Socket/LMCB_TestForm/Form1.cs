using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LMCB_TestForm
{
    public partial class Client : Form
    {
        private TcpClient tcpClient;
        private StreamReader sReader;
        private StreamWriter sWriter;
        private Thread clientThread;
        private int serverPort = 8000;
        private bool stopTcpClient = true;

        public Client()
        {
            InitializeComponent();
        }

        private void ClientRecv()
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopTcpClient && tcpClient.Connected)
                {
                    Application.DoEvents();
                    string data = sr.ReadLine();
                    if (!string.IsNullOrEmpty(data))
                    {
                        UpdateChatHistoryThreadSafe($"{data}\n");
                    }
                }
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show($"Mất kết nối: {sockEx.Message}");
                tcpClient.Close();
                sr.Close();
            }
        }

        private delegate void SafeCallDelegate(string text);

        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                richTextBox1.Invoke(d, new object[] { text });
            }
            else
            {
                richTextBox1.Text += text;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Thay đổi định dạng tin nhắn để phù hợp với server
                string message = $"TEXT|{textBox3.Text}|{sendMsgTextBox.Text}";
                await sWriter.WriteLineAsync(message);

                // Cập nhật giao diện người dùng
                UpdateChatHistoryThreadSafe($"[Bạn]: {sendMsgTextBox.Text}\n");

                sendMsgTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            // Add any cleanup code here if needed
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                stopTcpClient = false;
                this.tcpClient = new TcpClient();
                this.tcpClient.Connect(new IPEndPoint(IPAddress.Parse(textBox2.Text), serverPort));
                this.sWriter = new StreamWriter(tcpClient.GetStream());
                this.sWriter.AutoFlush = true;
                sWriter.WriteLine(this.textBox1.Text);
                clientThread = new Thread(this.ClientRecv);
                clientThread.Start();
                MessageBox.Show("Connected");
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message, "Network error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Send_File_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        string fileName = Path.GetFileName(filePath);

                        // Notify the server about the incoming file
                        await sWriter.WriteLineAsync($"FILE_TRANSFER;{textBox3.Text};{fileName}");

                        // Send the file content
                        using (FileStream fs = File.OpenRead(filePath))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await tcpClient.GetStream().WriteAsync(buffer, 0, bytesRead);
                            }
                        }

                        UpdateChatHistoryThreadSafe($"File sent: {fileName}\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}