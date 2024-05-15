namespace deneme4
{
    partial class Grafik
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            splitContainer1 = new SplitContainer();
            label3 = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            button3 = new Button();
            dateTimePicker1 = new DateTimePicker();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(chart1);
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            splitContainer1.Panel1.Resize += splitContainer1_Panel1_Resize;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ActiveCaption;
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Resize += splitContainer1_Panel2_Resize;
            splitContainer1.Size = new Size(1346, 617);
            splitContainer1.SplitterDistance = 464;
            splitContainer1.TabIndex = 0;
            //splitContainer1.SplitterMoved += this.splitContainer1_SplitterMoved;
            splitContainer1.Resize += splitContainer1_Resize;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(633, 437);
            label3.Name = "label3";
            label3.Size = new Size(36, 37);
            label3.TabIndex = 3;
            label3.Text = "^";
            label3.BackColorChanged += label3_BackColorChanged;
            label3.Click += label3_Click;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea4);
            chart1.Dock = DockStyle.Fill;
            legend4.Name = "Legend1";
            chart1.Legends.Add(legend4);
            chart1.Location = new Point(0, 0);
            chart1.Name = "chart1";
            chart1.Size = new Size(1346, 464);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            chart1.AxisViewChanged += chart1_AxisViewChanged;
            chart1.PostPaint += chart1_PostPaint;
            chart1.Click += chart1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1346, 464);
            dataGridView1.TabIndex = 4;
            dataGridView1.Visible = false;
           // dataGridView1.CellContentClick += this.dataGridView1_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.GhostWhite;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(633, -10);
            label2.Name = "label2";
            label2.Size = new Size(27, 32);
            label2.TabIndex = 2;
            label2.Text = "v";
            label2.BackColorChanged += label2_BackColorChanged;
            label2.Click += label2_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1346, 149);
            panel1.TabIndex = 1;
           // panel1.Paint += this.panel1_Paint;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.GhostWhite;
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(1138, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(208, 149);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button3
            // 
            button3.Location = new Point(69, 65);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "Veri ekle";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(27, 36);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(156, 23);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button2
            // 
            button2.Location = new Point(108, 94);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = ">";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(27, 94);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "<";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Grafik
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1346, 617);
            Controls.Add(splitContainer1);
            Name = "Grafik";
            Text = "Grafik";
            Load += Grafik_Load;
            Resize += Grafik_Resize;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public DateTimePicker dateTimePicker1;
        private Button button1;
        private Button button2;
        public DataGridView dataGridView1;
        public SplitContainer splitContainer1;
        public Label label3;
        private Button button3;
        public Panel panel1;
        private GroupBox groupBox1;
        public Label label2;
    }
}