namespace deneme4
{
    partial class Anaform
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            toolTip1 = new ToolTip(components);
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            listBox1 = new ListBox();
            button8 = new Button();
            splitContainer2 = new SplitContainer();
            label7 = new Label();
            label5 = new Label();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            label8 = new Label();
            button5 = new Button();
            button10 = new Button();
            button4 = new Button();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            button9 = new Button();
            button6 = new Button();
            button7 = new Button();
            label3 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            label4 = new Label();
            button3 = new Button();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            openFileDialog1 = new OpenFileDialog();
            toolTip2 = new ToolTip(components);
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // toolTip1
            // 
            toolTip1.BackColor = SystemColors.InactiveCaptionText;
            toolTip1.ForeColor = SystemColors.GradientActiveCaption;
            toolTip1.IsBalloon = true;
            toolTip1.OwnerDraw = true;
            toolTip1.ToolTipTitle = "Tarih :";
            toolTip1.Draw += toolTip1_Draw;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            chart1.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(0, 0);
            chart1.Name = "chart1";
            chart1.Size = new Size(1125, 411);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.Window;
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            listBox1.ForeColor = SystemColors.InfoText;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(3, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(323, 150);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // button8
            // 
            button8.Location = new Point(26, 24);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 9;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click_1;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(label7);
            splitContainer2.Panel1.Controls.Add(label5);
            splitContainer2.Panel1.Controls.Add(chart1);
            splitContainer2.Panel1.Controls.Add(dataGridView1);
            splitContainer2.Panel1.Resize += splitContainer2_Panel1_Resize;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackColor = Color.FromArgb(224, 224, 224);
            splitContainer2.Panel2.Controls.Add(panel2);
            splitContainer2.Panel2.Resize += splitContainer2_Panel2_Resize;
            splitContainer2.Size = new Size(1125, 693);
            splitContainer2.SplitterDistance = 411;
            splitContainer2.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(424, 280);
            label7.Name = "label7";
            label7.Size = new Size(36, 37);
            label7.TabIndex = 5;
            label7.Text = "^";
            label7.Click += label7_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(928, 0);
            label5.Name = "label5";
            label5.Size = new Size(20, 21);
            label5.TabIndex = 6;
            label5.Text = "X";
            label5.Visible = false;
            label5.Click += label5_Click;
            label5.MouseLeave += label5_MouseLeave;
            label5.MouseHover += label5_MouseHover;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1125, 411);
            dataGridView1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.GhostWhite;
            panel2.Controls.Add(button8);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1125, 278);
            panel2.TabIndex = 2;
            panel2.Resize += panel2_Resize;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.GhostWhite;
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button10);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button9);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button7);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(324, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(801, 278);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.GhostWhite;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(277, 0);
            label8.Name = "label8";
            label8.Size = new Size(27, 32);
            label8.TabIndex = 4;
            label8.Text = "v";
            label8.BackColorChanged += label8_BackColorChanged;
            label8.Click += label8_Click;
            // 
            // button5
            // 
            button5.Location = new Point(6, 110);
            button5.Name = "button5";
            button5.Size = new Size(130, 40);
            button5.TabIndex = 8;
            button5.Text = "Veri Göster";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button10
            // 
            button10.Location = new Point(444, 39);
            button10.Name = "button10";
            button10.Size = new Size(75, 40);
            button10.TabIndex = 11;
            button10.Text = "Pdf olarak kaydet";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button4
            // 
            button4.Location = new Point(6, 64);
            button4.Name = "button4";
            button4.Size = new Size(130, 40);
            button4.TabIndex = 3;
            button4.Text = "listele";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(536, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(221, 23);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(6, 15);
            button1.Name = "button1";
            button1.Size = new Size(130, 40);
            button1.TabIndex = 2;
            button1.Text = "Grafik";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button9
            // 
            button9.Location = new Point(444, 39);
            button9.Name = "button9";
            button9.Size = new Size(75, 40);
            button9.TabIndex = 10;
            button9.Text = "Pdf olarak kaydet";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button6
            // 
            button6.Location = new Point(714, 85);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 7;
            button6.Text = ">";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(536, 85);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 6;
            button7.Text = "<";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 36F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.WindowFrame;
            label3.Location = new Point(265, 179);
            label3.Name = "label3";
            label3.Size = new Size(383, 130);
            label3.TabIndex = 0;
            label3.Text = "Dosya Yüklemek \r\n    için Tıklayın";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            label3.Click += label3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 611);
            panel1.Name = "panel1";
            panel1.Size = new Size(1125, 82);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
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
            label4.Click += label4_Click;
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
            button2.Location = new Point(299, 3);
            button2.Name = "button2";
            button2.Size = new Size(27, 23);
            button2.TabIndex = 1;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseLeave += button2_MouseLeave;
            button2.MouseHover += button2_MouseHover;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel3
            // 
            panel3.BackColor = Color.GhostWhite;
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(splitContainer2);
            panel3.Controls.Add(listBox1);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(button2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1125, 693);
            panel3.TabIndex = 8;
            // 
            // Anaform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 693);
            Controls.Add(panel3);
            Name = "Anaform";
            Text = "Anaform";
            WindowState = FormWindowState.Maximized;
            FormClosed += Anaform_FormClosed;
            Load += Anaform_Load;
            Resize += Anaform_Resize;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button4;
        public Button button1;
        public Label label5;
        private Panel panel1;
        private Label label6;
        private Label label4;
        private Button button3;
        private ProgressBar progressBar1;
        private Button button2;
        private Label label3;
        private OpenFileDialog openFileDialog1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public Panel panel2;
        private GroupBox groupBox1;
        private Button button5;
        public DateTimePicker dateTimePicker1;
        private Button button6;
        private Button button7;
        public Label label7;
        public Label label8;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        public DataGridView dataGridView1;
        public SplitContainer splitContainer2;
        private Button button8;
        private Button button9;
        private Button button10;
        public Panel panel3;
    }
}