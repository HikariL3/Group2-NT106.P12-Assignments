using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        string ipServer = "127.0.0.2";
        int portServer = 9999;

        IPEndPoint serverEP;
        Socket client;

        static int size = 1024 * 5000;
        byte[] receiveBuffer = new byte[size];

        void Connect()
        {
            serverEP = new IPEndPoint(IPAddress.Parse(ipServer), portServer);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                client.Connect(serverEP); // Kết nối đến server
                listMessage.Items.Add("Đã kết nối với server!");
            }
            catch
            {
                MessageBox.Show("Khong the ket noi server!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        void Send()
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                client.Send(Serialize(txtMessage.Text));
            }  
        }

        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] headerLengthBytes = new byte[4];
                    int headerBytesReceived = client.Receive(headerLengthBytes, 0, 4, SocketFlags.None);
                    int headerLength = BitConverter.ToInt32(headerLengthBytes, 0);
                    if (headerBytesReceived == 0) break;


                    byte[] headerBytes = new byte[headerLength];
                    client.Receive(headerBytes, 0, headerLength, SocketFlags.None);
                    string header = System.Text.Encoding.ASCII.GetString(headerBytes);

                    if (header == "text")
                    {
                        client.Receive(receiveBuffer);
                        string message = (string)Deserialize(receiveBuffer);
                        AddMessage(message);
                        Array.Clear(receiveBuffer, 0, size);
                    }
                    else if (header == "file")
                    {
                        byte[] fileNameLengthBytes = new byte[4];
                        client.Receive(fileNameLengthBytes, 0, 4, SocketFlags.None);
                        int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0);


                        byte[] fileNameBytes = new byte[fileNameLength];
                        client.Receive(fileNameBytes, 0, fileNameLength, SocketFlags.None);
                        string fileName = System.Text.Encoding.ASCII.GetString(fileNameBytes);

                        string message = string.Format($"Đã nhận file: {fileName}");
                        AddMessage(message);

                        byte[] buffer = new byte[1024];
                        int receivedBytes = 0;
                        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                        {
                            while ((receivedBytes = client.Receive(buffer, 0, buffer.Length, SocketFlags.None)) > 0)
                            {
                                fs.Write(buffer, 0, receivedBytes);
                                if (receivedBytes < buffer.Length)
                                    break;
                            }
                        }
                        //client.Shutdown(SocketShutdown.Receive);
                        Array.Clear(buffer, 0, 2024);
                        Array.Clear(fileNameLengthBytes, 0, 4);
                        Array.Clear(fileNameBytes, 0, fileNameLength);
                    }
                }
            }
            catch
            {
                Close();
                //Connect();
                //MessageBox.Show("Kết nối bị ngắt sau khi gửi tệp, hãy kết nối lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        void Close()
        {
            client.Close();
        }

        void AddMessage(string msg)
        {
            listMessage.Items.Add(msg);
            txtMessage.Clear();
        }

        static byte[] Serialize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        static object Deserialize(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            //Send();
            SendText(client, txtMessage.Text);
            AddMessage(txtMessage.Text);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void sendFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            if(fileOpen.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileOpen.FileName;
                byte[] fileData = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);
                byte[] fileNameBytes = Encoding.ASCII.GetBytes(fileName);

                SendFile(client, filePath, fileName);
                AddMessage($"Đã gửi file: {fileName}");
            }
        }
        static void SendText(Socket socket, string text)
        {
            string header = "text";
            byte[] headerBuffer = Encoding.ASCII.GetBytes(header);

            socket.Send(BitConverter.GetBytes(headerBuffer.Length),0,4, SocketFlags.None);
            socket.Send(headerBuffer);

            socket.Send(Serialize(text));
        }

        static void SendFile(Socket socket, string filePath, string fileName)
        {
            string header = "file";
            byte[] headerBuffer = Encoding.UTF8.GetBytes(header);
            socket.Send(BitConverter.GetBytes(headerBuffer.Length), 0, 4, SocketFlags.None);
            socket.Send(headerBuffer);

            byte[] fileNameBuffer = Encoding.UTF8.GetBytes(fileName);
            socket.Send(BitConverter.GetBytes(fileNameBuffer.Length), 0, 4, SocketFlags.None);
            socket.Send(fileNameBuffer);

            socket.SendFile(filePath);
        }
    }
}
