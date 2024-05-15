using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme4
{
    public class Connection
    {
        static string UserName = Environment.UserName;

        public static SQLiteConnection conn = new SQLiteConnection("Data source=C:\\Users\\" + UserName + "\\AppData\\Local\\Sqlite\\Tablo4.db");

        public static SQLiteConnection conn2 = new SQLiteConnection("Data source=C:\\Users\\" + UserName + "\\AppData\\Local\\Sqlite\\Tablo4.db");
    }
}
