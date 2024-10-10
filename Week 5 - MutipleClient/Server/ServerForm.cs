using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;

namespace Server
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Connect();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            listMessage.Items.Add(txtMessage.Text);
            txtMessage.Clear();
        }

        int localPort = 9999;

        IPEndPoint localEP;
        Socket server;

        List<Socket> clientList;
        static int size = 1024;
        byte[] receiveBuffer = new byte[size];

        void Connect()
        {
            clientList = new List<Socket>();
            localEP = new IPEndPoint(IPAddress.Any, localPort);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(localEP);

            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        AddMessage("Đã kết nối với client!", client);
                        clientList.Add(client);

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }        
                catch
                {
                    localEP = new IPEndPoint(IPAddress.Any, localPort);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });
            Listen.IsBackground = true;
            Listen.Start(); 
        }
 
        void Close()
        {
            server.Close();
        }

        void Send(Socket client)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                //client.Send(Serialize(txtMessage.Text));
                SendText(client, txtMessage.Text);
            }
        }

        void Receive(object obj)
        {
            Socket client = obj as Socket;
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

                        foreach (Socket item in clientList)
                        {
                            if (item != null && item != client)
                                SendText(item, message);
                        }

                        AddMessage(message, client);
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
                        AddMessage(message,client);

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
                listMessage.Items.Add($"---------Bị mất kết nối với {client.RemoteEndPoint}---------");
                clientList.Remove(client);
                client.Close();
                MessageBox.Show("Kết nối bị ngắt sau khi gửi tệp, hãy kết nối lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void ReceiveFile(Socket client)
        {
            byte[] fileNameLengthBytes = new byte[4];
            client.Receive(fileNameLengthBytes, 0, 4, SocketFlags.None);
            int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0);


            byte[] fileNameBytes = new byte[fileNameLength];
            client.Receive(fileNameBytes, 0, fileNameLength, SocketFlags.None);
            string fileName = System.Text.Encoding.ASCII.GetString(fileNameBytes);


            listMessage.Items.Add(fileName);

            byte[] buffer = new byte[1024];
            int receivedBytes = 0;
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                while ((receivedBytes = client.Receive(buffer, 0, buffer.Length, SocketFlags.None)) > 0)
                {
                    fs.Write(buffer, 0, receivedBytes);
                }
            }
        }
        void AddMessage(string s, Socket client)
        {
            string msg = string.Format($"From {client.RemoteEndPoint}: {s}");
            listMessage.Items.Add(msg);
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

        private void ServerForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void sendFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileOpen.FileName;
                byte[] fileData = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);
                byte[] fileNameBytes = Encoding.ASCII.GetBytes(fileName);

                //SendText(client, fileName);
                //SendFile(client, filePath, fileName);
                foreach(Socket item in clientList)
                {
                    SendFile(item, filePath, fileName);
                }

                listMessage.Items.Add($"Đã gửi file: {fileName}");
            }
        }

        static void SendText(Socket socket, string text)
        {
            string header = "text";
            byte[] headerBuffer = Encoding.ASCII.GetBytes(header);

            socket.Send(BitConverter.GetBytes(headerBuffer.Length), 0, 4, SocketFlags.None);
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
