using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ABC_Analyse
{
    public partial class Listen_Auswahl : Form
    {
        public Listen_Auswahl()
        {
            InitializeComponent();
            Dateien_laden();
        }

        private void button_Waehlen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_All_Click(object sender, EventArgs e)
        {
            Auswahl(true);
        }

        private void button_Nothing_Click(object sender, EventArgs e)
        {
            Auswahl(false);
        }

        void Auswahl(bool wahl)
        {
            for (int i = 0; i < listBox_Datei.Items.Count; i++)
            {
                listBox_Datei.SetSelected(i, wahl);
            }
        }

        public string[] Ausgabe()
        {
            string[] e = new string[listBox_Datei.SelectedItems.Count];
            for (var i = 0; i < listBox_Datei.SelectedItems.Count; i++)
            {
                e[i] = listBox_Datei.SelectedItems[i].ToString();
            }

            return e;
        }

        void Dateien_laden()
        {
            Dateien datei = new Dateien();
            datei.conn = new MySqlConnection(
            "datasource=127.0.0.1;port=3306;DATABASE=stueckliste;username=root;PASSWORD=;");
            datei.conn.Open();
            MySqlCommand cmd = datei.conn.CreateCommand();
            cmd.CommandText = "SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_SCHEMA='stueckliste'";
            MySqlDataReader Reader = cmd.ExecuteReader();
            DataTable DTA = new DataTable();
            DTA.Load(Reader);
            //foreach (var item in DTA.Columns)
            //{
            //    listBox_Datei.Items.Add(item.ToString());
            //}

            foreach (DataRow row in DTA.Rows)
            {
                listBox_Datei.Items.Add(row["TABLE_NAME"].ToString());
            }

            //    while (Reader.Read())
            //{
            //    listBox_Datei.Items.Add(Reader[""].ToString());// ("id_ma") & " # " & Reader("name") & " # " & Reader("vorname"));
            //}

        }
    }
}
