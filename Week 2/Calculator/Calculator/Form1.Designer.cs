namespace Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.seven = new System.Windows.Forms.Button();
            this.four = new System.Windows.Forms.Button();
            this.one = new System.Windows.Forms.Button();
            this.sign = new System.Windows.Forms.Button();
            this.eight = new System.Windows.Forms.Button();
            this.five = new System.Windows.Forms.Button();
            this.two = new System.Windows.Forms.Button();
            this.zero = new System.Windows.Forms.Button();
            this.nine = new System.Windows.Forms.Button();
            this.six = new System.Windows.Forms.Button();
            this.three = new System.Windows.Forms.Button();
            this.comma = new System.Windows.Forms.Button();
            this.C = new System.Windows.Forms.Button();
            this.mul = new System.Windows.Forms.Button();
            this.sub = new System.Windows.Forms.Button();
            this.percent = new System.Windows.Forms.Button();
            this.CE = new System.Windows.Forms.Button();
            this.div = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.equal = new System.Windows.Forms.Button();
            this.current = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox1.Font = new System.Drawing.Font("Gadugi", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(28, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(435, 51);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // seven
            // 
            this.seven.BackColor = System.Drawing.Color.AntiqueWhite;
            this.seven.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seven.Location = new System.Drawing.Point(28, 117);
            this.seven.Name = "seven";
            this.seven.Size = new System.Drawing.Size(65, 65);
            this.seven.TabIndex = 1;
            this.seven.Text = "7";
            this.seven.UseVisualStyleBackColor = false;
            this.seven.Click += new System.EventHandler(this.btn_click);
            // 
            // four
            // 
            this.four.BackColor = System.Drawing.Color.AntiqueWhite;
            this.four.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.four.Location = new System.Drawing.Point(28, 188);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(65, 65);
            this.four.TabIndex = 2;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = false;
            this.four.Click += new System.EventHandler(this.btn_click);
            // 
            // one
            // 
            this.one.BackColor = System.Drawing.Color.AntiqueWhite;
            this.one.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.one.Location = new System.Drawing.Point(28, 259);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(65, 65);
            this.one.TabIndex = 3;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = false;
            this.one.Click += new System.EventHandler(this.btn_click);
            // 
            // sign
            // 
            this.sign.BackColor = System.Drawing.Color.AntiqueWhite;
            this.sign.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign.Location = new System.Drawing.Point(28, 330);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(65, 65);
            this.sign.TabIndex = 4;
            this.sign.Text = "+/-";
            this.sign.UseVisualStyleBackColor = false;
            this.sign.Click += new System.EventHandler(this.sign_Click);
            // 
            // eight
            // 
            this.eight.BackColor = System.Drawing.Color.AntiqueWhite;
            this.eight.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eight.Location = new System.Drawing.Point(99, 117);
            this.eight.Name = "eight";
            this.eight.Size = new System.Drawing.Size(65, 65);
            this.eight.TabIndex = 5;
            this.eight.Text = "8";
            this.eight.UseVisualStyleBackColor = false;
            this.eight.Click += new System.EventHandler(this.btn_click);
            // 
            // five
            // 
            this.five.BackColor = System.Drawing.Color.AntiqueWhite;
            this.five.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.five.Location = new System.Drawing.Point(99, 188);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(65, 65);
            this.five.TabIndex = 6;
            this.five.Text = "5";
            this.five.UseVisualStyleBackColor = false;
            this.five.Click += new System.EventHandler(this.btn_click);
            // 
            // two
            // 
            this.two.BackColor = System.Drawing.Color.AntiqueWhite;
            this.two.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.two.Location = new System.Drawing.Point(99, 259);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(65, 65);
            this.two.TabIndex = 7;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = false;
            this.two.Click += new System.EventHandler(this.btn_click);
            // 
            // zero
            // 
            this.zero.BackColor = System.Drawing.Color.AntiqueWhite;
            this.zero.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zero.Location = new System.Drawing.Point(99, 330);
            this.zero.Name = "zero";
            this.zero.Size = new System.Drawing.Size(65, 65);
            this.zero.TabIndex = 8;
            this.zero.Text = "0";
            this.zero.UseVisualStyleBackColor = false;
            this.zero.Click += new System.EventHandler(this.btn_click);
            // 
            // nine
            // 
            this.nine.BackColor = System.Drawing.Color.AntiqueWhite;
            this.nine.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nine.Location = new System.Drawing.Point(170, 117);
            this.nine.Name = "nine";
            this.nine.Size = new System.Drawing.Size(65, 65);
            this.nine.TabIndex = 9;
            this.nine.Text = "9";
            this.nine.UseVisualStyleBackColor = false;
            this.nine.Click += new System.EventHandler(this.btn_click);
            // 
            // six
            // 
            this.six.BackColor = System.Drawing.Color.AntiqueWhite;
            this.six.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.six.Location = new System.Drawing.Point(170, 188);
            this.six.Name = "six";
            this.six.Size = new System.Drawing.Size(65, 65);
            this.six.TabIndex = 10;
            this.six.Text = "6";
            this.six.UseVisualStyleBackColor = false;
            this.six.Click += new System.EventHandler(this.btn_click);
            // 
            // three
            // 
            this.three.BackColor = System.Drawing.Color.AntiqueWhite;
            this.three.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.three.Location = new System.Drawing.Point(170, 259);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(65, 65);
            this.three.TabIndex = 11;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = false;
            this.three.Click += new System.EventHandler(this.btn_click);
            // 
            // comma
            // 
            this.comma.BackColor = System.Drawing.Color.AntiqueWhite;
            this.comma.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comma.Location = new System.Drawing.Point(170, 330);
            this.comma.Name = "comma";
            this.comma.Size = new System.Drawing.Size(65, 65);
            this.comma.TabIndex = 12;
            this.comma.Text = ".";
            this.comma.UseVisualStyleBackColor = false;
            this.comma.Click += new System.EventHandler(this.btn_click);
            // 
            // C
            // 
            this.C.BackColor = System.Drawing.Color.LightSalmon;
            this.C.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C.Location = new System.Drawing.Point(398, 117);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(65, 65);
            this.C.TabIndex = 13;
            this.C.Text = "C";
            this.C.UseVisualStyleBackColor = false;
            this.C.Click += new System.EventHandler(this.C_Click);
            // 
            // mul
            // 
            this.mul.BackColor = System.Drawing.Color.AntiqueWhite;
            this.mul.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mul.Location = new System.Drawing.Point(398, 188);
            this.mul.Name = "mul";
            this.mul.Size = new System.Drawing.Size(65, 65);
            this.mul.TabIndex = 14;
            this.mul.Text = "×";
            this.mul.UseVisualStyleBackColor = false;
            this.mul.Click += new System.EventHandler(this.opr_click);
            // 
            // sub
            // 
            this.sub.BackColor = System.Drawing.Color.AntiqueWhite;
            this.sub.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub.Location = new System.Drawing.Point(398, 259);
            this.sub.Name = "sub";
            this.sub.Size = new System.Drawing.Size(65, 65);
            this.sub.TabIndex = 15;
            this.sub.Text = "-";
            this.sub.UseVisualStyleBackColor = false;
            this.sub.Click += new System.EventHandler(this.opr_click);
            // 
            // percent
            // 
            this.percent.BackColor = System.Drawing.Color.AntiqueWhite;
            this.percent.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percent.Location = new System.Drawing.Point(398, 330);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(65, 65);
            this.percent.TabIndex = 16;
            this.percent.Text = "%";
            this.percent.UseVisualStyleBackColor = false;
            this.percent.Click += new System.EventHandler(this.percent_Click);
            // 
            // CE
            // 
            this.CE.BackColor = System.Drawing.Color.LightSalmon;
            this.CE.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CE.Location = new System.Drawing.Point(327, 117);
            this.CE.Name = "CE";
            this.CE.Size = new System.Drawing.Size(65, 65);
            this.CE.TabIndex = 17;
            this.CE.Text = "CE";
            this.CE.UseVisualStyleBackColor = false;
            this.CE.Click += new System.EventHandler(this.button17_Click);
            // 
            // div
            // 
            this.div.BackColor = System.Drawing.Color.AntiqueWhite;
            this.div.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.div.Location = new System.Drawing.Point(327, 188);
            this.div.Name = "div";
            this.div.Size = new System.Drawing.Size(65, 65);
            this.div.TabIndex = 18;
            this.div.Text = "/";
            this.div.UseVisualStyleBackColor = false;
            this.div.Click += new System.EventHandler(this.opr_click);
            // 
            // plus
            // 
            this.plus.BackColor = System.Drawing.Color.AntiqueWhite;
            this.plus.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plus.Location = new System.Drawing.Point(327, 259);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(65, 65);
            this.plus.TabIndex = 19;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = false;
            this.plus.Click += new System.EventHandler(this.opr_click);
            // 
            // equal
            // 
            this.equal.BackColor = System.Drawing.Color.LightCoral;
            this.equal.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equal.Location = new System.Drawing.Point(327, 330);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(65, 65);
            this.equal.TabIndex = 20;
            this.equal.Text = "=";
            this.equal.UseVisualStyleBackColor = false;
            this.equal.Click += new System.EventHandler(this.equal_Click);
            // 
            // current
            // 
            this.current.AutoSize = true;
            this.current.BackColor = System.Drawing.Color.AntiqueWhite;
            this.current.Font = new System.Drawing.Font("Gadugi", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current.ForeColor = System.Drawing.SystemColors.ControlText;
            this.current.Location = new System.Drawing.Point(22, 18);
            this.current.Name = "current";
            this.current.Size = new System.Drawing.Size(0, 33);
            this.current.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(493, 429);
            this.Controls.Add(this.current);
            this.Controls.Add(this.equal);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.div);
            this.Controls.Add(this.CE);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.sub);
            this.Controls.Add(this.mul);
            this.Controls.Add(this.C);
            this.Controls.Add(this.comma);
            this.Controls.Add(this.three);
            this.Controls.Add(this.six);
            this.Controls.Add(this.nine);
            this.Controls.Add(this.zero);
            this.Controls.Add(this.two);
            this.Controls.Add(this.five);
            this.Controls.Add(this.eight);
            this.Controls.Add(this.sign);
            this.Controls.Add(this.one);
            this.Controls.Add(this.four);
            this.Controls.Add(this.seven);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fake Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button seven;
        private System.Windows.Forms.Button four;
        private System.Windows.Forms.Button one;
        private System.Windows.Forms.Button sign;
        private System.Windows.Forms.Button eight;
        private System.Windows.Forms.Button five;
        private System.Windows.Forms.Button two;
        private System.Windows.Forms.Button zero;
        private System.Windows.Forms.Button nine;
        private System.Windows.Forms.Button six;
        private System.Windows.Forms.Button three;
        private System.Windows.Forms.Button comma;
        private System.Windows.Forms.Button C;
        private System.Windows.Forms.Button mul;
        private System.Windows.Forms.Button sub;
        private System.Windows.Forms.Button percent;
        private System.Windows.Forms.Button CE;
        private System.Windows.Forms.Button div;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button equal;
        private System.Windows.Forms.Label current;
    }
}

