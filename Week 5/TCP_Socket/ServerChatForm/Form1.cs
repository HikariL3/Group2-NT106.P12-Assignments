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

namespace ServerChatForm
{
    public partial class Server : Form
    {
        private Thread listenThread;
        private TcpListener tcpListener;
        private bool stopChatServer = true;
        private readonly int _serverPort = 8000;
        private Dictionary<string, TcpClient> dict = new Dictionary<string, TcpClient>();
        private Thread replyThread;

        public Server()
        {
            InitializeComponent();
        }

        private async void HandleClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string message;
                while ((message = await reader.ReadLineAsync()) != null)
                {
                    string[] parts = message.Split(';');

                    if (parts[0] == "TEXT")
                    {
                        string recipient = parts[1];
                        string text = parts[2];
                        HandleTextMessage(recipient, text);
                    }
                    else if (parts[0] == "FILE_TRANSFER")
                    {
                        string recipient = parts[1];
                        string fileName = parts[2];
                        await ReceiveFileAsync(stream, recipient, fileName);
                    }
                }
            }
        }

        private async Task ReceiveFileAsync(NetworkStream stream, string recipientUsername, string fileName)
        {
            string savePath = Path.Combine(Application.StartupPath, "ReceivedFiles", fileName);
            Directory.CreateDirectory(Path.GetDirectoryName(savePath));

            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await fs.WriteAsync(buffer, 0, bytesRead);
                }
            }

            NotifyFileReceived(recipientUsername, fileName);
        }
        private void ReceiveFile(NetworkStream stream, string senderUsername, string fileName)
        {
            try
            {
                string savePath = Path.Combine(Application.StartupPath, "ReceivedFiles", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Nhận file từ stream
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, bytesRead);
                    }
                }

                // Thông báo về file nhận thành công
                BroadcastMessage(senderUsername, $"File received: {fileName}");
                UpdateChatHistoryThreadSafe($"[{DateTime.Now:MM/dd/yyyy h:mm tt}] {senderUsername} sent a file: {fileName}\n"); // Hiển thị trên server
            }
            catch (Exception ex)
            {
                UpdateChatHistoryThreadSafe($"[{DateTime.Now:MM/dd/yyyy h:mm tt}] Error receiving file from {senderUsername}: {ex.Message}\n");
            }
        }


        private void BroadcastMessage(string senderUsername, string message)
        {
            foreach (var pair in dict)
            {
                string recipientUsername = pair.Key;
                TcpClient client = pair.Value;
                try
                {
                    StreamWriter sw = new StreamWriter(client.GetStream());
                    sw.WriteLine(message);
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    UpdateChatHistoryThreadSafe($"Error sending to {recipientUsername}: {ex.Message}\n");
                }
            }
        }


        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(new IPEndPoint(IPAddress.Parse(textBox1.Text), _serverPort));
                tcpListener.Start();

                while (!stopChatServer)
                {
                    TcpClient _client = tcpListener.AcceptTcpClient();

                    StreamReader sr = new StreamReader(_client.GetStream());
                    StreamWriter sw = new StreamWriter(_client.GetStream());
                    sw.AutoFlush = true;
                    string username = sr.ReadLine();
                    if (string.IsNullOrEmpty(username))
                    {
                        sw.WriteLine("Please pick a username");
                        _client.Close();
                    }
                    else
                    {
                        if (!dict.ContainsKey(username))
                        {
                            Thread clientThread = new Thread(() => this.ClientRecv(username, _client));
                            dict.Add(username, _client);
                            clientThread.Start();
                        }
                        else
                        {
                            sw.WriteLine("Username already exist, pick another one");
                            _client.Close();
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClientRecv(string username, TcpClient tcpClient)
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopChatServer)
                {
                    Application.DoEvents();
                    string message = sr.ReadLine();

                    if (string.IsNullOrEmpty(message))
                    {
                        continue;
                    }

                    string[] parts = message.Split('|');
                    if (parts.Length < 3)
                    {
                        continue;
                    }

                    string messageType = parts[0];
                    string recipient = parts[1];
                    string text = parts[2];

                    if (messageType == "TEXT")
                    {
                        string formattedMsg = $"[{DateTime.Now:MM/dd/yyyy h:mm tt}] {username}: {text}";
                        BroadcastMessage(username, formattedMsg);
                        UpdateChatHistoryThreadSafe($"{formattedMsg}\n");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateChatHistoryThreadSafe($"[{DateTime.Now:MM/dd/yyyy h:mm tt}] Error: {ex.Message}\n");
            }
            finally
            {
                tcpClient.Close();
                sr.Close();
                dict.Remove(username);
                UpdateChatHistoryThreadSafe($"[{DateTime.Now:MM/dd/yyyy h:mm tt}] {username} has disconnected.\n");
            }
        }
        private void HandleFileTransfer(string senderUsername, string receiverUsername, string fileName, TcpClient senderClient)
        {
            try
            {
                TcpClient receiverClient;
                if (dict.TryGetValue(receiverUsername, out receiverClient))
                {
                    StreamWriter swReceiver = new StreamWriter(receiverClient.GetStream());
                    swReceiver.WriteLine($"[{DateTime.Now:MM/dd/yyyy h:mm tt}] {senderUsername} is sending file: {fileName}");
                    swReceiver.AutoFlush = true;

                    string savePath = Path.Combine(Application.StartupPath, "ReceivedFiles", $"{DateTime.Now:yyyyMMddHHmmss}_{fileName}");
                    Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                    using (FileStream fs = File.Create(savePath))
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        NetworkStream ns = senderClient.GetStream();

                        // Đọc dữ liệu nhị phân từ client
                        while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fs.Write(buffer, 0, bytesRead);
                        }
                    }

                    string successMsg = $"[{DateTime.Now:MM/dd/yyyy h:mm tt}] File transfer complete: {fileName}\n";
                    StreamWriter swSender = new StreamWriter(senderClient.GetStream());
                    swSender.WriteLine(successMsg);
                    swSender.AutoFlush = true;
                    swReceiver.WriteLine(successMsg);
                }
                else
                {
                    StreamWriter sw = new StreamWriter(senderClient.GetStream());
                    sw.WriteLine($"[{DateTime.Now:MM/dd/yyyy h:mm tt}] Error: User {receiverUsername} not found. File transfer failed.\n");
                    sw.AutoFlush = true;
                }
            }
            catch (Exception ex)
            {
                UpdateChatHistoryThreadSafe($"Error during file transfer: {ex.Message}\n");
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

        private async void HandleTextMessage(string recipientUsername, string text)
        {
            TcpClient recipientClient;
            if (dict.TryGetValue(recipientUsername, out recipientClient))
            {
                StreamWriter sw = new StreamWriter(recipientClient.GetStream());
                await sw.WriteLineAsync($"[{DateTime.Now:MM/dd/yyyy h:mm tt}] {text}");
                sw.AutoFlush = true;
            }
        }

        private void NotifyFileReceived(string recipientUsername, string fileName)
        {
            UpdateChatHistoryThreadSafe($"[{DateTime.Now:MM/dd/yyyy h:mm tt}] File '{fileName}' has been received by {recipientUsername}.\n");
        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (stopChatServer)
            {
                stopChatServer = false;
                listenThread = new Thread(this.Listen);
                listenThread.Start();
                MessageBox.Show(@"Start listening for incoming connections");
                button1.Text = @"Stop";
            }
            else
            {
                stopChatServer = true;
                button1.Text = @"Start listening";
                tcpListener.Stop();
                listenThread = null;
            }
        }
    }
}
