using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static System.Windows.Forms.AxHost;
using System.DirectoryServices;
using static deneme4.Form2;
using static deneme4.Form1;
using CheckBox = System.Windows.Forms.CheckBox;



namespace deneme4
{

    public partial class Grafik : Form
    {
        private Form1 form1Instance;
        public Grafik()
        {
            InitializeComponent();
            FormClosing += Form2_Closed;

        }
        public string formattedDateTime;

        int with;

       
        public DateTime dtObj2;
        // private List<System.Windows.Forms.CheckBox> checkBoxes;

        private void Grafik_Load(object sender, EventArgs e)
        {

            chart1.MouseWheel += Chart1_MouseWheel;
            chart1.FormatNumber += chart1_FormatNumber;
            Loads.LoadGrafik(with, splitContainer1, dateTimePicker1, dtObj2, dataGridView1, formattedDateTime);
            label3.Visible = false;
            label3.Location = new Point(splitContainer1.Panel2.Width / 2, splitContainer1.Panel1.Height - 21);
            label2.Location = new Point(splitContainer1.Panel2.Width / 2, label3.Height - 50);
            splitContainer1.SplitterDistance = 870;
            label2.BackColor = splitContainer1.Panel2.BackColor;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            button1.Enabled = false;
            chart1.Visible = true;
        }


