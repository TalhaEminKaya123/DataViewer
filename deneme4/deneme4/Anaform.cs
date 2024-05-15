using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static deneme4.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using ToolTip = System.Windows.Forms.ToolTip;
using System;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Word = Microsoft.Office.Interop.Word;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using System.Globalization;
using System.Reflection.Emit;

namespace deneme4
{
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();

        }
        //private System.Windows.Forms.ToolTip customToolTip;
        ToolTip customToolTip = new ToolTip();
        SQLiteConnection con;
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        string dosyayolu = "";
        //public string DataStorage.formattedDateTime;
        public string sorgu = "";
        public int a = 2000;
        public int b = 0;
        int with;
        int height;
        public DateTime dtobj2;
        List<string> list = new List<string>();
       // Label tooltipLabel = new Label();
        private Graphics graphics;
        private void Anaform_Load(object sender, EventArgs e)
        {
            button8.Visible = false;
            customToolTip = new System.Windows.Forms.ToolTip();
            button3.Visible = true;
            label5.Location = new Point(splitContainer2.Panel2.Width + 20, 0);
            label5.Visible = true;
            with = (panel3.Width - label3.Width) / 2;
            height = (panel3.Height - label3.Height) / 2;
            label3.Location = new Point(with, height);
           // label1.Visible = false;
          //  splitContainer1.SplitterDistance = 205;
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(AnaForm_DragEnter);
            this.DragDrop += new DragEventHandler(AnaForm_DragDrop);
            progressBar1.Width = panel3.Width - 500;
            progressBar1.Location = new Point(panel3.Left, 15);
            label6.Location = new Point(panel3.Left + progressBar1.Width / 2, 7 + progressBar1.Height / 2);
            button3.Location = new Point(progressBar1.Right + 20, 15);
            label4.Location = new Point(progressBar1.Left - label4.Width, 28);
            button7.Enabled = false;
           //************ splitContainer1.Panel2.Controls.Remove(splitContainer2);
            button2.Visible = false;
            chart1.MouseWheel += (sender, e) => Loads.Chart1_MouseWheel((Chart)sender, e, chart1, DataStorage.Counter);
            chart1.FormatNumber += (sender, e) => Loads.chart1_FormatNumber(sender, e);
            dataGridView1.CellFormatting += (sender, e) => Loads.DataGridView1_CellFormatting((DataGridView)sender, e);
            // seriesadd(panel2, DataStorage.DataList);
            dateTimePicker1.MinDate = (new DateTime(2022, 09, 15));
            Connection.conn.Open();
            SQLiteCommand read = new SQLiteCommand($"SELECT Tarih__Saat_A1_HT31 FROM tablo", Connection.conn);
            SQLiteDataReader reader = read.ExecuteReader();
            reader.Read();

            string a = reader[0].ToString();
            Connection.conn.Close();

            string yeniTarihVeSaat = a.Substring(0, a.Length - 3);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTime dtObj = DateTime.ParseExact(yeniTarihVeSaat, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            string tarih = dtObj.ToString("yyyy-MM-dd HH:mm:ss");
            dtObj = DateTime.ParseExact(tarih, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Value = dtObj;
            chart1.Paint += (sender, e) => Loads.chart1_Paint((Chart)sender, e);
            graphics = chart1.CreateGraphics();
            chart1.MouseMove += (sender, e) => Loads.chart1_MouseMove(sender, e, chart1, customToolTip);
            //  toolTip1.Draw += toolTip1_Draw;
            customToolTip.Draw += customToolTip_Draw;
            FillCheckboxList();
            splitContainer2.SplitterDistance = 20 * button1.Height + 50;
            groupBox1.Width = panel2.Width;
           
        }

        public List<string> checkBoxList = new List<string>();
        public List<CheckBox> deneme = new List<CheckBox>();
        private void FillCheckboxList()
        {
            try
            {
                // Veritabanı bağlantısını açma
                Connection.conn.Open();

                // Veritabanından series tablosundaki verileri alacak sorgu
                string query = "SELECT series_name FROM series";
                SQLiteCommand command = new SQLiteCommand(query, Connection.conn);

                // Verileri okuma
                SQLiteDataReader reader = command.ExecuteReader();

                // Checkbox listesini temizleme
                checkBoxList.Clear();

                // Verileri checkbox listesine ekleyerek doldurma
                while (reader.Read())
                {
                    string seriesName = reader["Series_name"].ToString();
                    checkBoxList.Add(seriesName);
                }

                // Veritabanı bağlantısını kapatma
                Connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);


            }
            foreach (string s in checkBoxList)
            {
                System.Windows.Forms.CheckBox checkBox = new System.Windows.Forms.CheckBox();
                checkBox.Text = s.ToString();
                checkBox.Checked = true;
                deneme.Add(checkBox);
            }
        }

        public void CustomToolTip_Popup(object sender, PopupEventArgs e)
        {
            // Balon tooltip'in boyutunu ayarlamak için kullanılır
            e.ToolTipSize = new Size(200, 200);
        }
        private void CustomToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, e.Font, Brushes.Red, e.Bounds);
        }

        private void AnaForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void AnaForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                string filePath = files[0]; // İlk dosya yolunu al
                if (!list.Contains(filePath))
                {
                    list.Add(filePath); // TextBox'a dosya yolunu yaz
                    foreach (string file in files)
                    {
                        listBox1.Items.Add(Path.GetFileName(file));

                    }
                }
                else
                {
                    MessageBox.Show("bu dosya zaten var");
                }

            }
        }




        private void Anaform_Resize(object sender, EventArgs e)
        {
            with = (panel3.Width - label3.Width) / 2;
            height = (panel3.Height - label3.Height) / 2;
            label3.Location = new Point(with, height);
            //splitContainer1.SplitterDistance = 205;
            //if (splitContainer1.Panel1.Width > 170)
            //{
            //    button1.Visible = true;
            //    button4.Visible = true;
            //    button5.Visible = true;
            //    label1.Visible = false;
            //    label2.Visible = true;
            //}
            // splitContainer2.SplitterDistance = 870;
            chart1.Invalidate();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.BackColor = SystemColors.Highlight;
            button2.Visible = true;
            int konum = 27;
            if (listBox1.SelectedItem != null)
            {
                if (listBox1.SelectedIndex > 1)
                {
                    konum++;
                }
                if (listBox1.SelectedIndex > 3)
                {
                    konum = konum + 2;
                }
                konum = konum - listBox1.SelectedIndex;
                konum = konum * listBox1.SelectedIndex;
                button2.Location = new Point(300, konum);

            }
        }


        private void progressBar1_Resize(object sender, EventArgs e)
        {
            label6.Location = new Point(panel3.Left + progressBar1.Width / 2, 7 + progressBar1.Height / 2);
        }
        int g = 0;


        private void Form2_Closed(object sender, EventArgs e)
        {


            DataStorage.DataList.Clear();
            controlcheck.Clear();


            Fonks.ShowData(dataGridView1, sorgu, a, 0, DataStorage.formattedDateTime);
            // seriesadd(panel2, DataStorage.DataList);
        }

        public async void seriesadd(Panel panel1, List<System.Windows.Forms.CheckBox> checkBoxes3)
        {
            List<string> list = new List<string>();
            Fonks.Colums(list);
            int j = 0, i = 0;
            foreach (var sutun in list)
            {
                CheckBox yeniCheckBox = new CheckBox();
                yeniCheckBox.Text = sutun;
                yeniCheckBox.Checked = false;
                lis(yeniCheckBox, checkBoxes3);
                // yeniCheckBox.CheckedChanged += CheckBox_CheckedChanged1;
                // checkBoxes3.Add(yeniCheckBox);
                panel2.Controls.Add(yeniCheckBox);

                yeniCheckBox.Location = new Point(k, d);
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
                yeniCheckBox.CheckedChanged += CheckBox_CheckedChanged3;
            }

            panel2.Visible = true;

        }
        private void customToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Yellow, e.Bounds); // Arka planı sarı yapın

            // Başlık metnini çizin
            using (System.Drawing.Font font = new System.Drawing.Font("Arial", 20))
            {
                e.Graphics.DrawString(e.ToolTipText, font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            }
        }

        private void customToolTip_Popup(object sender, PopupEventArgs e)
        {
            // Başlık genişliğine 20 piksel ekleyerek tooltip'un genişliğini artırın
            int additionalWidth = 200;
            e.ToolTipSize = TextRenderer.MeasureText(customToolTip.ToolTipTitle, new System.Drawing.Font("Arial", 10)) + new Size(additionalWidth, 20);
        }


        // ToolTip oluşturulduğunda özel çizim olaylarına bağlanın
        private void InitializeCustomToolTip()
        {
            customToolTip.OwnerDraw = true;
            customToolTip.Draw += customToolTip_Draw;
            customToolTip.Popup += customToolTip_Popup;
        }


        public void UpdateChart(List<CheckBox> selectedCheckboxes)
        {
            // selectedCheckboxes listesindeki CheckBox'lara göre Chart grafiğini güncelle


            checkBoxes = selectedCheckboxes;
            foreach (CheckBox checkbox in selectedCheckboxes)
            {
                if (checkbox.Checked == true && !DataStorage.Colums.Contains(checkbox.Text))
                {

                    DataStorage.Colums.Add(checkbox.Text);
                    Fonks.ShowData(dataGridView1, sorgu, 2000, 0, DataStorage.formattedDateTime);
                }
                else
                {
                    // DataStorage.Colums.Remove(checkbox.Text);
                    Fonks.ShowData(dataGridView1, sorgu, a, b, DataStorage.formattedDateTime);
                }

                Fonks.control(chart1, checkbox, dataGridView1, a, b, dateTimePicker1, DataStorage.formattedDateTime, customToolTip);
            }
        }

        private void CheckBox_CheckedChanged3(object sender, EventArgs e)
        {

            CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            // DateTime selectedDateTime = grafik.dateTimePicker1.Value; // DateTimePicker kontrolünden seçilen değeri alır

            DataStorage.formattedDateTime = DataStorage.selectedDateTime.ToString("yyyyMMddHHmmss"); // Belirtilen formata göre string'e dönüştürür
            DataStorage.formattedDateTime = DataStorage.formattedDateTime + "000";


            if (checkBox.Checked == true)
            {

                DataStorage.Colums.Add(checkBox.Text);
                Fonks.ShowData(dataGridView1, sorgu, 2000, 0, DataStorage.formattedDateTime);
            }
            else
            {
                DataStorage.Colums.Remove(checkBox.Text);
                Fonks.ShowData(dataGridView1, sorgu, a, b, DataStorage.formattedDateTime);
            }

            Fonks.control(chart1, checkBox, dataGridView1, a, b, dateTimePicker1, DataStorage.formattedDateTime, customToolTip);


        }
        public static List<System.Windows.Forms.CheckBox> checkBoxes3 = new List<System.Windows.Forms.CheckBox>();
        public List<System.Windows.Forms.CheckBox> lis(System.Windows.Forms.CheckBox c, List<System.Windows.Forms.CheckBox> cl)
        {
            checkBoxes3 = new List<System.Windows.Forms.CheckBox>();
            cl.Add(c);
            return cl;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            b = 0;
            DataStorage.selectedDateTime = dateTimePicker1.Value; // DateTimePicker kontrolünden seçilen değeri alır
                                                                  // checkBoxes3 = new List<System.Windows.Forms.CheckBox> ();
            DataStorage.formattedDateTime = DataStorage.selectedDateTime.ToString("yyyyMMddHHmmss"); // Belirtilen formata göre string'e dönüştürür
            DataStorage.formattedDateTime = DataStorage.formattedDateTime + "000";
            UpdateChart(DataStorage.selectedCheckboxes);
            Fonks.ShowData(dataGridView1, sorgu, a, b, DataStorage.formattedDateTime);
            // Fonks.Checks(DataStorage.DataList, chart1, a, b, dateTimePicker1, DataStorage.formattedDateTime);
            Fonks.Checks(DataStorage.DataList, chart1, a, b, dateTimePicker1, DataStorage.formattedDateTime, customToolTip);
           // MessageBox.Show(DataStorage.formattedDateTime);

        }


        public List<System.Windows.Forms.CheckBox> checkBoxes = new List<System.Windows.Forms.CheckBox>();



        public async Task add()
        {
            string tabload = "tablo";
            string tablo = Fonks.tabload(tabload);
            await Task.Run(async () =>
            {
                foreach (string s in list)
                {
                    dosyayolu = list[0];
                    int sayi2 = Fonks.SayiSatirSayisiniAl(dosyayolu);
                    sayi2 = (sayi2 / 100) + 1;
                    int sayi3 = sayi2;
                    var allines = System.IO.File.ReadAllLines(dosyayolu);
                    string[] dizi = new string[allines.Length];

                    progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = 0));
                    progressBar1.Invoke((MethodInvoker)(() => progressBar1.Maximum = 100));
                    List<string> metin = new List<string>();
                    cmd = new SQLiteCommand();
                    con = new SQLiteConnection(Connection.conn);
                    cmd.Connection = con;

                    string query = $"insert into {tablo}({Fonks.TabloBaslıkları(dosyayolu)}) values(";
                    string query2 = "";
                    int j = 1;

                    using (StreamReader reader = new StreamReader(dosyayolu))
                    {
                        string dfghj = reader.ReadLine();
                        List<string> lines = new List<string>();
                        string line = "";
                        //progressBar1.Visible = true;
                        progressBar1.Value = 0;
                        string sql = $"DELETE FROM tablo";

                        using (SQLiteConnection connection = new SQLiteConnection(con))
                        {
                            await con.OpenAsync();

                            SQLiteCommand komut = new SQLiteCommand(sql, con);
                            komut.ExecuteNonQuery();
                            MessageBox.Show("basarılı");
                            List<string> dataList = new List<string>();
                            using (var transaction = con.BeginTransaction())
                            {
                                while (!reader.EndOfStream)
                                {
                                    query2 = "";
                                    query = $"insert into {tablo}({Fonks.TabloBaslıkları(dosyayolu)}) values(";


                                    line = reader.ReadLine();
                                    lines = new List<string>(line.Split(";"));

                                    if (j == sayi2 && progressBar1.Value < 100)
                                    {
                                        ChangeProgressBarValue(progressBar1.Value);
                                        progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value++));
                                        sayi2 = sayi2 + sayi3;

                                    }
                                    for (int i = 0; i < lines.Count; i++)
                                    {

                                        lines[i] = lines[i].Replace(".", "_").Replace("/", "").Replace("_", "").Replace(":", "").Replace(" ", "");
                                        query2 += $"{lines[i]},";
                                    }
                                    lines.Clear();
                                    query += query2;
                                    int count = query.Length;
                                    string changedQuery = query.Substring(0, count - 2) + "";

                                    changedQuery += ");";

                                    j++;

                                    using (SQLiteCommand command = con.CreateCommand())
                                    {
                                        //await con.OpenAsync();
                                        command.CommandText = changedQuery;
                                        await command.PrepareAsync();
                                        await command.ExecuteNonQueryAsync();
                                    }
                                    //});

                                }
                                transaction.Commit();
                            }
                            con.Close();

                        }
                    }
                }
            });


            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = 100));
            label6.Text = "% 100";
            MessageBox.Show("Yükleme Tamamlandı");
        }
        private void ChangeProgressBarValue(int newValue)
        {
            progressBar1.Value = newValue;
            if (newValue > 51)
                label6.BackColor = ColorTranslator.FromHtml("#06b025");


            if (label6.InvokeRequired)
            {
                label6.Invoke((MethodInvoker)(() => label6.Text = "% " + newValue.ToString()));
            }
            else
            {
                label6.Text = "% " + newValue.ToString();
            }

        }
        private void Anaform_FormClosed(object sender, FormClosedEventArgs e)
        {
            chart1.MouseMove -= (sender, e) => Loads.chart1_MouseMove(sender, e, chart1, customToolTip);
        }
        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, e.Font, Brushes.Red, new PointF(2, 2));

        }
        /************************************************************************                Buttons               *******************************************************************************************************************/
        private void button2_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (listBox1.SelectedItem != null)
            {
                index = listBox1.SelectedIndex;
                listBox1.Items.Remove(listBox1.SelectedItem);
                list.RemoveAt(index);
            }
            button2.Visible = false;

        }
        private async void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label4.Visible = true;
            label6.Visible = true;


            //await Task.Run(async () =>
            //{
            await add();
            //});
        }
        private void button7_Click(object sender, EventArgs e)
        {
            b = b - 2000;

            //checkBoxes = DataStorage.DataList;
            if (b <= 2000)
            {
                button7.Enabled = false;
            }

            Fonks.ShowData(dataGridView1, sorgu, a, b, DataStorage.formattedDateTime);
            Fonks.Checks(checkBoxes, chart1, a, b, dateTimePicker1, DataStorage.formattedDateTime, customToolTip);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // checkBoxes = DataStorage.DataList;
            b = b + 2000;
            Fonks.ShowData(dataGridView1, sorgu, a, b, DataStorage.formattedDateTime);
            button7.Enabled = true;

            Fonks.Checks(checkBoxes, chart1, a, b, dateTimePicker1, DataStorage.formattedDateTime, customToolTip);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            deger = "data";
            button9.Visible = false;
            button10.Visible = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            chart1.Visible = false;
            //chart1.Controls.Clear();
            dataGridView1.Visible = true;
            if (g <= 0)
            {
                foreach (Control c in panel3.Controls)
                {
                    if (c is not SplitContainer)
                    {
                        c.Visible = false;
                    }
                }
            }

            if (!panel3.Contains(splitContainer2))
                panel3.Controls.Add(splitContainer2);
            g++;
            splitContainer2.Visible = true;
            Fonks.ShowData(dataGridView1, "", 2000, 0, DataStorage.formattedDateTime);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel3.Contains(splitContainer2))
               panel3.Controls.Add(splitContainer2);
            g++;
            button7.Visible = true;
            button6.Visible = true;
            splitContainer2.Visible = true;
            label3.Visible = false;
            listBox1.Visible = false;
            label7.Visible = false;
            label7.Location = new Point(splitContainer2.Panel2.Width / 2, splitContainer2.Panel1.Height - 21);
            label8.Location = new Point(splitContainer2.Panel2.Width / 2, label7.Height - 50);
            splitContainer2.SplitterDistance = 870;
            label7.BackColor = panel3.BackColor;
            DataStorage.Counter = 1;
            Form2 form2 = new Form2(); // Form2'yi oluşturur
            form2.FormClosed += Form2_Closed;
            form2.Show();
            chart1.Series.Clear();
            DataStorage.Colums.Clear();
            y = 0; z = 0; k = 0; l = 0; d = 30; m = 0;

        }
        string deger = "";
        private void button1_Click(object sender, EventArgs e)
        {
            button10.Visible = false;

            deger = "grafik";
            label5.Visible = true;
            if (g <= 0)
            {
                foreach (Control c in panel3.Controls)
                {
                    if (c is not SplitContainer)
                    {
                        c.Visible = false;
                    }
                }
            }
            dataGridView1.Visible = false;
            Loads.LoadGrafik(with, splitContainer2, dateTimePicker1, dtobj2, dataGridView1, DataStorage.formattedDateTime);
            chart1.Visible = true;
            if (!panel3.Contains(splitContainer2))
                panel3.Controls.Add(splitContainer2);
            g++;
            splitContainer2.Visible = true;
            label7.Visible = false;
            label7.Location = new Point(splitContainer2.Panel2.Width / 2, splitContainer2.Panel1.Height - 21);
            label8.Location = new Point(splitContainer2.Panel2.Width / 2, label7.Height - 50);
            splitContainer2.SplitterDistance = 1000;
            label7.BackColor = panel3.BackColor;
            chart1.Series.Clear();
            if (DataStorage.Counter < 1 || DataStorage.selectedCheckboxes.Count == 0)
            {
                DataStorage.Counter = 1;
                UpdateChart(deneme);
            }
            else
            {
                DataStorage.iii = 0;

                UpdateChart(DataStorage.selectedCheckboxes);


            }



        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Black;
        }
        /*****************************************************************************                    Labels            ************************************************************************************************************************************/
        private void label3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Metin dosyası seçin";
            openFileDialog1.Filter = "Metin dosyaları(*.csv;.docx;.txt)|*.csv;*docx;*txt";
            // openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK && !list.Contains(openFileDialog1.FileName))
            {
                // Dosya seçildiyse ListBox'a ekle
                list.Add(openFileDialog1.FileName);
                listBox1.Items.Add(Path.GetFileName(openFileDialog1.FileName));
                button3.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           // label2.Visible = true;
            //splitContainer1.SplitterDistance = 205;
            //label1.Visible = false;
            button1.Visible = true;
            button4.Visible = true;
            progressBar1.Width = panel3.Width - 500;
            progressBar1.Location = new Point(panel3.Left, 15);
            button3.Location = new Point(progressBar1.Right + 20, 15);
            label4.Location = new Point(progressBar1.Left - label4.Width, 28);
            button5.Visible = true;
        }
        //private void label1_Click(object sender, EventArgs e)
        //{
        //    label2.Visible = true;
        //    splitContainer1.SplitterDistance = 205;
        //    label1.Visible = false;
        //    button1.Visible = true;
        //    button4.Visible = true;
        //    progressBar1.Width = splitContainer1.Panel2.Width - 500;
        //    progressBar1.Location = new Point(splitContainer1.Panel2.Left, 15);
        //    button3.Location = new Point(progressBar1.Right + 20, 15);
        //    label4.Location = new Point(progressBar1.Left - label4.Width, 28);
        //    button5.Visible = true;
        //}

        private void label2_Click(object sender, EventArgs e)
        {
           // splitContainer1.SplitterDistance = label1.Width;
//label1.Visible = true;
          //  label2.Visible = false;
            button1.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }
        //private void label2_Click(object sender, EventArgs e)
        //{
        //    splitContainer1.SplitterDistance = label1.Width;
        //    label1.Visible = true;
        //    label2.Visible = false;
        //    button1.Visible = false;
        //    button4.Visible = false;
        //    button5.Visible = false;
        //}
        private void label2_MouseHover(object sender, EventArgs e)
        {
            //label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            //label2.ForeColor = Color.Black;
        }
        private void label5_Click(object sender, EventArgs e)
        {

            splitContainer2.Visible = false;
            panel1.Visible = true;
            label3.Visible = true;
            listBox1.Visible = true;
            label4.Visible = false;
            progressBar1.Visible = false;
            g = 0;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label7_Click(object sender, EventArgs e)
        {

            if (deger == "grafik")
            {
                button9.Visible = true;
            }
            else if (deger == "data")
            {
                button10.Visible = true;
            }
            else
            {
                button9.Visible = false;
                button10.Visible = false;
            }
            splitContainer2.SplitterDistance = 870;
            label7.Visible = false; label8.Visible = true;
            groupBox1.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            // label1.Location=label2.Location;
            groupBox1.Visible = false;
            label8.Visible = false;
            splitContainer2.SplitterDistance = splitContainer2.Height - label8.Size.Height;
            button9.Visible = false;
            button10.Visible = true;
        }

        private void label8_BackColorChanged(object sender, EventArgs e)
        {
            label8.BackColor = splitContainer2.Panel2.BackColor;
        }
        /*******************************************************************************        Container    ******************************************************************************************************************/
        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
        ////    if (splitContainer1.Panel1.Width < 170)
        ////    {
        ////        splitContainer1.SplitterDistance = label1.Width;
        ////        label1.Visible = true;
        ////        label2.Visible = false;
        ////        button1.Visible = false;
        ////        button4.Visible = false;
        ////        button5.Visible = false;
        ////    }
        ////    button1.Width = splitContainer1.Panel1.Width;
        ////    button4.Width = splitContainer1.Panel1.Width;
        ////    button5.Width = splitContainer1.Panel1.Width;
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            progressBar1.Width = panel3.Width - 500;
            progressBar1.Location = new Point(panel3.Left, 15);
            button3.Location = new Point(progressBar1.Right + 20, 15);
            label4.Location = new Point(progressBar1.Left - label4.Width, 28);
        }

        private void splitContainer2_Panel1_Resize(object sender, EventArgs e)
        {
            with = panel3.Size.Width - 20;
            //   label1.Location = new Point(with, 0);
            label7.Location = new Point(splitContainer2.Panel2.Width / 2, splitContainer2.Panel1.Height - 21);
            label8.Location = new Point(splitContainer2.Panel2.Width / 2, label7.Height - 50);
            // label1.Location = new Point(splitContainer1.Panel2.Width / 2, label3.Height - 50);
            splitContainer2.Panel2.BackColor = Color.GhostWhite;
            if (splitContainer2.SplitterDistance > 870)
            {
                label7.Visible = true;
                // label1.Visible = true;
                label8.Visible = false;
                splitContainer2.SplitterDistance = splitContainer2.Height - label8.Size.Height;
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;

            }
        }

        private void splitContainer2_Resize(object sender, EventArgs e)
        {
            label7.Location = new Point(splitContainer2.Panel2.Width / 2, splitContainer2.Panel1.Height - 21);
            label8.Location = new Point(splitContainer2.Panel2.Width / 2, label7.Height - 50);
            if (splitContainer2.SplitterDistance > 900)
            {

                label7.Visible = true;
                label8.Visible = false;
                splitContainer2.SplitterDistance = splitContainer2.Height - label8.Size.Height;
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void splitContainer2_Panel2_Resize(object sender, EventArgs e)
        {
            label5.Location = new Point(splitContainer2.Panel2.Width - 20, 0);
            label7.Location = new Point(splitContainer2.Panel2.Width / 2, splitContainer2.Panel1.Height - 21);
            label8.Location = new Point(splitContainer2.Panel2.Width / 2, label7.Height - 50);

            if (label8.Visible == false)
            {
                if (splitContainer2.SplitterDistance < 600)
                {
                    label7.Visible = true;
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            groupBox1.Width = panel2.Width;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
            chart1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart1.Width, chart1.Height));

            // Bitmap dosyasını JPEG formatında geçici bir dosyaya kaydedin
            string tempImagePath = Path.Combine(Path.GetTempPath(), "chartImage.jpg");
            bmp.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Word uygulamasını başlatın ve belge oluşturun
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();

            try
            {
                // Word belgesine görüntüyü ekleyin
                Word.Paragraph para = doc.Content.Paragraphs.Add();
                Word.InlineShape shape = para.Range.InlineShapes.AddPicture(tempImagePath);

                // Word belgesini kaydedin ve uygulamayı kapatın
                doc.SaveAs2(@"C:\Users\MURATVARLI\Desktop\chart.docx");
                MessageBox.Show("Chart başarıyla PDF'e aktarıldı.");
                MessageBox.Show("Geçici dosya yol: " + tempImagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                // Kullanılan kaynakları temizleyin
                doc.Close();
                wordApp.Quit();

                // Geçici dosyayı silebilirsiniz
                File.Delete(tempImagePath);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
            chart1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart1.Width, chart1.Height));

            // iTextSharp kütüphanesini kullanarak PDF oluşturma işlemi
            iTextSharp.text.Document doc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(chart1.Width, chart1.Height)); // Grafik boyutunda bir PDF oluştur
                                                                                                                                     //  PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\MURATVARLI\Desktop\chartttt.pdf", FileMode.Create));
                                                                                                                                     //  doc.Open();

            // Bitmap'i PDF'e ekleme
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp);
            // doc.Add(image);

            // doc.Close();

            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "PDF Dosyaları";
            save.DefaultExt = "pdf";
            save.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {

                using (FileStream stream = new FileStream(save.FileName + ".pdf", FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 20f, 20f, 20f, 20f);// sayfa boyutu.
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();
                    doc.Add(image);
                    doc.Close();
                    stream.Close();
                }
            }

            MessageBox.Show("Pdf olarak kaydedildi");









        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "PDF Dosyaları";
            save.DefaultExt = "pdf";
            save.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.
                pdfTable.DefaultCell.Padding = 3; // hücre duvarı ve veri arasında mesafe
                pdfTable.WidthPercentage = 10; // hücre genişliği
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT; // yazı hizalaması
                pdfTable.DefaultCell.BorderWidth = 1; // kenarlık kalınlığı
                pdfTable.WidthPercentage = 50;
                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // hücre arka plan rengi
                    pdfTable.AddCell(cell);
                }
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string tarihStr = row.Cells[0].Value.ToString();
                            string tarihFormatli = ""; // Parçalanmış tarih

                            if (tarihStr.Length >= 14) // En azından tarih formatı kadar karakter olmalı
                            {
                                // Tarihi parçala ve doğru formatta olup olmadığını kontrol et
                                string yil = tarihStr.Substring(0, 4);
                                string ay = tarihStr.Substring(4, 2);
                                string gun = tarihStr.Substring(6, 2);
                                string saat = tarihStr.Substring(8, 2);
                                string dakika = tarihStr.Substring(10, 2);
                                string saniye = tarihStr.Substring(12, 2);

                                if (DateTime.TryParse($"{gun}.{ay}.{yil} {saat}:{dakika}:{saniye}", out DateTime tarih))
                                {
                                    tarihFormatli = tarih.ToString("dd.MM.yyyy HH:mm:ss"); // PDF'e tarih ve saat formatında ekle
                                }
                            }

                            pdfTable.AddCell(tarihFormatli); // Parçalanmış tarihi ekleyin
                        }
                        else
                        {
                            pdfTable.AddCell(""); // İlk sütundaki boş hücreler için boş bir hücre ekle
                        }

                        // Diğer sütunları doğrudan ekleyin
                        for (int i = 1; i < dataGridView1.Columns.Count; i++)
                        {
                            pdfTable.AddCell(row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "");
                        }

                    }
                }
                catch (NullReferenceException)
                {
                }
                using (FileStream stream = new FileStream(save.FileName + ".pdf", FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A0, 0f, 0f, 10f, 10f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            }

            MessageBox.Show("Pdf olarak kaydedildi");
            // @"C:\Users\MURATVARLI\Desktop\dataaa.pdf"


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

