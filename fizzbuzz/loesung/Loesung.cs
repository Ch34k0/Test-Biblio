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
            var zahlen = EingabeZahlen(unten, oben);
            var zahlenfb = Verarbeitung(zahlen, unten, oben);
            var ergebnis = Ausgabe(zahlenfb, unten);
        }

        public static int Eingabe_Unten(int unter)
        {
            Console.Write("Untergrenze = ");
            unter = unter;
            unter = EingabeText(unter);
            return unter;
        }

        public static int Eingabe_Ober(int ober)
        {
            Console.Write("Obergrenze = ");
            ober = ober;
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
            var zahlen = new List<int>();
            for (int zahl = unter; zahl < ober; zahl++)
            {
                zahlen.Add(zahl);
            }
            return zahlen;
        }

        public static Dictionary<int, string> Verarbeitung(List<int> zahlen, int unten, int oben)
        {
            var zahlenfb = new Dictionary<int, string>();
            for (int zahl = unten; zahl <= oben + unten; zahl++)
            {                
                if (zahl % 3 == 0 && zahl % 5 == 0)
                {
                    zahlenfb.Add(zahl, "fizzbuzz");
                }               
                else if (zahl % 3 == 0)
                {
                    zahlenfb.Add(zahl, "fizz");
                }                
                else if (zahl % 5 == 0)
                {
                    zahlenfb.Add(zahl, "buzz");
                }
                else
                {
                    zahlenfb.Add(zahl, zahl.ToString());
                }
            }
            return zahlenfb;
        }

        public static Dictionary<int, string> Ausgabe(Dictionary<int, string> zahlenfb, int unter)
        {
            var ergebnis = new Dictionary<int, string>();
            for (int zahl = unter; zahl < zahlenfb.Count; zahl++)
            {
                Console.WriteLine(zahlenfb[zahl]);
            }
            Console.Read();
            return ergebnis;
        }
    }
}
