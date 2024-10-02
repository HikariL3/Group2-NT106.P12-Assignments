using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SocketChat
{
    public partial class Server : Form
    {
        private UdpClient udpServer;
        private bool started = false;
        private int _port = 11000;
        private static readonly int _buff_size = 2048;
        private byte[] _buffer;
        private IPEndPoint clientEndPoint;
        private UdpClient udpClient;

        public Server()
        {
            InitializeComponent();
            udpServer = new UdpClient(_port);
            _buffer = new byte[_buff_size];
            udpClient = new UdpClient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (started)
                {
                    started = false;
                    button2.Text = "Listen on port 11000";
                    udpServer.Close();
                }
                else
                {
                    button2.Text = "Listening on port 11000";
                    listen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listen()
        {
            started = true;
            UpdateChatHistoryThreadSafe("Start listening at ");
            udpServer.BeginReceive(OnReceive, null);
        }

        private void OnReceive(IAsyncResult ar)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] receivedBytes = udpServer.EndReceive(ar, ref remoteEndPoint);
            clientEndPoint = remoteEndPoint;
            string receivedData = Encoding.UTF8.GetString(receivedBytes);
            if (receivedData.StartsWith("SEND_FILE"))
            {
                string fileName = receivedData.Substring(9);
                ReceiveFile(fileName);
            }
            else
            {
                UpdateChatHistoryThreadSafe($"Received from {remoteEndPoint}: {receivedData}");
            }
            udpServer.BeginReceive(OnReceive, null);
        }

        private void ReceiveFile(string fileName)
        {
            byte[] fileData = ReceiveVarData(clientEndPoint);
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(fileData, 0, fileData.Length);
            }
            UpdateChatHistoryThreadSafe($"File received: {fileName}\n");
        }

        private byte[] ReceiveVarData(IPEndPoint remoteEndPoint)
        {
            byte[] dataSizeBuffer = new byte[4];
            EndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            int bytesReceived = udpServer.Client.ReceiveFrom(dataSizeBuffer, ref sender);
            if (bytesReceived < 4)
            {
                throw new Exception("Failed to receive data size.");
            }

            int size = BitConverter.ToInt32(dataSizeBuffer, 0);
            byte[] data = new byte[size];
            int total = 0;

            while (total < size)
            {
                byte[] tempBuffer = new byte[size - total];
                int received = udpServer.Client.ReceiveFrom(tempBuffer, ref sender);
                Array.Copy(tempBuffer, 0, data, total, received);
                total += received;
            }

            return data;
        }

        private void SendFileToClient(string filePath, string fileName, IPEndPoint clientEndPoint)
        {
            try
            {
                string command = "SEND_FILE" + fileName;
                byte[] commandBytes = Encoding.UTF8.GetBytes(command);
                udpClient.Send(commandBytes, commandBytes.Length, clientEndPoint);
                byte[] fileData = File.ReadAllBytes(filePath);
                SendVarData(fileData, clientEndPoint);
                UpdateChatHistoryThreadSafe($"File sent: {fileName} to {clientEndPoint}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending file: {ex.Message}");
            }
        }

        private void SendVarData(byte[] data, IPEndPoint clientEndPoint)
        {
            byte[] dataSize = BitConverter.GetBytes(data.Length);
            udpClient.Send(dataSize, dataSize.Length, clientEndPoint);
            udpClient.Send(data, data.Length, clientEndPoint);
        }

        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                var d = new Action<string>(UpdateChatHistoryThreadSafe);
                richTextBox1.Invoke(d, text);
            }
            else
            {
                richTextBox1.Text += text + Environment.NewLine;
            }
        }

        private void SendFile_Click(object sender, EventArgs e)
        {
            if (clientEndPoint == null)
            {
                MessageBox.Show("No client connected. Please wait for a client to send a message first.");
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                SendFileToClient(filePath, fileName, clientEndPoint);
            }
        }
    }
}