        public static List<System.Windows.Forms.CheckBox> checkBoxes3 = new List<System.Windows.Forms.CheckBox>();
        public List<System.Windows.Forms.CheckBox> lis(System.Windows.Forms.CheckBox c, List<System.Windows.Forms.CheckBox> cl)
        {
            checkBoxes3 = new List<System.Windows.Forms.CheckBox>();
            cl.Add(c);
            return cl;
        }
        public int y = 0, z = 0, k = 0, l = 0, d = 30, m = 0;
        // private List<System.Windows.Forms.CheckBox> checkBoxes;
        public int targetX = 100;
        public async void seriesadd(Panel panel1, List<System.Windows.Forms.CheckBox> checkBoxes3)
        {
            List<string> list = new List<string>();
            Fonks.Colums(list);

            Grafik grafik = new Grafik();
            int j = 0, i = 0;
            foreach (var column in list)
            {

                System.Windows.Forms.CheckBox newCheckBox = new System.Windows.Forms.CheckBox();
                newCheckBox.Text = column;
                newCheckBox.Checked = false;
                lis(newCheckBox, checkBoxes3);
                newCheckBox.CheckedChanged += CheckBox_CheckedChanged1;
                // checkBoxes3.Add(yeniCheckBox);
                panel1.Controls.Add(newCheckBox);
                newCheckBox.Location = new Point(k, d);
                if (m < 3)
                    k = k + 105;
                else if (l == 3 || m >= 3)
                {
                    d = d + 30;
                    if (m >= 3)
                        m++;
                }

                l++;

                if (l == 3 && m <= 3)
                {
                    k = 0;
                    d = d + 30;
                    l = 0;
                    m++;
                }
                if (m % 3 == 0 && m > 0)
                {

                    if (m == 3)
                    {
                        k = m * 105;
                        d = 30;
                    }

                    else
                    {
                        k = k + 105;

                        d = 30;
                        l = 0;
                    }


                }
                newCheckBox.CheckedChanged += CheckBox_CheckedChanged3;


            }
            panel1.Visible = true;

        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // İlgili sütun ve satır
            {
                if (e.Value != null)
                {
                    if (DateTime.TryParseExact(e.Value.ToString(), "yyyyMMddHHmmssfff", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                    {
                        e.Value = parsedDate.ToString("yyyy.MM.dd / HH:mm:ss:fff");
                        e.FormattingApplied = true; // Formatlama işlemi uygulandı olarak işaretlenir
                    }
                }
            }
        }
        private void chart1_FormatNumber(object sender, FormatNumberEventArgs e)
        {
            if (e.ElementType == ChartElementType.AxisLabels && e.ValueType == ChartValueType.Double)
            {
                e.LocalizedValue = ((int)e.Value).ToString();
            }
        }
        private void Chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Chart chart = sender as Chart;

            // Tıklanan noktanın koordinatlarını al
            double xValue = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            double yValue = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

            // Yakınlaştırma ve uzaklaştırma faktörlerini belirle
            double zoomInFactor = 0.9;  // Yukarı kaydırma (zoom in) için faktör
            double zoomOutFactor = 1.0 / zoomInFactor; // Uzaklaştırma için ters faktör

            // Tekerleğin döndürülme yönüne göre işlem yap
            if (e.Delta > 0) // Yukarı kaydırma (zoom in)
            {
                // Yeni ölçeklendirme değerlerini ayarla
                chart1.ChartAreas[0].AxisX.Minimum = Convert.ToInt32((xValue - (xValue - chart1.ChartAreas[0].AxisX.Minimum) * zoomInFactor));
                chart1.ChartAreas[0].AxisX.Maximum = Convert.ToInt32((xValue + (chart1.ChartAreas[0].AxisX.Maximum - xValue) * zoomInFactor));
                chart1.ChartAreas[0].AxisY.Minimum = Convert.ToInt32((yValue - (yValue - chart1.ChartAreas[0].AxisY.Minimum) * zoomInFactor));
                chart1.ChartAreas[0].AxisY.Maximum = Convert.ToInt32((yValue + (chart1.ChartAreas[0].AxisY.Maximum - yValue) * zoomInFactor));
            }
            else if (e.Delta < 0) // Aşağı kaydırma (zoom out)
            {
                // Yeni ölçeklendirme değerlerini ayarla
                chart1.ChartAreas[0].AxisX.Minimum = Convert.ToInt32((xValue - (xValue - chart1.ChartAreas[0].AxisX.Minimum) * zoomOutFactor));
                chart1.ChartAreas[0].AxisX.Maximum = Convert.ToInt32((xValue + (chart1.ChartAreas[0].AxisX.Maximum - xValue) * zoomOutFactor));
                chart1.ChartAreas[0].AxisY.Minimum = Convert.ToInt32((yValue - (yValue - chart1.ChartAreas[0].AxisY.Minimum) * zoomOutFactor));
                chart1.ChartAreas[0].AxisY.Maximum = Convert.ToInt32((yValue + (chart1.ChartAreas[0].AxisY.Maximum - yValue) * zoomOutFactor));
            }

            // Grafik üzerindeki değişiklikleri yeniden çiz
            chart1.Invalidate();
        }
        private void Grafik_Resize(object sender, EventArgs e)
        {

            //label3.Location = new Point(splitContainer1.Panel2.Width / 2, splitContainer1.Panel1.Height - 21);
            //label2.Location = new Point(splitContainer1.Panel2.Width / 2, label3.Height - 50);

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            //label1.ForeColor = Color.Black;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            // label1.ForeColor = Color.Red;
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            with = splitContainer1.Size.Width - 20;
            //   label1.Location = new Point(with, 0);
            label3.Location = new Point(splitContainer1.Panel2.Width / 2, splitContainer1.Panel1.Height - 21);
            label2.Location = new Point(splitContainer1.Panel2.Width / 2, label3.Height - 50);
            // label1.Location = new Point(splitContainer1.Panel2.Width / 2, label3.Height - 50);
            splitContainer1.Panel2.BackColor = Color.GhostWhite;
            if (splitContainer1.SplitterDistance > 870)
            {
                label3.Visible = true;
                // label1.Visible = true;
                label2.Visible = false;
                splitContainer1.SplitterDistance = splitContainer1.Height - label2.Size.Height;
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }



        private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
        {
            foreach (Series series in chart1.Series)
            {
                foreach (DataPoint point in series.Points)
                {
                    // Y değerini double'dan int'e dönüştür ve güncelle
                    int intValue = (int)Math.Round(point.YValues[0]);
                    point.SetValueY(intValue);
                }
            }
        }
        private void UpdateChart()
        {
            foreach (Series series in chart1.Series)
            {
                foreach (DataPoint point in series.Points)
                {
                    double yValue = point.YValues[0];
                    int intValue = (int)Math.Round(yValue);
                    point.SetValueY(intValue);
                }
            }
        }
        private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            UpdateChart();
        }







        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void splitContainer1_Resize(object sender, EventArgs e)
        {

            label3.Location = new Point(splitContainer1.Panel2.Width / 2, splitContainer1.Panel1.Height - 21);
            label2.Location = new Point(splitContainer1.Panel2.Width / 2, label3.Height - 50);
          
            if (splitContainer1.SplitterDistance > 900)
            {

                label3.Visible = true;
                label2.Visible = false;
                splitContainer1.SplitterDistance = splitContainer1.Height - label2.Size.Height;
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {

            label3.Location = new Point(splitContainer1.Panel2.Width / 2, splitContainer1.Panel1.Height - 21);
            label2.Location = new Point(splitContainer1.Panel2.Width / 2, label3.Height - 50);

            if (label2.Visible == false)
            {
                if (splitContainer1.SplitterDistance < 900)
                {

                    label3.Visible = true;
                }

            }
        }
        //   Form1 form1 = new Form1();
        private void label3_Click(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = this.Height - 150;
            label3.Visible = false; label2.Visible = true;
            groupBox1.Visible = true;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

            label3.Visible = true;
            // label1.Location=label2.Location;
            groupBox1.Visible = false;
            label2.Visible = false;
            splitContainer1.SplitterDistance = splitContainer1.Height - label2.Size.Height;
        }
        public int a = 2000;
        public int b = 0;


        private void label2_BackColorChanged(object sender, EventArgs e)
        {
            label2.BackColor = splitContainer1.Panel2.BackColor;
        }

        private void label3_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBoxes = DataStorage.DataList;
            b = b + 2000;
            Fonks.ShowData(dataGridView1, query, a, b, formattedDateTime);
            button1.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            b = b - 2000;

            checkBoxes = DataStorage.DataList;
            if (b <= 2000)
            {
                button1.Enabled = false;
            }

            Fonks.ShowData(dataGridView1, query, a, b, formattedDateTime);
           // Fonks.Checks(checkBoxes, chart1, a, b, dateTimePicker1, formattedDateTime);


        }
        // private System.Windows.Forms.CheckBox[] checkboxList;
        private void CheckBox_CheckedChanged2(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            if (checkBox.Checked)
            {
                // İlgili checkbox işaretlendiğinde yapılacak işlemleri burada gerçekleştirin.
                MessageBox.Show(dtObj2.ToString());
                checkBoxes.Add(checkBox);

            }
            else
            {
                // İlgili checkbox işareti kaldırıldığında yapılacak işlemleri burada gerçekleştirin.
                checkBoxes.Remove(checkBox);
            }
        }

        //private Form2 form2 = new Form2();
        private void CheckBox_CheckedChanged1(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            DateTime selectedDateTime = dateTimePicker1.Value; // DateTimePicker kontrolünden seçilen değeri alır

            formattedDateTime = selectedDateTime.ToString("yyyyMMddHHmmss"); // Belirtilen formata göre string'e dönüştürür
            formattedDateTime = formattedDateTime + "000";

            if (checkBox.Checked == true)
            {
                Fonks.ShowData(dataGridView1, query, a, b, formattedDateTime);
            }
            else
            {
                Fonks.ShowData(dataGridView1, query, a, b, formattedDateTime);
            }

           // Fonks.control(chart1, checkBox, dataGridView1, a, b, dateTimePicker1, formattedDateTime);


        }

        public List<System.Windows.Forms.CheckBox> checkBoxes = new List<System.Windows.Forms.CheckBox>();


        private void label1_Click(object sender, EventArgs e)
        {
            //label2.Visible = true;
            //label1.Visible = false;
            //splitContainer1.SplitterDistance = 900;
        }

        private void label1_BackColorChanged(object sender, EventArgs e)
        {
            //label1.BackColor = splitContainer1.Panel1.BackColor;
        }
        string query = "";


        private void CheckBox_CheckedChanged3(object sender, EventArgs e)
        {

            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            // DateTime selectedDateTime = grafik.dateTimePicker1.Value; // DateTimePicker kontrolünden seçilen değeri alır

            formattedDateTime = DataStorage.selectedDateTime.ToString("yyyyMMddHHmmss"); // Belirtilen formata göre string'e dönüştürür
            formattedDateTime = formattedDateTime + "000";

            if (checkBox.Checked == true)
            {
                Fonks.ShowData(dataGridView1, query, 2000, 0, formattedDateTime);
            }
            else
            {
                Fonks.ShowData(dataGridView1, query, a, b, formattedDateTime);
            }

           // Fonks.control(chart1, checkBox, dataGridView1, a, b, dateTimePicker1, formattedDateTime);


        }
        private void Form2_Closed(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            //LoadGrafik();
            for (int i = panel1.Controls.Count - 1; i >= 0; i--)
            {
                Control control = panel1.Controls[i];
                if (control is CheckBox)
                {
                    DataStorage.DataList.Remove(control as CheckBox);
                    panel1.Controls.Remove(control);
                }
            }
            DataStorage.DataList.Clear();
            controlcheck.Clear();
            // chart1.Controls.Clear();
            // int a = a; int b = b;

            Fonks.ShowData(dataGridView1, query, a, 0, formattedDateTime);
            seriesadd(panel1, DataStorage.DataList);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Form2'yi oluşturur
            form2.FormClosed += Form2_Closed;
            form2.Show();
            chart1.Series.Clear();
            DataStorage.Colums.Clear();


        }
        // public static string newformattedDateTime { get; set; }
        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            b = 0;
            DataStorage.selectedDateTime = dateTimePicker1.Value; // DateTimePicker kontrolünden seçilen değeri alır
                                                                   // checkBoxes3 = new List<System.Windows.Forms.CheckBox> ();
            formattedDateTime = DataStorage.selectedDateTime.ToString("yyyyMMddHHmmss"); // Belirtilen formata göre string'e dönüştürür
            formattedDateTime = formattedDateTime + "000";

            Fonks.ShowData(dataGridView1, query, a, b, formattedDateTime);
           // Fonks.Checks(DataStorage.DataList, chart1, a, b, dateTimePicker1, formattedDateTime);
            // b = b + 2000;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkBoxes = DataStorage.DataList;
            if (b <= 2000)
            {
                button1.Enabled = false;
            }
            b = b - 2000;

            Fonks.ShowData(dataGridView1, query, a, b, formattedDateTime);
          //  Fonks.Checks(checkBoxes3, chart1, a, b, dateTimePicker1, formattedDateTime);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }


}


