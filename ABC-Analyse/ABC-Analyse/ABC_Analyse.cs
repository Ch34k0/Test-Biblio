using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ABC_Analyse
{
    public partial class ABC_Analyse : Form
    {

        string Dateiname;
        bool aenderung = false;
        public Toleranz Menge_A = new Toleranz();
        public Toleranz Menge_B = new Toleranz();
        public Toleranz Menge_C = new Toleranz();
        public Toleranz Wert_A = new Toleranz();
        public Toleranz Wert_B = new Toleranz();
        public Toleranz Wert_C = new Toleranz();

        public ABC_Analyse()
        {
            InitializeComponent();
        }

        private void ABC_Analyse_Load(object sender, EventArgs e)
        {
            Toleranzen_festlegen(Menge_A, "A", 0, 20);
            Toleranzen_festlegen(Menge_B, "B", 20, 30);
            Toleranzen_festlegen(Menge_C, "C", 30, 100);
            Toleranzen_festlegen(Wert_A, "A", 60, 100);
            Toleranzen_festlegen(Wert_B, "B", 20, 60);
            Toleranzen_festlegen(Wert_C, "C", 0, 20);
            Toleranzen_laden();
            Tabellenspalten_erstellen();
        }

        void Tabellenspalten_erstellen()
        {
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_ID", "ID", 30, true));
            //Tabelle.Columns.Add(Spalte_erstellen("Spalte_R", "Rang", 80, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_Name", "Bezeichnung", 80, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_M", "Menge", 60, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_MP", "Menge in %", 90, true));
            //Tabelle.Columns.Add(Spalte_erstellen("Spalte_MPK", "Menge kumuliert", 90, true));
            //Tabelle.Columns.Add(Spalte_erstellen("Spalte_AM", "Anteil Menge", 80, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_MK", "Klasse nach Menge", 130, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_W", "Wert pro Menge",110, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_WA", "Wert absolut", 90, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_WP", "Wert in %", 90, true));
            //Tabelle.Columns.Add(Spalte_erstellen("Spalte_WPK", "Wert kumuliert", 90, true));
            //Tabelle.Columns.Add(Spalte_erstellen("Spalte_AW", "Anteil Wert", 80, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_WK", "Klasse nach Wert", 130, true));
            Tabelle.Columns.Add(Spalte_erstellen("Spalte_ABC", "Klasse", 100, false));
            //Tabelle.Width = 913;
        }

        DataGridViewColumn Spalte_erstellen(string name, string header, int breite, bool schreibbar)
        {
            DataGridViewTextBoxColumn C = new DataGridViewTextBoxColumn();
            C.Name = name;
            C.HeaderText = header;
            C.Width = breite;
            C.DefaultCellStyle = C.DefaultCellStyle;
            C.ReadOnly = schreibbar;
            return C;
        }

        void Toleranzen_festlegen(Toleranz tol, string Klasse, int min, int max)
        {
            tol.Klasse = Klasse;
            tol.max = max;
            tol.min = min;
        }

        void Toleranzen_laden()
        {
            Toleranzen_zeigen(label_MA, Menge_A);
            Toleranzen_zeigen(label_MB, Menge_B);
            Toleranzen_zeigen(label_MC, Menge_C);
            Toleranzen_zeigen(label_WA, Wert_A);
            Toleranzen_zeigen(label_WB, Wert_B);
            Toleranzen_zeigen(label_WC, Wert_C);
        }

        void Toleranzen_zeigen(Label label, Toleranz tol)
        {
            label.Text = tol.Klasse + ": " + tol.min + "% - " + tol.max + "%";
        }

        private void button_Menge_Klasse_Click(object sender, EventArgs e)
        {
            Klassen_Toleranz KT = new Klassen_Toleranz();
            KT.Modus = "Menge";
            KT.Werte_geben(Menge_B.min, Menge_B.max);
            KT.ShowDialog();
            Toleranzen_festlegen(Menge_A, "A", 0, KT.AB_geben());
            Toleranzen_festlegen(Menge_B, "B", KT.AB_geben(), KT.BC_geben());
            Toleranzen_festlegen(Menge_C, "C", KT.BC_geben(), 100);
            Toleranzen_laden();
        }

        private void button_Wert_Klasse_Click(object sender, EventArgs e)
        {
            Klassen_Toleranz KT = new Klassen_Toleranz();
            KT.Modus = "Wert";
            KT.Werte_geben(Wert_B.max, Wert_B.min);
            KT.ShowDialog();
            Toleranzen_festlegen(Wert_A, "A", KT.AB_geben(), 100);
            Toleranzen_festlegen(Wert_B, "B", KT.BC_geben(), KT.AB_geben());
            Toleranzen_festlegen(Wert_C, "C", 0, KT.BC_geben());
            Toleranzen_laden();
        }

        private void button_Laden_Click(object sender, EventArgs e)
        {



            Listen_Auswahl LA = new Listen_Auswahl();
            LA.ShowDialog();
            Tabelle.Rows.Clear();
            Dateien datei = new Dateien();            
            datei.conn = new MySqlConnection(
            "datasource=127.0.0.1;port=3306;DATABASE=stueckliste;username=root;PASSWORD=;");
            datei.conn.Open();
            MySqlCommand cmd = datei.conn.CreateCommand();
            foreach (var item in LA.Ausgabe())
            {
                cmd.CommandText = "SELECT * FROM " +item;
                MySqlDataReader Leser;
                Leser = cmd.ExecuteReader();
                DataTable DTA = new DataTable();
                DTA.Load(Leser);
                foreach (DataRow row in DTA.Rows)
                {
                    Artikel a = new Artikel();
                    a.ID = Convert.ToInt32(row["ID"].ToString());
                    a.Name = (row["Bezeichnung"].ToString());
                    a.Menge = Convert.ToDouble(row["Menge"].ToString());
                    a.Wert = Convert.ToDouble(row["Wert"].ToString());
                    a.Wert_absolut = Convert.ToDouble(row["Wert"].ToString()) * Convert.ToDouble(row["Menge"].ToString());
                    Tabellensatz_hinzufuegen(a);
                }
            }
            /*
            INSERT INTO `Schreibtisch` (`ID`, `Bezeichnung`, `Menge`, `Wert`) VALUES
            (1, 'Teakholzfurnier', 80, 850),
            (2, 'Fichtenholz', 280, 180),
            (3, 'Leim', 630, 15),
            (4, 'Pressspanplatten', 180, 45),
            (5, 'Muttern', 300, 15),
            (6, 'Holzdübel', 150, 23),
            (11, 'Schrauben', 120, 19);

            

CREATE TABLE `Schreibtisch` (
  `ID` int(11) NOT NULL,
  `Bezeichnung` varchar(50) COLLATE utf8_german2_ci NOT NULL,
  `Menge` double NOT NULL,
  `Wert` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_german2_ci;

            */
        }

        public void Tabellensatz_hinzufuegen(Artikel bsp)
        {
            Tabelle.Rows.Add(bsp.ID, bsp.Name, bsp.Menge, "", "", bsp.Wert, bsp.Wert_absolut ,"",  "", "");
        }

        private void button_Berechnen_Click(object sender, EventArgs e)
        {
            Toleranz[] T_Mengen = new Toleranz[3] { Menge_A, Menge_B, Menge_C };
            Toleranz[] T_Werte = new Toleranz[3] { Wert_A, Wert_B, Wert_C };
            Berechnung.Berechnen(Tabelle, radio_Menge.Checked, T_Mengen, T_Werte);
            Berechnung.Berechnen(Tabelle, radio_Menge.Checked, T_Mengen, T_Werte);
            aenderung = false;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

            Dateiname = String_uebergeben("Bitte geben Sie ein, unter welchem Namen die Datei gespeichert werden soll.");
            string Thema = String_uebergeben("Hat die Liste einen speziellen Titel?" + Environment.NewLine + "Wenn ja, nennen Sie ihn.");
            Dokument WF = new Dokument();
            WF.Show();
            this.Enabled = false;
            WF.Dokument_erstellen(Tabelle, Prio(), Thema, Dateiname, aenderung);
            this.Enabled = true;
            this.BringToFront();
        }

        string String_uebergeben(string Thema)
        {
            Stringeingabe SE = new Stringeingabe();
            SE.label_Thema.Text = Thema;
            SE.ShowDialog();
            return SE.Ausgabe();
        }

        string Prio()
        {
            if (radio_Menge.Checked)
            {
                return "Menge";
            }
            else
            {
                return "Wert";
            }
        }

        private void button_Look_Click(object sender, EventArgs e)
        {
            //Dokument.Dokument_erstellen(Tabelle, Prio(), "stueckliste");
            Datei_Auswahl DA = new Datei_Auswahl();
            DA.ShowDialog();
            if (DA.Ausgabe().Length == 0)
            {
                return;
            }
            Dokument.Dokument_zeigen(DA.Ausgabe());
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            Datei_Auswahl DA = new Datei_Auswahl();
            DA.ShowDialog();
            if (DA.Ausgabe().Length == 0)
            {
                return;
            }
            Dokument.Dokument_drucken(DA.Ausgabe());
        }

        private void button_empty_Click(object sender, EventArgs e)
        {
            Datei_Auswahl DA = new Datei_Auswahl();
            DA.ShowDialog();
            if (DA.Ausgabe().Length == 0)
            {
                return;
            }

            DialogResult r;
            r = MessageBox.Show("Wollen Sie diese Dateien wirklich löschen?", "Warnung!!", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                Dokument.Dokument_loeschen(DA.Ausgabe());
            }
        }

        private void Tabelle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            aenderung = true;
        }
    }
}
