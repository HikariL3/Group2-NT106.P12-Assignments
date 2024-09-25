namespace File_Explorer
{
    partial class File_Explorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(File_Explorer));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tenFile = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.thongTin = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Back = new System.Windows.Forms.Button();
            this.Forward = new System.Windows.Forms.Button();
            this.HienDuongDi = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.TextBox();
            this.OpenBox = new System.Windows.Forms.Button();
            this.Option = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Option.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tenFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.thongTin);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.No;
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(826, 460);
            this.splitContainer1.SplitterDistance = 275;
            this.splitContainer1.TabIndex = 0;
            // 
            // tenFile
            // 
            this.tenFile.ImageIndex = 0;
            this.tenFile.ImageList = this.imageList1;
            this.tenFile.Location = new System.Drawing.Point(1, 2);
            this.tenFile.Name = "tenFile";
            this.tenFile.SelectedImageIndex = 0;
            this.tenFile.Size = new System.Drawing.Size(273, 457);
            this.tenFile.TabIndex = 2;
            this.tenFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tenFile_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "photo-1588611164738-ce2bd6151ec4.png");
            this.imageList1.Images.SetKeyName(1, "yuri-krupenin-XiE_PmKL-6U-unsplash.jpg");
            // 
            // thongTin
            // 
            this.thongTin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.columnHeader1});
            this.thongTin.HideSelection = false;
            this.thongTin.Location = new System.Drawing.Point(1, 2);
            this.thongTin.Name = "thongTin";
            this.thongTin.Size = new System.Drawing.Size(535, 457);
            this.thongTin.SmallImageList = this.imageList1;
            this.thongTin.TabIndex = 3;
            this.thongTin.UseCompatibleStateImageBehavior = false;
            this.thongTin.View = System.Windows.Forms.View.Details;
            // 
            // column1
            // 
            this.column1.Text = "Name";
            // 
            // column2
            // 
            this.column2.Text = "Type";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Last Modified";
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(3, 12);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(44, 26);
            this.Back.TabIndex = 2;
            this.Back.Text = "<<";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Forward
            // 
            this.Forward.Location = new System.Drawing.Point(48, 12);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(44, 26);
            this.Forward.TabIndex = 3;
            this.Forward.Text = ">>";
            this.Forward.UseVisualStyleBackColor = true;
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // HienDuongDi
            // 
            this.HienDuongDi.AutoSize = true;
            this.HienDuongDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HienDuongDi.Location = new System.Drawing.Point(98, 17);
            this.HienDuongDi.Name = "HienDuongDi";
            this.HienDuongDi.Size = new System.Drawing.Size(42, 18);
            this.HienDuongDi.TabIndex = 4;
            this.HienDuongDi.Text = "Path:";
            this.HienDuongDi.Click += new System.EventHandler(this.HienDuongDi_Click);
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(146, 12);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(561, 22);
            this.Path.TabIndex = 5;
            this.Path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OpenBox
            // 
            this.OpenBox.Location = new System.Drawing.Point(715, 9);
            this.OpenBox.Name = "OpenBox";
            this.OpenBox.Size = new System.Drawing.Size(92, 29);
            this.OpenBox.TabIndex = 6;
            this.OpenBox.Text = "Open";
            this.OpenBox.UseVisualStyleBackColor = true;
            this.OpenBox.Click += new System.EventHandler(this.OpenBox_Click);
            // 
            // Option
            // 
            this.Option.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Option.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.newToolStripMenuItem});
            this.Option.Name = "Option";
            this.Option.Size = new System.Drawing.Size(123, 124);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.newToolStripMenuItem.Text = "New";
            // 
            // File_Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 507);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.Forward);
            this.Controls.Add(this.OpenBox);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.HienDuongDi);
            this.Controls.Add(this.Back);
            this.Name = "File_Explorer";
            this.Text = "File Explorer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Option.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label HienDuongDi;
        private System.Windows.Forms.Button Forward;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button OpenBox;
        private System.Windows.Forms.TreeView tenFile;
        private System.Windows.Forms.ListView thongTin;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip Option;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}

