using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;


namespace ABC_Analyse
{
    public class Dateien
    {
        public int ID;
        public MySqlConnection conn;
        public string Name;
    }
}
