
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static deneme4.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Label = System.Reflection.Emit.Label;
using ToolTip = System.Windows.Forms.ToolTip;

namespace deneme4
{
    public class Fonks
    {
        public static void AddDataToChart(Chart chart, string sutunad, int i, int j, string textBox, DateTimePicker dt, string formatdate ,System.Windows.Forms.ToolTip tp)
        {
            Connection.conn.Open();
            SQLiteCommand read = new SQLiteCommand($"SELECT Tarih__Saat_A1_HT31, {sutunad} FROM tablo where Tarih__Saat_A1_HT31 > {formatdate}  LIMIT {i}  OFFSET {j}", Connection.conn);
            SQLiteDataReader reader = read.ExecuteReader();

        
            
            string datee;
            reader.Read();
            string a = reader[0].ToString();

            List<DateTime> dateTimeList = new List<DateTime>();

            while (reader.Read())
            {
                datee = reader[0].ToString();
                string trimmedString = datee.Substring(0, datee.Length - 3);
                DateTime date = DateTime.ParseExact(trimmedString, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                dateTimeList.Add(date);
                if(chart.Series.Count > 0) 
                    chart.Series[$"{sutunad}"].Points.AddXY(date, reader[1]);

            }

            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto; // Otomatik tarih aralığı belirleme
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy.MM.dd-HH:mm:ss";
            chart.ChartAreas[0].AxisX.Interval = 100; // Birimler arası tarih farkı
            Connection.conn.Close();
            int c = 0;
        }
        

        public static List<int> maxmin(List<int> list,DataGridView d1,CheckBox c1)
        {
            string columnName = c1.Text; // Sorgulamak istediğiniz sütunun adı
            DataGridViewColumn column = d1.Columns[columnName];

            if (column != null)
            {
                List<int> values = new List<int>();

                // DataGridView'deki tüm satırları dön
                foreach (DataGridViewRow row in d1.Rows)
                {
                    // Eğer hücre boş değilse ve değer numerik bir değerse
                    if (!row.IsNewRow && row.Cells[column.Index].Value != null && decimal.TryParse(row.Cells[column.Index].Value.ToString(), out decimal value))
                    {
                        values.Add(Convert.ToInt32(value)); // Değeri listeye ekle
                    }
                }

                if (values.Count > 0)
                {
                    int maxValue = values.Max(); // Maksimum değeri bul
                    int minValue = values.Min(); // Minimum değeri bul
                    list.Add(maxValue);
                    list.Add(minValue);
                    //MessageBox.Show($"Maksimum Değer: {list.Max()}\nMinimum Değer: {list.Min()}", "Sonuçlar");
                }
                
            }
            return list;
        }
        public static List<int> liste = new List<int> {  };
       
       public static List<CheckBox> acd = new List<CheckBox>();
        public static void control(Chart chart1,CheckBox check,DataGridView d1, int a,int b, DateTimePicker dt, string formatdate,ToolTip tp)
        {
            acd = DataStorage.selectedCheckboxes;

            if (DataStorage.iii == 0) {
                chart1.Series.Clear();
                DataStorage.iii++;
            }
          
            var thresholdValue = 0;
            int i = 0;
          
            Series existingSeries = chart1.Series.FindByName(check.Text);
            if (check.Checked == true )
                {
                
                List<int> list = new List<int>();

                
                    chart1.Series.Add(check.Text);
                    chart1.Series[check.Text].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    chart1.Series[check.Text].IsXValueIndexed = true;
                    DataStorage.values.Add(check.Text);
                    AddDataToChart(chart1, check.Text, a, b, check.Text, dt,formatdate,tp);
                    chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto; // Otomatik tarih aralığı belirleme
                    chart1.ChartAreas[0].AxisX.Interval = 100; // Birimler arası tarih farkı
                    list = maxmin(list, d1, check);
                    liste.AddRange(list);                                        
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 2000;
                    chart1.ChartAreas[0].AxisY.Minimum = liste.Min() - 50;
                    chart1.ChartAreas[0].AxisY.Maximum = liste.Max() + 50;
                
               
                foreach (DataPoint point in chart1.Series[check.Text].Points)
                    {
                    
                    if (point.YValues[0] != thresholdValue || i == 0)
                        {
                            point.MarkerStyle = MarkerStyle.Circle;
                            point.MarkerSize = 8;
                        point.MarkerColor = chart1.Series[check.Text].Color;
                        thresholdValue = Convert.ToInt32(point.YValues[0]);

                        }
                        else
                        {
                            point.MarkerStyle = MarkerStyle.None; // Eşiğin altındaki değerlerde marker kullanma
                        
                         }
                        i++;

                    }
             }
                else
                {
                    DataStorage.values.Remove(check.Text);
                    List<int> list = new List<int>();
                if (list.Count != 0)
                {
                    list = maxmin(list, d1, check);
                    liste.Remove(list.Min());
                    liste.Remove(list.Max());
                }

                if (liste.Count == 0) { 
                    liste.Add(0);
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 2000;
                    chart1.ChartAreas[0].AxisY.Minimum = liste.Min() ;
                    chart1.ChartAreas[0].AxisY.Maximum = liste.Max() ;
                    chart1.Series.Remove(chart1.Series.FindByName(check.Text));
                    liste.Remove(liste.Min());
                }else
                {
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = 2000;
                    chart1.ChartAreas[0].AxisY.Minimum = liste.Min() - 50;
                    chart1.ChartAreas[0].AxisY.Maximum = liste.Max() + 50;
                    chart1.Series.Remove(chart1.Series.FindByName(check.Text));
                }
                   
                
            }
            
        }
           
        public static void Checks(List<CheckBox> checkBoxes, Chart chart, int i, int j, DateTimePicker dt, string formatdate,ToolTip tp)//DataGridView d1)
        {
            int thresholdValue = 0;
            foreach (var series in chart.Series)
            {
                series.Points.Clear(); // Serideki tüm noktaları temizle
            }
            foreach (var check in checkBoxes)
            {
                if (check.Checked == true && chart.Series.Count>0)
                {
                    AddDataToChart(chart, check.Text, i, j, check.Text, dt, formatdate, tp);
                    foreach (DataPoint point in chart.Series[check.Text].Points)
                    {

                        if (point.YValues[0] != thresholdValue || i == 0)
                        {
                            point.MarkerStyle = MarkerStyle.Circle;
                            point.MarkerSize = 8;
                            point.MarkerColor = chart.Series[check.Text].Color;
                            thresholdValue = Convert.ToInt32(point.YValues[0]);

                        }
                        else
                        {
                            point.MarkerStyle = MarkerStyle.None; // Eşiğin altındaki değerlerde marker kullanma

                        }
                        i++;
                    }
                 

                }
            }
        }

        public static int SayiSatirSayisiniAl(string dosyaYolu)
        {
            // Dosyanın var olup olmadığını kontrol et
            if (!File.Exists(dosyaYolu))
            {
                Console.WriteLine("Dosya bulunamadı: " + dosyaYolu);
                return -1;
            }

            // Dosyadaki satır sayısını hesapla
            int satirSayisi = 0;
            using (var reader = new StreamReader(dosyaYolu))
            {
                while (reader.ReadLine() != null)
                {
                    satirSayisi++;
                }
            }
            return satirSayisi;
        }
        public static string tabload(string ad)
        {
            return ad;
        }
        public static void TabloVerileriniSil(string tabloAdi, SQLiteConnection baglanti)
        {
           
            try
            {
                
                string sql = $"DELETE FROM {tabloAdi}";
                SQLiteCommand komut = new SQLiteCommand(sql, baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("basarılı");
                // Baglantı.conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void ShowData( DataGridView dataGridView,string Colums,int a,int b,string formattedDateTime)
        {
            Colums = "*";
            string veriler;
            if (DataStorage.Colums.Count > 0)
            {
                Colums = "Tarih__Saat_A1_HT31";
                foreach (string s in DataStorage.Colums)
                {
                    Colums += "," + s;
                }
            }
            
            veriler = $"Select  {Colums} from tablo where Tarih__Saat_A1_HT31 >{formattedDateTime} limit {a} offset {b}";

            SQLiteDataAdapter da = new SQLiteDataAdapter(veriler, Connection.conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
           
               
        }
        public static string TabloBaslıkları(string dosyayolu)
        {
            StreamReader str = new StreamReader(dosyayolu);
            var satır = str.ReadLine();
            string birlesim = "";
            var parcalar = satır.Split(";");
            string[] dizi = new string[parcalar.Length];

            for (int i = 0; i < parcalar.Length - 1; i++)
            {
                dizi[i] = parcalar[i];
                dizi[i] = dizi[i].Replace("(", "_").Replace("/", "_").Replace(")", "").Replace("-", "_").Replace(".", "").Replace("%", "").Replace(" ", "_").Replace("__", "_");
                birlesim = birlesim + dizi[i] + ",";
            }
            int count = birlesim.Length;
            string metin = birlesim.Substring(0, count - 1) + "";
            return metin;
        }
        public static List<string> TabloBaslıklarılist(List<string> strings)
        {
            string kullanıcıAdı = Environment.UserName;

            string con = "Data source=C:\\Users\\" + kullanıcıAdı + "\\AppData\\Local\\Sqlite\\Tablo5.db";

            using (SQLiteConnection connection = new SQLiteConnection(con))
            {
                // SQL sorgusu
                string query = $"PRAGMA table_info(tablo);";

                // Komut oluştur
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Bağlantıyı aç
                    connection.Open();

                    // Sütun isimlerini almak için veritabanından veri oku
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Sütun isimlerini tutacak liste


                        // Her bir sütun ismini liste içine ekle
                        while (reader.Read())
                        {
                            string columnName = reader["name"].ToString();
                            strings.Add(columnName);
                        }
                    }
                }
            }
            return strings;
        }
        public static string Tablobasliklar2(string dosyayolu)
        {
            StreamReader str = new StreamReader(dosyayolu);
            var satır = str.ReadLine();
            string birlesim = "";
            var parcalar = satır.Split(";");
            string[] dizi = new string[parcalar.Length];

            for (int i = 0; i < parcalar.Length - 1; i++)
            {
                if (i == 0)
                {
                    dizi[0] = parcalar[0];
                    dizi[0] = dizi[0].Replace("(", "_").Replace("/", "_").Replace(")", "").Replace("-", "_").Replace(".", "").Replace("%", "").Replace(" ", "_").Replace("__", "_");
                    birlesim = birlesim + dizi[0] + " TEXT NOT NULL" + ",";
                    i++;
                }
                dizi[i] = parcalar[i];
                dizi[i] = dizi[i].Replace("(", "_").Replace("/", "_").Replace(")", "").Replace("-", "_").Replace(".", "").Replace("%", "").Replace(" ", "_").Replace("__", "_");
                birlesim = birlesim + dizi[i] + " INT NOT NULL" + ",";
            }
            int count = birlesim.Length;
            string metin = birlesim.Substring(0, count - 1) + "";
            return metin;
        }
        public static List<string> Colums(List<string> strings) {
            string selectQuery = "SELECT Series_name FROM Series";

            using (SQLiteCommand command = new SQLiteCommand(selectQuery, Connection.conn2))
            {
                Connection.conn2.Open();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["Series_name"].ToString();
                        strings.Add(name);
                    }
                }
                Connection.conn2.Close();
            }
            return strings.ToList();
        }

    }


}
