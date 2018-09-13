using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ABC_Analyse
{
    public class Berechnung
    {
        public static void Berechnen(DataGridView Tabelle, bool radio_Menge, Toleranz[] T_Mengen, Toleranz[] T_Werte)
        {
            List<Artikel> Liste;
            double Summe;
            Liste = Listenlogik.Liste_nehmen(Tabelle);
            Summe = Summe_Menge(Liste);
            Liste = Durchschnitt_Menge(Liste, Summe);
            Summe = Summe_Wert(Liste);
            Liste = Durchschnitt_Wert(Liste, Summe);
            Liste = Klasse_bestimmen(Liste, radio_Menge, T_Mengen, T_Werte);
            Tabelle_reinigen(Tabelle, Liste);
            Liste_in_Tabelle_eintragen(Liste, Tabelle);
        }

        public static void Tabelle_reinigen(DataGridView Tabelle, List<Artikel> Liste)
        {
            Tabelle.Rows.Clear();
            for (int i = 0; i < Liste.Count; i++)
            {
                Tabelle.Rows.Add();
            }
        }

        public static double Summe_Menge(List<Artikel> Liste)
        {
            double Summe = 0;
            foreach (var item in Liste)
            {
                Summe += item.Menge;
            }
            return Summe;
        }

        public static List<Artikel> Durchschnitt_Menge(List<Artikel> Liste, double Summe)
        {
            foreach (var item in Liste)
            {
                item.Menge_Prozent = Convert.ToInt32(item.Menge / Summe * 100);
            }
            return Liste;
        }

        public static List<Artikel> Rangordnung(List<Artikel> Liste)
        {

            Liste = Liste.OrderBy(o => o.Wert_absolut).ToList();
            Liste.Reverse();
            for (int i = 0; i < Liste.Count; i++)
            {
                Liste[i].Rang = i + 1;
            }
            Liste = Liste.OrderBy(o => o.Rang).ToList();
            return Liste;
        }

        public static double Summe_Wert(List<Artikel> Liste)
        {
            double Summe = 0;
            foreach (var item in Liste)
            {
                Summe += item.Wert_absolut;
            }
            return Summe;
        }

        public static List<Artikel> Durchschnitt_Wert(List<Artikel> Liste, double Summe)
        {
            foreach (var item in Liste)
            {
                item.Wert_Prozent = Convert.ToInt32(item.Wert_absolut / Summe * 100);
            }
            return Liste;
        }

        public static List<Artikel> Klasse_bestimmen(List<Artikel> Liste, bool radio_Menge, Toleranz[] T_Mengen, Toleranz[] T_Werte)
        {
            Liste = Klasse_nach_Regeln(Liste, T_Mengen, T_Werte);
            Liste = Anteile(Liste, T_Mengen, T_Werte);


            Liste = Rangordnung(Liste);
            Liste = Kumulieren(Liste, T_Mengen, T_Werte);
            Liste = Klasse_nach_Prio(Liste, radio_Menge);

            Liste = Anteile_gleichsetzen(Liste);


            Liste = Liste.OrderBy(o => o.ID).ToList();
            return Liste;
        }

        public static List<Artikel> Klasse_nach_Regeln(List<Artikel> Liste, Toleranz[] T_Mengen, Toleranz[] T_Werte)
        {
            foreach (var item in Liste)
            {
                item.Klasse_Menge = Klasse_werten(item.Menge_Prozent, T_Mengen[0], T_Mengen[1], T_Mengen[2]);
                item.Klasse_Wert = Klasse_werten(item.Wert_Prozent, T_Werte[0], T_Werte[1], T_Werte[2]);
            }
            return Liste;
        }

        public static List<Artikel> Kumulieren(List<Artikel> Liste, Toleranz[] T_Mengen, Toleranz[] T_Werte)
        {
            int Menge_kumu = 0;
            int Wert_kumu = 0;

            for (int i = 0; i < Liste.Count; i++)
            {
                Menge_kumu += (int)Liste[i].Menge_Prozent;
                Liste[i].Menge_kum = Menge_kumu;
                //Liste[i].Klasse_Menge = Klasse_werten(Liste[i].Menge_Anteil, T_Mengen[0], T_Mengen[1], T_Mengen[2]);

                Wert_kumu += (int)Liste[i].Wert_Prozent;
                Liste[i].Wert_kum = Wert_kumu;
                //Liste[i].Klasse_Wert = Klasse_werten(Liste[i].Wert_Anteil, T_Werte[0], T_Werte[1], T_Werte[2]);
            }


            return Liste;
        }

        public static List<Artikel> Anteile(List<Artikel> Liste, Toleranz[] T_Mengen, Toleranz[] T_Werte)
        {
            for (int i = 0; i < Liste.Count; i++)
            {
                Liste[i].Menge_Anteil = Liste[i].Menge_Prozent;
                Liste[i].Wert_Anteil = Liste[i].Wert_Prozent;
            }


            Liste = Liste.OrderBy(o => o.Klasse_Menge).ToList();

            for (int i = 1; i < Liste.Count - 1; i++)
            {
                //string[] Anteile = new string[Liste.Count];
                int kumu;
                if (Liste[i].Klasse_Menge != Liste[i].Klasse_Wert && Liste[i + 1].Klasse_Menge != Liste[i + 1].Klasse_Wert)
                {
                    kumu = (int)(Liste[i].Menge_Prozent + Liste[i + 1].Menge_Prozent);
                    Liste[i].Menge_Anteil = kumu;
                    Liste[i + 1].Menge_Anteil = kumu;

                    kumu = (int)(Liste[i].Wert_Prozent + Liste[i + 1].Wert_Prozent);
                    Liste[i].Wert_Anteil = kumu;
                    Liste[i + 1].Wert_Anteil = kumu;

                    Liste[i].Klasse_Wert = Klasse_werten(Liste[i].Wert_Anteil, T_Werte[0], T_Werte[1], T_Werte[2]);
                    Liste[i + 1].Klasse_Wert = Klasse_werten(Liste[i + 1].Wert_Anteil, T_Werte[0], T_Werte[1], T_Werte[2]);
                    Liste[i].Klasse_Menge = Klasse_werten(Liste[i].Menge_Anteil, T_Mengen[0], T_Mengen[1], T_Mengen[2]);
                    Liste[i + 1].Klasse_Menge = Klasse_werten(Liste[i + 1].Menge_Anteil, T_Mengen[0], T_Mengen[1], T_Mengen[2]);
                }
                else if (Liste[i].Klasse_Menge != Liste[i].Klasse_Wert && Liste[i - 1].Klasse_Menge != Liste[i - 1].Klasse_Wert)
                {

                    kumu = (int)(Liste[i].Menge_Prozent + Liste[i - 1].Menge_Prozent);
                    Liste[i].Menge_Anteil = kumu;
                    Liste[i - 1].Menge_Anteil = kumu;

                    kumu = (int)(Liste[i].Wert_Prozent + Liste[i - 1].Wert_Prozent);
                    Liste[i].Wert_Anteil = kumu;
                    Liste[i - 1].Wert_Anteil = kumu;

                    Liste[i].Klasse_Wert = Klasse_werten(Liste[i].Wert_Anteil, T_Werte[0], T_Werte[1], T_Werte[2]);
                    Liste[i - 1].Klasse_Wert = Klasse_werten(Liste[i - 1].Wert_Anteil, T_Werte[0], T_Werte[1], T_Werte[2]);
                    Liste[i].Klasse_Menge = Klasse_werten(Liste[i].Menge_Anteil, T_Mengen[0], T_Mengen[1], T_Mengen[2]);
                    Liste[i - 1].Klasse_Menge = Klasse_werten(Liste[i - 1].Menge_Anteil, T_Mengen[0], T_Mengen[1], T_Mengen[2]);
                }

            }

            List<Artikel> Anteile = new List<Artikel>();
            string[] Klassen = new string[3];
            int e;
            for (int a = 0; a < 3; a++)
            {
                e = 0;
                for (int i = 0; i < Liste.Count; i++)
                {
                    if (Liste[i].Klasse_Menge == Klassen[a])
                    {
                        Anteile.Add(Liste[i]);
                    }
                }

                foreach (var item in Anteile)
                {
                    e += (int)item.Menge_Anteil;
                }
                foreach (var item in Anteile)
                {
                    item.Menge_Anteil = e;
                }
            }



            return Liste;
        }

        public static List<Artikel> Anteile_gleichsetzen(List<Artikel> Liste)
        {
            List<Artikel>[] Anteile;
            Anteile = new List<Artikel>[3];
            Anteile[0] = new List<Artikel>();
            Anteile[1] = new List<Artikel>();
            Anteile[2] = new List<Artikel>();
            List<Artikel> Fertig_Liste;
            Fertig_Liste = new List<Artikel>();
            string[] Klassen = new string[3] { "A", "B", "C" };

            for (int a = 0; a < 3; a++)
            {
                for (int i = 0; i < Liste.Count; i++)
                {
                    if (Liste[i].Klasse == Klassen[a])
                    {
                        Anteile[a].Add(Liste[i]);
                    }
                }
                Anteile[a] = Anteile_machen(Anteile[a]);
                foreach (var item in Anteile[a])
                {
                    Fertig_Liste.Add(item);
                }
            }

            return Fertig_Liste;
        }

        public static List<Artikel> Anteile_machen(List<Artikel> Liste)
        {
            int e, f;
            e = 0;
            f = 0;
            foreach (var item in Liste)
            {
                e += (int)item.Menge_Prozent;
                f += (int)item.Wert_Prozent;
            }
            foreach (var item in Liste)
            {
                item.Menge_Anteil = e;
                item.Wert_Anteil = f;
            }
            return Liste;
        }

        public static List<Artikel> Klasse_nach_Prio(List<Artikel> Liste, bool radio_Menge)
        {

            foreach (var item in Liste)
            {
                if (radio_Menge)
                {
                    item.Klasse = item.Klasse_Menge;
                }
                else
                {
                    item.Klasse = item.Klasse_Wert;
                }
            }
            return Liste;
        }

        public static string Klasse_werten(double prozent, Toleranz A, Toleranz B, Toleranz C)
        {
            if (prozent <= A.max && prozent >= A.min)
            {
                return "A";
            }
            else if (prozent <= B.max && prozent >= B.min)
            {
                return "B";
            }
            else if (prozent <= C.max && prozent >= C.min)
            {
                return "C";
            }
            return "";
        }

        public static void Liste_in_Tabelle_eintragen(List<Artikel> Liste, DataGridView Tabelle)
        {
            foreach (DataGridViewRow item in Tabelle.Rows)
            {
                try
                {
                    Werte_in_Tabelle(item, Liste[item.Index]);
                    Farben_trennen(item, Liste[item.Index]);
                }
                catch { break; }
            }
        }

        public static void Werte_in_Tabelle(DataGridViewRow Zeile, Artikel item)
        {
            Zeile.Cells["Spalte_ID"].Value = item.ID;
            //Zeile.Cells["Spalte_R"].Value = item.Rang;
            Zeile.Cells["Spalte_Name"].Value = item.Name;
            Zeile.Cells["Spalte_M"].Value = item.Menge;
            Zeile.Cells["Spalte_MP"].Value = item.Menge_Prozent;
            //Zeile.Cells["Spalte_AM"].Value = item.Menge_Anteil;
            Zeile.Cells["Spalte_MK"].Value = item.Klasse_Menge;
            //Zeile.Cells["Spalte_MPK"].Value = item.Menge_kum;
            Zeile.Cells["Spalte_WA"].Value = item.Wert_absolut;
            Zeile.Cells["Spalte_W"].Value = item.Wert;
            Zeile.Cells["Spalte_WP"].Value = item.Wert_Prozent;
            //Zeile.Cells["Spalte_AW"].Value = item.Wert_Anteil;
            Zeile.Cells["Spalte_WK"].Value = item.Klasse_Wert;
            //Zeile.Cells["Spalte_WPK"].Value = item.Wert_kum;
            Zeile.Cells["Spalte_ABC"].Value = item.Klasse;
        }

        public static void Farben_trennen(DataGridViewRow Zeile, Artikel item)
        {
            /*Zeile.Cells["Spalte_MK"].Style.ForeColor = Color.Green;
            Zeile.Cells["Spalte_ABC"].Style.ForeColor = Color.Green;
            Zeile.Cells["Spalte_WK"].Style.ForeColor = Color.Green;
            if (radio_Menge.Checked && Werte_sind_gleich(item))
            {
                Zeile.Cells["Spalte_WK"].Style.ForeColor = Color.Red;
            }
            else if (radio_Wert.Checked && Werte_sind_gleich(item))
            {
                Zeile.Cells["Spalte_MK"].Style.ForeColor = Color.Red;
            }*/
        }

        public static bool Werte_sind_gleich(Artikel item)
        {
            if (item.Klasse_Menge != item.Klasse_Wert)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
