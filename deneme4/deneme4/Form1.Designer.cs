namespace deneme4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            button4 = new Button();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            label4 = new Label();
            button3 = new Button();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            label3 = new Label();
            listBox1 = new ListBox();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.GhostWhite;
            splitContainer1.Panel1.Controls.Add(button4);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            splitContainer1.Panel1.Resize += splitContainer1_Panel1_Resize;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Window;
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(listBox1);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Panel2.Resize += splitContainer1_Panel2_Resize;
            splitContainer1.Size = new Size(1163, 615);
            splitContainer1.SplitterDistance = 239;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // button4
            // 
            button4.Location = new Point(0, 107);
            button4.Name = "button4";
            button4.Size = new Size(236, 56);
            button4.TabIndex = 3;
            button4.Text = "listele";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(0, 40);
            button1.Name = "button1";
            button1.Size = new Size(236, 61);
            button1.TabIndex = 2;
            button1.Text = "Grafik";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.Resize += button1_Resize;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Right;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(204, 0);
            label2.Name = "label2";
            label2.Size = new Size(35, 37);
            label2.TabIndex = 1;
            label2.Text = "<";
            label2.Click += label2_Click;
            label2.MouseLeave += label2_MouseLeave;
            label2.MouseHover += label2_MouseHover;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(35, 37);
            label1.TabIndex = 0;
            label1.Text = ">";
            label1.Click += label1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(897, 2);
            label5.Name = "label5";
            label5.Size = new Size(20, 21);
            label5.TabIndex = 6;
            label5.Text = "X";
            label5.Visible = false;
            label5.Click += label5_Click;
            label5.MouseLeave += label5_MouseLeave;
            label5.MouseHover += label5_MouseHover;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 541);
            panel1.Name = "panel1";
            panel1.Size = new Size(920, 74);
            panel1.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlLight;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(448, 27);
            label6.Name = "label6";
            label6.Size = new Size(36, 21);
            label6.TabIndex = 6;
            label6.Text = "% 0";
            label6.Visible = false;
            label6.Click += label6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(26, 28);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 5;
            label4.Text = "Loading...";
            label4.Visible = false;
            // 
            // button3
            // 
            button3.BackColor = Color.GhostWhite;
            button3.Location = new Point(805, 15);
            button3.Name = "button3";
            button3.Size = new Size(75, 38);
            button3.TabIndex = 3;
            button3.Text = "Verileri Yükle";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.GhostWhite;
            progressBar1.Location = new Point(124, 15);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(675, 38);
            progressBar1.TabIndex = 4;
            progressBar1.Visible = false;
            progressBar1.ForeColorChanged += progressBar1_ForeColorChanged;
            progressBar1.Click += progressBar1_Click;
            progressBar1.Resize += progressBar1_Resize;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Window;
            button2.FlatAppearance.BorderColor = SystemColors.ButtonShadow;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            button2.FlatAppearance.MouseOverBackColor = SystemColors.Highlight;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ControlText;
            button2.Location = new Point(299, 0);
            button2.Name = "button2";
            button2.Size = new Size(27, 23);
            button2.TabIndex = 1;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseLeave += button2_MouseLeave;
            button2.MouseHover += button2_MouseHover;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 36F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.WindowFrame;
            label3.Location = new Point(265, 210);
            label3.Name = "label3";
            label3.Size = new Size(383, 130);
            label3.TabIndex = 0;
            label3.Text = "Dosya Yüklemek \r\n    için Tıklayın";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            label3.Click += label3_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Window;
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            listBox1.ForeColor = SystemColors.InfoText;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(3, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(323, 150);
            listBox1.TabIndex = 2;
            listBox1.MouseClick += listBox1_MouseClick_1;
            listBox1.MeasureItem += listBox1_MeasureItem;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1163, 615);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Resize += Form1_Resize;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label1;
        private Label label3;
        private Button button2;
        private ListBox listBox1;
        private Button button3;
        private ProgressBar progressBar1;
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private Label label4;
        private Button button4;
        public SplitContainer splitContainer1;
        public Label label5;
        public Button button1;
        private Label label6;
    }
}
