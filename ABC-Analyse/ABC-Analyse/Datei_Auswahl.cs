using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace ABC_Analyse
{
    public partial class Datei_Auswahl : Form
    {
        public Datei_Auswahl()
        {
            InitializeComponent();
            Dateien_laden();
        }

        private void button_Waehlen_Click(object sender, EventArgs e)
        {
            this.Close();
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
            DirectoryInfo PDF = new DirectoryInfo(@"Dateien\");
            FileInfo[] wordFs = PDF.GetFiles("*.pdf");
            foreach (var item in wordFs)
            {
                listBox_Datei.Items.Add(item.ToString());
            }
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


    }
}
