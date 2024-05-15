using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static deneme4.Form1;
using static System.Windows.Forms.AxHost;

namespace deneme4
{
    public class Loads
    {
        
        public static RectangleF circle = RectangleF.Empty;
        private const int markerDistance = 100;
        public static void LoadGrafik(int with, SplitContainer splitContainer1, DateTimePicker dateTimePicker1, DateTime dtObj2, DataGridView dataGridView1, string formattedDateTime)
        {
            
            Connection.conn.Open();
            SQLiteCommand read = new SQLiteCommand($"SELECT Tarih__Saat_A1_HT31 FROM tablo", Connection.conn);
            SQLiteDataReader reader = read.ExecuteReader();
            reader.Read();
            string a = reader[0].ToString();
            Connection.conn.Close();
            string yeniTarihVeSaat = a.Substring(0, a.Length - 3);
           
            DateTime dtObj = DateTime.ParseExact(yeniTarihVeSaat, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            string tarih = dtObj.ToString("yyyy-MM-dd HH:mm:ss");
            dtObj = DateTime.ParseExact(tarih, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            dtObj2 = dtObj;
            string tabload = "tablo";
            string tablo = Fonks.tabload(tabload);
            formattedDateTime = yeniTarihVeSaat;
            if (tablo != "")
                Fonks.ShowData(dataGridView1, "", 2000, 0,formattedDateTime);
            else
                MessageBox.Show("Tablo adı seçilmedi");
    
        }

        public static void chart1_MouseMove(object sender, MouseEventArgs e,Chart chart1,ToolTip customToolTip)
        {
           
           // customToolTip.OwnerDraw = true;
            customToolTip.IsBalloon = true;
            customToolTip.ToolTipTitle = "Tarih";
            
            var chart = sender as Chart;
            // Fare konumunu al
            var pos = e.Location;

            // Hangi series'in üzerinde olduğumuzu belirleyelim
            var hit = chart.HitTest(pos.X, pos.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                var dataPoint = hit.Object as DataPoint;
                if (dataPoint != null)
                {
                    string seriesName = "";
                    ////foreach (var series in chart.Series)
                    ////{
                    ////    foreach (var point in series.Points)
                    ////    {
                    ////        if (point == dataPoint)
                    ////        {
                    ////            seriesName = series.Name;
                    ////            break;
                    ////        }
                    ////    }
                    ////    if (!string.IsNullOrEmpty(seriesName))
                    ////    {
                    ////        break;
                    ////    }
                    ////}

                    double xValueAsDouble = dataPoint.XValue;
                    DateTime dateTimeXValue = DateTime.FromOADate(xValueAsDouble); // double değeri DateTime'a çevirme
                    string formattedXValue = dateTimeXValue.ToString("yyyy.MM.dd-HH:mm:ss");

                    customToolTip.SetToolTip(chart, $"{formattedXValue}\n {seriesName} : {dataPoint.YValues[0]}");


                    // MouseMove olayına bir işleyici ekleyerek tooltip içeriğini kalın biçimde gösterin

                }

            }
            else
            {
                customToolTip.Hide(chart);
            }
            //   RectangleF circle;
            int markerSize = 15;

            // var chart = sender as Chart;
            UpdateMarker(chart1, e);

        }
        public static float DistanceToLine(Chart chart, Point point)
        {
            var area = chart.ChartAreas[0];
            var axisX = area.AxisX;
            var axisY = area.AxisY;

            var xValue = axisX.PixelPositionToValue(point.X);
            var yValue = axisY.PixelPositionToValue(point.Y);

            var nearestXValue = Math.Max(axisX.Minimum, Math.Min(axisX.Maximum, xValue));
            var nearestYValue = Math.Max(axisY.Minimum, Math.Min(axisY.Maximum, yValue));

            var nearestXPixel = axisX.ValueToPixelPosition(nearestXValue);
            var nearestYPixel = axisY.ValueToPixelPosition(nearestYValue);

            var deltaX = point.X - nearestXPixel;
            var deltaY = point.Y - nearestYPixel;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        public static void chart1_Paint(object sender, PaintEventArgs e)
        {
            if (!circle.IsEmpty)
            {
                int markerSize = 10;
                Color markerColor = Color.FromArgb(128, Color.Green); // İşaret rengi, isteğe bağlı olarak değiştirilebilir

                // İşareti çiz
                using (SolidBrush brush = new SolidBrush(markerColor))
                {
                    e.Graphics.FillEllipse(brush, circle);
                }
            }
            
        }
        public static void UpdateMarker(Chart chart, MouseEventArgs e)
        {
            int markerSize = 15;
            float markerDistance = 20; // Varsayılan değer, isteğe bağlı olarak değiştirilebilir

            if (chart != null)
            {
                var result = chart.HitTest(e.X, e.Y);
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var dataPoint = result.Object as DataPoint;
                    if (dataPoint != null && dataPoint.IsVisibleInLegend)
                    {
                        // DataPoint'un bulunduğu seriyi al
                        var series = chart.Series.FirstOrDefault(s => s.Points.Contains(dataPoint) && s.ChartType == SeriesChartType.Spline);
                        if (series != null)
                        {
                            // Mouse'un çizgiye olan uzaklığını kontrol et
                            float distanceToLine = DistanceToLine(chart, e.Location);
                            if (distanceToLine <= markerDistance)
                            {
                                // Cizginin yakınında olduğunda işaretin konumunu ve boyutunu güncelle
                                circle = new RectangleF((float)e.X - markerSize / 2,
                                                        (float)e.Y - markerSize / 2,
                                                        markerSize, markerSize);
                                
                                // Formu yeniden çiz
                                chart.Invalidate();
                                return;
                            }
                        }
                    }
                }

                // Eğer cizginin yakınında değilse veya spline serisi değilse işareti temizle
                circle = RectangleF.Empty;
                chart.Invalidate();
            }
        }
        public static void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
        public static void Chart1_MouseWheel(object sender, MouseEventArgs e,Chart chart1,int a)
        {
            // Chart chart = sender as Chart;

            // Tıklanan noktanın koordinatlarını al
            if (a > 0)
            {
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
           
        }
        public static void chart1_FormatNumber(object sender, FormatNumberEventArgs e)
        {
            if (e.ElementType == ChartElementType.AxisLabels && e.ValueType == ChartValueType.Double)
            {
                e.LocalizedValue = ((int)e.Value).ToString();
            }
        }
    }
    
}
