using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static deneme4.Form1;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using ToolTip = System.Windows.Forms.ToolTip;

namespace deneme4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // List<System.Windows.Forms.CheckBox> DataList = new List<System.Windows.Forms.CheckBox>();
        }

        const int startX = 20;
        const int startY = 20;
        const int spacingX = 150;
        const int spacingY = 50;
        const int checkboxesPerRow = 10;
        SQLiteConnection con;
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        string query = "";
        string query2 = "";
        object result;
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Grafik grafik = new Grafik();
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

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Anaform ana = new Anaform();

            string name = string.Empty;
            List<string> list = new List<string>();
            Fonks.TabloBaslıklarılist(list);
            list.RemoveAt(0);
            int j = 0, i = 0, k = 1;

            int h = 0;
            int g = 0;
            this.StartPosition = FormStartPosition.Manual;
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width - 250) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height - 200) / 2;
            this.Location = new Point(x, y);
            foreach (string s in list)
            {
                System.Windows.Forms.CheckBox checkBox = new System.Windows.Forms.CheckBox();
                checkBox.Text = s.ToString();
                checkBox.AutoSize = true;
                checkBox.Location = new System.Drawing.Point(startX + j * spacingX, startY + i * spacingY);
                // checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((Left,Top,Right,Bottom)));
                checkBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;



                // Olay işleyicisi ekle
                //checkBox.Click += checkBox_Click;
                checkBox.CheckedChanged += CheckBox_CheckedChanged4;
                // checkBox.Checked = false;
                panel1.Controls.Add(checkBox);

                j++;

                if (j == 10)
                {
                    i++;
                    j = 0;
                    h = checkBox.Height;
                    g = checkBox.Width;
                }
                k++;
                query2 = $"SELECT Series_name FROM Series WHERE Series_name = '{checkBox.Text}'";
                using (SQLiteCommand command = new SQLiteCommand(query2, Connection.conn2))
                {
                    Connection.conn2.Open();
                    result = command.ExecuteScalar();
                    if (result != null)
                    {
                        checkBox.Checked = true;

                    }
                    Connection.conn2.Close();
                }
            }
            i = i + 5;
            k = k - 15;

            this.Size = new System.Drawing.Size(i * g - 4, (i - 7) * g);


        }
       




        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            //grafik.Panel1.Controls.Add(checkBox);

        }
        Anaform anaform = new Anaform();

        public List<CheckBox> checkBoxes = new List<CheckBox>();
        public void CheckBox_CheckedChanged2(object sender, EventArgs e)
        {
            // cmd = new SQLiteCommand();

            //cmd.Connection = con;
            // con.Open();
            //"INSERT INTO TableName (Column1, Column2) VALUES (@value1, @value2)";
            con = new SQLiteConnection(Connection.conn);
            CheckBox checkBox = (CheckBox)sender;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (checkBox.Checked == true)
            {


                // İlgili checkbox işaretlendiğinde yapılacak işlemleri burada gerçekleştirin.

                checkBoxes.Add(checkBox);
                //checkBox.Checked = true;

                if (result == null)
                {
                    query = $"INSERT INTO Series (Series_name) VALUES ('{checkBox.Text}')";
                    SQLiteCommand command = new SQLiteCommand(query, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                // İlgili checkbox işareti kaldırıldığında yapılacak işlemleri burada gerçekleştirin.
                checkBoxes.Remove(checkBox);
                controlcheck.Remove(checkBox.Text);

                DataStorage.DataList = checkBoxes;

                query = $"DELETE FROM Series WHERE Series_name = '{checkBox.Text}'";
                SQLiteCommand command = new SQLiteCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
            }

        }

        private void CheckBox_CheckedChanged3(object sender, EventArgs e)
        {
            con = new SQLiteConnection(Connection.conn);
            CheckBox checkBox = (CheckBox)sender;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            // CheckBox checkBox = (System.Windows.Forms.CheckBox)sender;
            // DateTime selectedDateTime = grafik.dateTimePicker1.Value; // DateTimePicker kontrolünden seçilen değeri alır

            formattedDateTime = DataStorage.selectedDateTime.ToString("yyyyMMddHHmmss"); // Belirtilen formata göre string'e dönüştürür
            formattedDateTime = formattedDateTime + "000";


            if (checkBox.Checked == true)
            {
                checkBoxes.Add(checkBox);
                //checkBox.Checked = true;

                if (result == null)
                {
                    query = $"INSERT INTO Series (Series_name) VALUES ('{checkBox.Text}')";
                    SQLiteCommand command = new SQLiteCommand(query, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
                DataStorage.Colums.Add(checkBox.Text);
                Fonks.ShowData(anaform.dataGridView1, anaform.sorgu, 2000, 0, formattedDateTime);
            }
            else
            {
                checkBoxes.Remove(checkBox);
                controlcheck.Remove(checkBox.Text);

                DataStorage.DataList = checkBoxes;

                query = $"DELETE FROM Series WHERE Series_name = '{checkBox.Text}'";
                SQLiteCommand command = new SQLiteCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
                DataStorage.Colums.Remove(checkBox.Text);
                Fonks.ShowData(anaform.dataGridView1, anaform.sorgu, anaform.a, anaform.b, formattedDateTime);
            }

            Fonks.control(anaform.chart1, checkBox, anaform.dataGridView1, anaform.a, anaform.b, anaform.dateTimePicker1, formattedDateTime, customToolTip);


        }
        // Grafik grafik = new Grafik();
        private void button1_Click_2(object sender, EventArgs e)
        {
            int g = 0;
            //foreach (Control control in  panel1.Controls)
            //{
            //    if (control is CheckBox checkBox && checkBox.Checked)
            //    {
            //        checkBox.CheckedChanged += CheckBox_CheckedChanged3;
            //    }
            //}
            anaform.label5.Visible = true;
            if (g <= 0)
            {
                foreach (Control c in anaform.panel3.Controls)
                {
                    if (c is not SplitContainer)
                    {
                        c.Visible = false;
                    }
                }
            }
            anaform.dataGridView1.Visible = false;
            Loads.LoadGrafik(200, anaform.splitContainer2, anaform.dateTimePicker1, anaform.dtobj2, anaform.dataGridView1, formattedDateTime);
            anaform.chart1.Visible = true;
            if (!anaform.panel3.Contains(anaform.splitContainer2))
                anaform.panel3.Controls.Add(anaform.splitContainer2);
            g++;
            anaform.splitContainer2.Visible = true;
            anaform.label7.Visible = false;
            anaform.label7.Location = new Point(anaform.splitContainer2.Panel2.Width / 2, anaform.splitContainer2.Panel1.Height - 21);
            anaform.label8.Location = new Point(anaform.splitContainer2.Panel2.Width / 2, anaform.label7.Height - 50);
            anaform.splitContainer2.SplitterDistance = 870;
            anaform.label7.BackColor = anaform.panel3.BackColor;
            this.Close();


        }
        public string formattedDateTime;

        ToolTip customToolTip = new ToolTip();

        public List<string> selectedCheckboxesTexts = new List<string>();
        public List<CheckBox> selectedCheckboxes = new List<CheckBox>();
        private void CheckBox_CheckedChanged4(object sender, EventArgs e)
        {

            con = new SQLiteConnection(Connection.conn);
           // CheckBox checkBox = (CheckBox)sender;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            CheckBox checkbox = (CheckBox)sender;
            string checkboxText = checkbox.Text;
            if (checkbox.Checked && !selectedCheckboxesTexts.Contains(checkboxText))
            {

                checkBoxes.Add(checkbox);
                //checkBox.Checked = true;

                if (result == null)
                {
                    query = $"INSERT INTO Series (Series_name) VALUES ('{checkbox.Text}')";
                    SQLiteCommand command = new SQLiteCommand(query, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
                selectedCheckboxes.Add(checkbox);
                if (!DataStorage.selectedCheckboxes.Any(cb => cb.Text == checkbox.Text))
                    DataStorage.selectedCheckboxes.Add(checkbox);
                
                selectedCheckboxesTexts.Add(checkboxText);
            }
            else
            {
                selectedCheckboxes.Remove(checkbox);
                selectedCheckboxesTexts.Remove(checkboxText);
                checkBoxes.Remove(checkbox);
                controlcheck.Remove(checkbox.Text);
               List<CheckBox> acd = new List<CheckBox>();
               // acd = DataStorage.selectedCheckboxes;
                DataStorage.selectedCheckboxes=selectedCheckboxes ;
                //acd = DataStorage.selectedCheckboxes;
                DataStorage.DataList = checkBoxes;

                query = $"DELETE FROM Series WHERE Series_name = '{checkbox.Text}'";
                SQLiteCommand command = new SQLiteCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(grafik.dtObj2.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            anaform = Application.OpenForms.OfType<Anaform>().FirstOrDefault();
            if (anaform != null)
            {
                anaform.UpdateChart(selectedCheckboxes);
            }

        }
    }
}
///////////form2 closed-changed3