namespace Picture_Viewer
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.o1 = new System.Windows.Forms.Button();
            this.o2 = new System.Windows.Forms.Button();
            this.o3 = new System.Windows.Forms.Button();
            this.o4 = new System.Windows.Forms.Button();
            this.box1 = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.73708F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.26292F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.box1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.31169F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.68831F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 378);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(671, 327);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.o1);
            this.flowLayoutPanel1.Controls.Add(this.o2);
            this.flowLayoutPanel1.Controls.Add(this.o3);
            this.flowLayoutPanel1.Controls.Add(this.o4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(96, 336);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(578, 39);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // o1
            // 
            this.o1.AutoSize = true;
            this.o1.Location = new System.Drawing.Point(3, 3);
            this.o1.Name = "o1";
            this.o1.Size = new System.Drawing.Size(104, 26);
            this.o1.TabIndex = 0;
            this.o1.Text = "Close ";
            this.o1.UseVisualStyleBackColor = true;
            this.o1.Click += new System.EventHandler(this.o1_Click);
            // 
            // o2
            // 
            this.o2.AutoSize = true;
            this.o2.Location = new System.Drawing.Point(113, 3);
            this.o2.Name = "o2";
            this.o2.Size = new System.Drawing.Size(148, 26);
            this.o2.TabIndex = 1;
            this.o2.Text = "Set Background Color";
            this.o2.UseVisualStyleBackColor = true;
            this.o2.Click += new System.EventHandler(this.o2_Click);
            // 
            // o3
            // 
            this.o3.AutoSize = true;
            this.o3.Location = new System.Drawing.Point(267, 3);
            this.o3.Name = "o3";
            this.o3.Size = new System.Drawing.Size(120, 26);
            this.o3.TabIndex = 2;
            this.o3.Text = "Clear The Picture";
            this.o3.UseVisualStyleBackColor = true;
            this.o3.Click += new System.EventHandler(this.o3_Click);
            // 
            // o4
            // 
            this.o4.AutoSize = true;
            this.o4.Location = new System.Drawing.Point(393, 3);
            this.o4.Name = "o4";
            this.o4.Size = new System.Drawing.Size(121, 26);
            this.o4.TabIndex = 1;
            this.o4.Text = "Show The Picture";
            this.o4.UseVisualStyleBackColor = true;
            this.o4.Click += new System.EventHandler(this.o4_Click);
            // 
            // box1
            // 
            this.box1.AutoSize = true;
            this.box1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.box1.Location = new System.Drawing.Point(3, 336);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(87, 39);
            this.box1.TabIndex = 1;
            this.box1.Text = "Stretch";
            this.box1.UseVisualStyleBackColor = true;
            this.box1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Select a Picture";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 375);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Picture Viewer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox box1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button o1;
        private System.Windows.Forms.Button o2;
        private System.Windows.Forms.Button o3;
        private System.Windows.Forms.Button o4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

