using System;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Transactions;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using static System.Net.Mime.MediaTypeNames;

namespace deneme4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //progressBar1.ValueChanged += ProgressBar1_ValueChanged;
        }
        //int adet = 1000;
        SQLiteConnection con;
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;
        string dosyayolu = "";
        string formattedDateTime;
        List<string> list = new List<string>();
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int with;
        int height;

     
        private void Form1_Load(object sender, EventArgs e)
        {
            
            with = (splitContainer1.Panel2.Width - label3.Width) / 2;
            height = (splitContainer1.Panel2.Height - label3.Height) / 2;
            label3.Location = new Point(with, height);
            label1.Visible = false;
            splitContainer1.SplitterDistance = 205;
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            progressBar1.Width = splitContainer1.Panel2.Width - 500;
            progressBar1.Location = new Point(splitContainer1.Panel2.Left, 15);
            label6.Location = new Point(splitContainer1.Panel2.Left + progressBar1.Width / 2, 7 + progressBar1.Height / 2);
            button3.Location = new Point(progressBar1.Right + 20, 15);
            label4.Location = new Point(progressBar1.Left - label4.Width, 28);
            button2.Visible = false;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                string filePath = files[0]; // Ýlk dosya yolunu al
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
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            splitContainer1.SplitterDistance = 205;
            label1.Visible = false;
            button1.Visible = true;
            button4.Visible = true;
            progressBar1.Width = splitContainer1.Panel2.Width - 500;
            progressBar1.Location = new Point(splitContainer1.Panel2.Left, 15);
            button3.Location = new Point(progressBar1.Right + 20, 15);
            label4.Location = new Point(progressBar1.Left - label4.Width, 28);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = label1.Width;
            label1.Visible = true;
            label2.Visible = false;
            button1.Visible = false;
            button4.Visible = false;
        }
        Grafik grafik = new Grafik();
        // Form2 form2 = new Form2();

        public static int y = 0, z = 0, k = 0, l = 0, d = 30, m = 0;
        // private List<System.Windows.Forms.CheckBox> checkBoxes;
        public int targetX = 100;
        public static class DataStorage {

            public static string formattedDateTime = "";
            public static int Counter=0;
            public static int iii = 0;
            public static List<string> values { get; set; } = new List<string>();
            public static List<CheckBox> DataList { get; set; } = new List<CheckBox>();
            public static List<CheckBox> cntrl { get; set; } = new List<CheckBox>();
            public static DateTime selectedDateTime;
            public static List <string> checboxname { get; set; } = new List<string>();
            public static List<string> Colums { get; set; } = new List<string>();
            public static List<CheckBox> selectedCheckboxes { get; set; } = new List<CheckBox>();
        }
        public static List<string> controlcheck = new List<string>();

        public async void seriesadd(Panel panel1, List<System.Windows.Forms.CheckBox> checkBoxes3)
        {
            y = 0; z = 0; k = 0; l = 0; d = 30; m = 0;
            List<string> list = new List<string>();
            Fonks.Colums(list);

            Grafik grafik = new Grafik();
            int j = 0, i = 0;
            //DataStorage.DataList.Clear();
            foreach (var sutun in list)
            {
                if (!controlcheck.Contains(sutun))
                {


                    System.Windows.Forms.CheckBox yeniCheckBox = new System.Windows.Forms.CheckBox();
                    yeniCheckBox.Text = sutun;
                   
                    yeniCheckBox.Checked = false;
                    // grafik.lis(yeniCheckBox, checkBoxes3);
                    controlcheck.Add(sutun);
                    // yeniCheckBox.CheckedChanged += CheckBox_CheckedChanged1;
                    //checkBoxes3.Add(yeniCheckBox);
                    panel1.Controls.Add(yeniCheckBox);
                    yeniCheckBox.Location = new Point(k, d);
                    if (!DataStorage.DataList.Contains(yeniCheckBox))
                    {
                        DataStorage.DataList.Add(yeniCheckBox);

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
                        yeniCheckBox.CheckedChanged += CheckBox_CheckedChanged1;

                    }

                }
            }
            panel1.Visible = true;
            // DataStorage.DataList = checkBoxes3;

            // list.Clear();
        }
        public List<System.Windows.Forms.CheckBox> checkBoxes3 = new List<System.Windows.Forms.CheckBox>();
        string sorgu = "";
        private void CheckBox_CheckedChanged1(object sender, EventArgs e)
        {

            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            // DateTime selectedDateTime = grafik.dateTimePicker1.Value; // DateTimePicker kontrolünden seçilen deðeri alýr

            formattedDateTime = DataStorage.selectedDateTime.ToString("yyyyMMddHHmmss"); // Belirtilen formata göre string'e dönüþtürür
            formattedDateTime = formattedDateTime + "000";
            
            if (checkBox.Checked == true)
            {
                DataStorage.Colums.Add(checkBox.Text);
               Fonks.ShowData(grafik.dataGridView1, sorgu, 2000, 0, formattedDateTime);
            }
            else
            {
                DataStorage.Colums.Remove(checkBox.Text);
                Fonks.ShowData(grafik.dataGridView1, sorgu, grafik.a, grafik.b, formattedDateTime);
            }

            //Fonks.control(grafik.chart1, checkBox, grafik.dataGridView1, grafik.a, grafik.b, grafik.dateTimePicker1, formattedDateTime);


        }
        public void clk()
        {
            for (int i = grafik.panel1.Controls.Count - 1; i >= 0; i--)
            {
                Control control = grafik.panel1.Controls[i];
                if (control is CheckBox)
                {
                    DataStorage.DataList.Remove(control as CheckBox);
                    grafik.panel1.Controls.Remove(control);
                }
            }
            DataStorage.DataList.Clear();
            controlcheck.Clear();

            int a = grafik.a; int b = grafik.b;
            grafik.chart1.Series.Clear();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(label5);
            Fonks.ShowData(grafik.dataGridView1, sorgu, a, b, "20220916172055000");
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.Location = new Point(splitContainer1.Panel2.Width - label5.Width, 0);
            label5.Visible = true;
            grafik.splitContainer1.Panel1.Controls.Clear();
            grafik.splitContainer1.Panel1.Controls.Add(grafik.label3);
            grafik.splitContainer1.Panel1.Controls.Add(grafik.chart1);

            grafik.TopLevel = false;
            splitContainer1.Panel2.Controls.Add(grafik);
            grafik.Dock = DockStyle.Fill;
            grafik.FormBorderStyle = FormBorderStyle.None;
            grafik.Size = splitContainer1.Panel2.Size;

            seriesadd(grafik.panel1, DataStorage.DataList);
            grafik.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            clk();




        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            grafik.Size = splitContainer1.Panel2.Size;

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            with = (splitContainer1.Panel2.Width - label3.Width) / 2;
            height = (splitContainer1.Panel2.Height - label3.Height) / 2;
            label3.Location = new Point(with, height);
            splitContainer1.SplitterDistance = 205;
            if (splitContainer1.Panel1.Width > 170)
            {
                button1.Visible = true;
                button4.Visible = true;
                label1.Visible = false;
                label2.Visible = true;
            }
          

        }

        private void button1_Resize(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1.Width < 170)
            {
                splitContainer1.SplitterDistance = label1.Width;
                label1.Visible = true;
                label2.Visible = false;
                button1.Visible = false;
                button4.Visible = false;
            }
            button1.Width = splitContainer1.Panel1.Width;
            button4.Width = splitContainer1.Panel1.Width;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {

            label2.ForeColor = Color.Red;

        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

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

        private void listBox1_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Metin dosyasý seçin";
            openFileDialog1.Filter = "Metin dosyalarý(*.csv;.docx;.txt)|*.csv;*docx;*txt";
            openFileDialog1.ShowDialog();
            list.Add(openFileDialog1.FileName);
            listBox1.Items.Add(Path.GetFileName(openFileDialog1.FileName));
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Black;
        }

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
                    // List<string> dataList = new List<string>();

                    //for (int i = 0; i < allines.Length; i++)
                    //{
                    //    dataList.Add(allines[i]);
                    //}
                    progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = 0));
                    progressBar1.Invoke((MethodInvoker)(() => progressBar1.Maximum = 100));
                    // StreamReader sr = new StreamReader(dosyayolu);
                    List<string> metin = new List<string>();
                    cmd = new SQLiteCommand();
                    con = new SQLiteConnection(Connection.conn);
                    cmd.Connection = con;

                    string query = $"insert into {tablo}({Fonks.TabloBaslýklarý(dosyayolu)}) values(";
                    string query2 = "";
                    int j = 1;

                    using (StreamReader reader = new StreamReader(dosyayolu))
                    {
                        string dfghj = reader.ReadLine();
                        List<string> lines = new List<string>();
                        string line = "";
                        //progressBar1.Visible = true;
                        progressBar1.Value = 0;
                        using (SQLiteConnection connection = new SQLiteConnection(con))
                        {
                            await con.OpenAsync();
                            List<string> dataList = new List<string>();
                            using (var transaction = con.BeginTransaction())
                            {
                                while (!reader.EndOfStream)
                                {
                                    query2 = "";
                                    query = $"insert into {tablo}({Fonks.TabloBaslýklarý(dosyayolu)}) values(";


                                    line = reader.ReadLine();
                                    lines = new List<string>(line.Split(";"));

                                    if (j == sayi2 && progressBar1.Value<100)
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
                                    // changedQuery += $" WHERE NOT EXISTS(SELECT 1 FROM Path   where Path = '{s}')";
                                    changedQuery += ");";

                                    j++;

                                    //dataList.Add(changedQuery);
                                    //con.Close();
                                    //Parallel.ForEach(dataList, async data =>
                                    //{
                                    // Veritabaný iþlemleri burada gerçekleþtirilir

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

                        }
                    }
                }
            });


            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = 100));
            label6.Text = "% 100";
            MessageBox.Show("Yükleme Tamamlandý");
        }
        private void ChangeProgressBarValue(int newValue)
        {
            progressBar1.Value = newValue;
            if (newValue > 51)
                label6.BackColor = ColorTranslator.FromHtml("#06b025");


            if (label6.InvokeRequired)
            {
                label6.Invoke((MethodInvoker)(() => label6.Text = "% "+ newValue.ToString()));
            }
            else
            {
                label6.Text ="% "+ newValue.ToString();
            }

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
        //private async Task button3_Click(object sender, EventArgs e)
        //{
        //    await add();

        //}

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            progressBar1.Width = splitContainer1.Panel2.Width - 500;
            progressBar1.Location = new Point(splitContainer1.Panel2.Left, 15);
            button3.Location = new Point(progressBar1.Right + 20, 15);
            label4.Location = new Point(progressBar1.Left - label4.Width, 28);
        }
        //Form2 form2 = new Form2();
        //Grafik grafik = new Grafik();
        private void button4_Click(object sender, EventArgs e)
        {
            int a = grafik.a; int b = grafik.b;
            grafik.seriesadd(grafik.panel1, DataStorage.DataList);

            DateTime selectedDateTime = grafik.dateTimePicker1.Value; // DateTimePicker kontrolünden seçilen deðeri alýr

            formattedDateTime = selectedDateTime.ToString("yyyyMMddHHmmss"); // Belirtilen formata göre string'e dönüþtürür
            formattedDateTime = formattedDateTime + "000";
            Fonks.ShowData(grafik.dataGridView1, sorgu, 2000, 0, formattedDateTime);
            // Fonks.ShowData($"select * from {tablo} limit 2000", grafik.dataGridView1);


            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(label5);
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.Location = new Point(splitContainer1.Panel2.Width - label5.Width, 0);
            label5.Visible = true;
            grafik.splitContainer1.Panel1.Controls.Clear();
            grafik.splitContainer1.Panel1.Controls.Add(grafik.label3);
            grafik.splitContainer1.Panel1.Controls.Add(grafik.dataGridView1);
            grafik.dataGridView1.Visible = true;
            grafik.TopLevel = false;
            splitContainer1.Panel2.Controls.Add(grafik);
            grafik.Dock = DockStyle.Fill;
            grafik.FormBorderStyle = FormBorderStyle.None;
            grafik.Size = splitContainer1.Panel2.Size;
            grafik.Show();


            //form2.TopLevel = false;
            //splitContainer1.Panel2.Controls.Add(form2);
            //form2.Dock = DockStyle.Fill;
            //form2.FormBorderStyle = FormBorderStyle.None;
            //form2.Size = splitContainer1.Panel2.Size;
            //form2.Show();

        }

        public void CheckBox_CheckedChanged2(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            if (checkBox.Checked)
            {
                // Ýlgili checkbox iþaretlendiðinde yapýlacak iþlemleri burada gerçekleþtirin.
                MessageBox.Show($"Checkbox '{checkBox.Text}' iþaretlendiiii.");
            }
            else
            {
                // Ýlgili checkbox iþareti kaldýrýldýðýnda yapýlacak iþlemleri burada gerçekleþtirin.
                MessageBox.Show($"Checkbox '{checkBox.Text}' iþareti kaldýrýldý.");
            }
        }
        private void checkBox_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            checkBox.Enabled = true;
        }

        const int startX = 200;
        const int startY = 200;
        const int spacingX = 100;
        const int spacingY = 30;
        const int checkboxesPerRow = 10;
        private async void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(grafik.dtObj2.ToString());
        }
        private Dictionary<string, DataPoint[]> originalDataPoints = new Dictionary<string, DataPoint[]>();
        private void StoreOriginalDataPoints()
        {
            originalDataPoints.Clear();

            // Her bir seriyi döngü ile geçelim
            foreach (Series series in grafik.chart1.Series)
            {
                // Serinin adýný kullanarak orijinal veri noktalarýný saklayalým
                DataPoint[] points = new DataPoint[series.Points.Count];
                series.Points.CopyTo(points, 0);
                originalDataPoints.Add(series.Name, points);
            }
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void label5_Click(object sender, EventArgs e)
        {
            grafik.Hide();
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(listBox1);
            label4.Visible = false;
            progressBar1.Visible = false;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<string> controlcheck = new List<string>();
            foreach (Control control in panel1.Controls)
            {
                if (control is CheckBox)
                {
                    controlcheck.Add(control.Text);
                    control.Controls.Remove(control);
                }
            }
            grafik.Show();
        }

        private void progressBar1_Resize(object sender, EventArgs e)
        {
            label6.Location = new Point(splitContainer1.Panel2.Left + progressBar1.Width / 2, 7 + progressBar1.Height / 2);
        }

        private void progressBar1_ForeColorChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        public static implicit operator Form1(Grafik v)
        {
            throw new NotImplementedException();
        }
    }
}
