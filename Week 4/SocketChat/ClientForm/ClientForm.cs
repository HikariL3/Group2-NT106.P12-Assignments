using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class ClientForm : Form
    {
        private UdpClient udpClient;
        private static int _buff_size = 2048;
        private IPEndPoint serverEndPoint;

        public ClientForm()
        {
            InitializeComponent();
            udpClient = new UdpClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress serverIp = IPAddress.Parse(textBox1.Text);
                int serverPort = int.Parse(textBox2.Text);
                serverEndPoint = new IPEndPoint(serverIp, serverPort);
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 0));
                richTextBox1.Text += "Connected to " + serverEndPoint.ToString() + "\n";
                udpClient.BeginReceive(OnReceive, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] receivedBytes = udpClient.EndReceive(ar, ref remoteEndPoint);
            string receivedData = Encoding.UTF8.GetString(receivedBytes);
            if (receivedData.StartsWith("SEND_FILE"))
            {
                string fileName = receivedData.Substring(9);
                ReceiveFile(remoteEndPoint, fileName);
            }
            else
            {
                UpdateChatHistoryThreadSafe(receivedData);
            }
            udpClient.BeginReceive(OnReceive, null);
        }

        private void UpdateChatHistoryThreadSafe(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(UpdateChatHistoryThreadSafe), text);
            }
            else
            {
                richTextBox1.AppendText(text + "\n");
            }
        }

        private void ReceiveFile(IPEndPoint remoteEndPoint, string fileName)
        {
            byte[] fileData = ReceiveVarData(remoteEndPoint);
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(fileData, 0, fileData.Length);
            }
            UpdateChatHistoryThreadSafe($"File received: {fileName}\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] dataToSend = Encoding.UTF8.GetBytes(richTextBox2.Text);
                udpClient.Send(dataToSend, dataToSend.Length, serverEndPoint);
                richTextBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Send_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);
                SendFileToServer(filePath, fileName);
            }
        }

        private void SendFileToServer(string filePath, string fileName)
        {
            try
            {
                string command = "SEND_FILE" + fileName;
                udpClient.Send(Encoding.UTF8.GetBytes(command), command.Length, serverEndPoint);
                byte[] fileData = File.ReadAllBytes(filePath);
                SendVarData(fileData);
                richTextBox1.AppendText($"File sent: {fileName}\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendVarData(byte[] data)
        {
            byte[] dataSize = BitConverter.GetBytes(data.Length);
            udpClient.Send(dataSize, dataSize.Length, serverEndPoint);
            udpClient.Send(data, data.Length, serverEndPoint);
        }

        private byte[] ReceiveVarData(IPEndPoint remoteEndPoint)
        {
            byte[] dataSizeBuffer = new byte[4];
            udpClient.Receive(ref remoteEndPoint);
            udpClient.Receive(ref remoteEndPoint);

            int size = BitConverter.ToInt32(dataSizeBuffer, 0);
            byte[] data = new byte[size];
            int total = 0;

            while (total < size)
            {
                byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                Array.Copy(receivedData, 0, data, total, receivedData.Length);
                total += receivedData.Length;
            }

            return data;
        }
    }
}
