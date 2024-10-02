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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketChat
{
    public partial class Server : Form
    {
        private Socket listener = null;
        private bool started = false;
        private int _port = 11000;
        private static int _buff_size = 2048;
        private byte[] _buffer = new byte[_buff_size];
        private Thread serverThread = null;
        private delegate void SafeCallDelegate(string text);
        public Server()
        {
            InitializeComponent();
            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        private void readFromSocket(Socket clientSocket)
        {
            try
            {
                while (started && clientSocket != null)
                {
                    byte[] headerBuffer = new byte[1024];
                    int headerBytes = clientSocket.Receive(headerBuffer);
                    string header = Encoding.UTF8.GetString(headerBuffer, 0, headerBytes);
                    string[] headerParts = header.Split(':');
                    string dataType = headerParts[0];

                    if (dataType == "FILE")
                    {
                        string fileName = headerParts[1];
                        int fileSize = int.Parse(headerParts[2]);

                        ReceiveFile(clientSocket, fileName, fileSize);
                    }
                    else if (dataType == "TEXT")
                    {
                        int messageSize = int.Parse(headerParts[1]);
                        ReceiveTextMessage(clientSocket, messageSize);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateChatHistoryThreadSafe("Error receiving data: " + ex.Message);
            }
        }

        void ReceiveFile(Socket clientSocket, string fileName, int fileSize)
        {
            try
            {
                string savePath = @"C:\path\to\save\" + fileName;

                using (FileStream fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] fileBuffer = new byte[_buff_size];
                    int totalReceived = 0;

                    while (totalReceived < fileSize)
                    {
                        int bytesRead = clientSocket.Receive(fileBuffer);
                        totalReceived += bytesRead;

                        fileStream.Write(fileBuffer, 0, bytesRead);
                    }
                }

                UpdateChatHistoryThreadSafe("File received and saved at: " + savePath);
            }
            catch (Exception ex)
            {
                UpdateChatHistoryThreadSafe("Error receiving file: " + ex.Message);
            }
        }

        void ReceiveTextMessage(Socket clientSocket, int messageSize)
        {
            try
            {
                byte[] messageBuffer = new byte[messageSize];
                int bytesRead = clientSocket.Receive(messageBuffer);
                string message = Encoding.UTF8.GetString(messageBuffer, 0, bytesRead);

                UpdateChatHistoryThreadSafe("Received message: " + message);
            }
            catch (Exception ex)
            {
                UpdateChatHistoryThreadSafe("Error receiving message: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (started)
                {
                    started = false;
                    Click.Text = "Listen";
                    serverThread = null;
                    listener.Close();
                }
                else
                {
                    serverThread = new Thread(this.listen);
                    serverThread.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listen()
        {
            listener.Bind(new IPEndPoint(IPAddress.Parse(IP_Address.Text), _port));
            listener.Listen(10);
            started = true;
            UpdateChatHistoryThreadSafe("Start listening");
            while (started)
            {
                Socket clientSocket = listener.Accept();
                UpdateChatHistoryThreadSafe("Accept connection from " + clientSocket.RemoteEndPoint.ToString());
                if (clientSocket != null && clientSocket.Connected)
                {
                    (new Thread(() => this.readFromSocket(clientSocket))).Start();
                }
            }
        }

        void SendFile(string filePath)
        {
            try
            {
                if (listener.Connected) // Kiểm tra socket đã kết nối chưa
                {
                    byte[] fileData = File.ReadAllBytes(filePath);

                    string fileName = Path.GetFileName(filePath);
                    string header = $"FILE:{fileName}:{fileData.Length}";

                    byte[] headerData = Encoding.UTF8.GetBytes(header);
                    listener.Send(headerData);   // Gửi header

                    listener.Send(fileData);     // Gửi file

                    UpdateChatHistoryThreadSafe("File sent successfully!");
                }
                else
                {
                    UpdateChatHistoryThreadSafe("Socket is not connected.");
                }
            }
            catch (Exception ex)
            {
                UpdateChatHistoryThreadSafe("Error sending file: " + ex.Message);
            }
        }



        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (Message.InvokeRequired)
            {
                var d = new SafeCallDelegate(UpdateChatHistoryThreadSafe);
                Message.Invoke(d, new object[] { text });

            }
            else
            {
                Message.Text += text + "\n";
            }
        }

        private void Send_File_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SendFile(openFileDialog.FileName);
                }
            }
        }
    }
}
