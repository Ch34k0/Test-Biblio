using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loesung
{
    public class Loesung
    {
        public static void Durchlauf()
        {
            int unter = 0, ober = 0;            
            var unten = Eingabe_Unten(unter);
            var oben = Eingabe_Ober(ober);
            var zahlen_list = EingabeZahlen(unten, oben);
            var zahlen_dic = Verarbeitung(zahlen_list, unten, oben);
            //var ergebnis = Ausgabe(zahlen_dic, unten);
        }

        public static int Eingabe_Unten(int unter)
        {
            Console.Write("Untergrenze = ");            
            unter = EingabeText(unter);
            return unter;
        }

        public static int Eingabe_Ober(int ober)
        {
            Console.Write("Obergrenze = ");            
            ober = EingabeText(ober);
            return ober;
        }

        public static int EingabeText(int number)
        {            
            number = Convert.ToInt32(Console.ReadLine());
            return number;
        }

        public static List<int> EingabeZahlen(int unter, int ober)
        {
            var zahlen_list = new List<int>();
            for (int zahl = unter; zahl < ober; zahl++)
            {
                zahlen_list.Add(zahl);
            }
            return zahlen_list;
        }

        public static Dictionary<int, string> Verarbeitung(List<int> zahlen_list, int unten, int oben)
        {
            var zahlen_dic = new Dictionary<int, string>();
            for (int zahl = unten; zahl <= oben + unten; zahl++)
            {                
                if (zahl % 3 == 0 && zahl % 5 == 0)
                {
                    zahlen_dic.Add(zahl, "fizzbuzz");
                }               
                else if (zahl % 3 == 0)
                {
                    zahlen_dic.Add(zahl, "fizz");
                }                
                else if (zahl % 5 == 0)
                {
                    zahlen_dic.Add(zahl, "buzz");
                }
                else
                {
                    zahlen_dic.Add(zahl, zahl.ToString());
                }
            }
            return zahlen_dic;
        }

        //public static Dictionary<int, string> Ausgabe(Dictionary<int, string> zahlen_dic, int unter)
        //{
        //    var ergebnis = new Dictionary<int, string>();
        //    for (int zahl = unter; zahl < zahlen_dic.Count; zahl++)
        //    {
        //        Console.WriteLine(zahlen_dic[zahl]);
        //    }
        //    Console.Read();
        //    return ergebnis;
        //}
    }
}
