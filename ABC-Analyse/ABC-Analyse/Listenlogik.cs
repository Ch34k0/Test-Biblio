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
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace ABC_Analyse
{
    public static class Listenlogik
    {

        public static List<Artikel> Liste_nehmen(DataGridView Tabelle)
        {
            List<Artikel> Liste = new List<Artikel>();
            Tabelle_lesen(Tabelle, Liste);

            Liste = Dopplungen(Liste);
            
            return Liste;
        }

        

        public static List<Artikel> Tabelle_lesen(DataGridView Tabelle,List<Artikel> Liste)
        {
            
            foreach (DataGridViewRow item in Tabelle.Rows)
            {
                Artikel a = new Artikel();
                a.ID = Convert.ToInt32((Eintrag_checken(item.Cells["Spalte_ID"])));
                //a.Rang = Convert.ToInt32((Eintrag_checken(item.Cells["Spalte_R"])));
                a.Name = Eintrag_checken(item.Cells["Spalte_Name"]).ToString();
                a.Menge = Convert.ToDouble(Eintrag_checken(item.Cells["Spalte_M"]));
                a.Menge_Prozent = Convert.ToDouble(Eintrag_checken(item.Cells["Spalte_MP"]));
                //a.Menge_kum = Convert.ToInt32(Eintrag_checken(item.Cells["Spalte_MPK"]));
                a.Klasse_Menge = Eintrag_checken(item.Cells["Spalte_MK"]).ToString();
                a.Wert = Convert.ToDouble(Eintrag_checken(item.Cells["Spalte_W"]));
                a.Wert_absolut = Convert.ToDouble(Eintrag_checken(item.Cells["Spalte_WA"]));
                a.Wert_Prozent = Convert.ToDouble(Eintrag_checken(item.Cells["Spalte_WP"]));
                //a.Wert_kum = Convert.ToInt32(Eintrag_checken(item.Cells["Spalte_WPK"]));
                a.Klasse_Wert = Eintrag_checken(item.Cells["Spalte_WK"]).ToString();
                a.Klasse = Eintrag_checken(item.Cells["Spalte_ABC"]).ToString();
                Liste.Add(a);
            }
            Liste.Remove(Liste.Last());
            return Liste;
        }

        public static object Eintrag_checken(DataGridViewCell zelle)
        {

            if (zelle.Value == null)
            {
                return 0;
            }
            else if (zelle.Value.ToString().Length == 0)
            {
                return 0;
            }
            else
            {
                return zelle.Value;
            }
        }

        public static List<Artikel> Dopplungen(List<Artikel> Liste)
        {
            List<Artikel> Liste_B = new List<Artikel>();
            string[] ID = new string[Liste.Count];
            string[] E = new string[Liste.Count];
            foreach (var item in Liste)
            {
                ID[Liste.IndexOf(item)] = (item.Name);
            }
            foreach (var item in Liste)
            {
                //Artikel a = new Artikel();
                //a = item;
                if (E.Contains(item.Name))
                {
                    int index = Array.IndexOf(ID, item.Name);
                    //MessageBox.Show(index.ToString());
                    //Liste_B.Add(a);
                    //Liste.Remove(item);
                    Liste_B[index].Menge += item.Menge;
                }
                else
                {
                    Liste_B.Add(item);
                    E[Liste.IndexOf(item)] = (item.Name);
                }
            }
            return Liste_B;
        }
    }
}
