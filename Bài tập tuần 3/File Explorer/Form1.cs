using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace File_Explorer
{
    public partial class File_Explorer : Form
    {
        Stack<string> backStack = new Stack<string>();
        Stack<string> forwardStack = new Stack<string>();
        string currentDirectory;

        public static class FileClipboard
        {
            public static List<string> FilePaths { get; set; } = new List<string>();
            public static bool IsCut { get; set; } = false;
        }
        public void ShowDrives()
        {
            tenFile.BeginUpdate();
            string[] drives = Directory.GetLogicalDrives();
            foreach (string adrive in drives)
            {
                TreeNode tn = new TreeNode(adrive);
                tenFile.Nodes.Add(tn);
            }
            tenFile.EndUpdate();
        }
        private void PopulateTreeView()
        {
            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(@"../..");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                tenFile.Nodes.Add(rootNode);
            }
        }
        public File_Explorer()
        {
            InitializeComponent();
            PopulateTreeView();
            InitializeContextMenu();
            this.tenFile.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.OpenBox.Click += new EventHandler(this.OpenBox_Click);
        }

        private void InitializeContextMenu()
        {
            Option = new ContextMenuStrip();
            Option.Items.Add("Sao chép", null, Copy_Click);
            Option.Items.Add("Cắt", null, Cut_Click);
            Option.Items.Add("Dán", null, Paste_Click);
            Option.Items.Add("Xóa", null, Delete_Click);
            Option.Items.Add("Tạo Thư Mục Mới", null, NewFolder_Click);
            thongTin.ContextMenuStrip = Option;
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {
                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";
                    subSubDirs = subDir.GetDirectories();
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories(subSubDirs, aNode);
                    }

                    nodeToAddTo.Nodes.Add(aNode);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Access to the path {subDir.FullName} is denied: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error accessing directory {subDir.FullName}: {ex.Message}");
                }
            }
        }
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            thongTin.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "Directory"),
              new ListViewItem.ListViewSubItem(item, dir.LastAccessTime.ToShortDateString()) };
                item.SubItems.AddRange(subItems);
                thongTin.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
              new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()) };
                item.SubItems.AddRange(subItems);
                thongTin.Items.Add(item);
            }

            thongTin.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Path.Text = nodeDirInfo.FullName;
            OpenDirectory(nodeDirInfo.FullName);
        }
        private void LoadFilesFromDirectory(string path)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                thongTin.Items.Clear();

                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    ListViewItem item = new ListViewItem(dir.Name, 0);
                    item.SubItems.Add("Directory");
                    item.SubItems.Add(dir.LastAccessTime.ToShortDateString());
                    thongTin.Items.Add(item);
                }

                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    ListViewItem item = new ListViewItem(file.Name, 1);
                    item.SubItems.Add("File");
                    item.SubItems.Add(file.LastAccessTime.ToShortDateString());
                    thongTin.Items.Add(item);
                }

                thongTin.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void OpenDirectory(string path)
        {
            if (!string.IsNullOrEmpty(currentDirectory))
            {
                backStack.Push(currentDirectory);
            }

            LoadFilesFromDirectory(path);
            currentDirectory = path;
            forwardStack.Clear();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (backStack.Count > 0)
            {
                forwardStack.Push(currentDirectory);
                string previousDirectory = backStack.Pop();
                LoadFilesFromDirectory(previousDirectory); 
                currentDirectory = previousDirectory; 
                Path.Text = currentDirectory;
            }
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            if (forwardStack.Count > 0)
            {
                backStack.Push(currentDirectory);
                string nextDirectory = forwardStack.Pop();
                LoadFilesFromDirectory(nextDirectory);
                currentDirectory = nextDirectory;
                Path.Text = currentDirectory;
            }
        }

        private void OpenBox_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowser.SelectedPath;
                    OpenDirectory(selectedPath);
                    tenFile.Nodes.Clear();
                    TreeNode rootNode = new TreeNode(selectedPath);
                    rootNode.Tag = new DirectoryInfo(selectedPath);
                    tenFile.Nodes.Add(rootNode);
                    PopulateTreeViewFromPath(selectedPath);
                }
            }
        }
        private void PopulateTreeViewFromPath(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            TreeNode rootNode = new TreeNode(info.Name);
            rootNode.Tag = info;
            GetDirectories(info.GetDirectories(), rootNode);
            tenFile.Nodes.Add(rootNode);
        }

        private void CopyFiles()
        {
            FileClipboard.FilePaths.Clear();
            foreach (ListViewItem item in thongTin.SelectedItems)
            {
                FileClipboard.FilePaths.Add(item.Tag.ToString());
            }
            FileClipboard.IsCut = false;
        }

        private void CutFiles()
        {
            FileClipboard.FilePaths.Clear();
            foreach (ListViewItem item in thongTin.SelectedItems)
            {
                FileClipboard.FilePaths.Add(item.Tag.ToString());
            }
            FileClipboard.IsCut = true;
        }

        private void PasteFiles(string targetDirectory)
        {
            foreach (var filePath in FileClipboard.FilePaths)
            {
                string fileName = System.IO.Path.GetFileName(filePath);
                string destPath = System.IO.Path.Combine(targetDirectory, fileName);

                if (FileClipboard.IsCut)
                {
                    File.Move(filePath, destPath);
                }
                else
                {
                    File.Copy(filePath, destPath);
                }
            }
            LoadFilesFromDirectory(targetDirectory);
            LoadFilesFromDirectory(targetDirectory);
        }

        private void DeleteFiles()
        {
            foreach (ListViewItem item in thongTin.SelectedItems)
            {
                string filePath = item.Tag.ToString(); 

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else if (Directory.Exists(filePath))
                {
                    Directory.Delete(filePath, true);
                }
            }
            LoadFilesFromDirectory(currentDirectory);
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            CopyFiles();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            CutFiles();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            PasteFiles(currentDirectory);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteFiles();
        }

        private void NewFolder_Click(object sender, EventArgs e)
        {
            CreateNewFolder(currentDirectory);
        }

        private void CreateNewFolder(string parentDirectory)
        {
            string currentDirectoryPath = Path.Text;

            string newFolderName = "New Folder";
            string newFolderPath = System.IO.Path.Combine(currentDirectoryPath, newFolderName); // Sử dụng Path.Combine

            int count = 1;

            while (Directory.Exists(newFolderPath))
            {
                newFolderPath = System.IO.Path.Combine(currentDirectoryPath, $"{newFolderName} ({count++})"); // Tạo tên thư mục mới nếu đã tồn tại
            }

            Directory.CreateDirectory(newFolderPath);
            LoadFilesFromDirectory(currentDirectoryPath);
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void HienDuongDi_Click(object sender, EventArgs e) { }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) { }
        private void tenFile_AfterSelect(object sender, TreeViewEventArgs e) { }
    }
}