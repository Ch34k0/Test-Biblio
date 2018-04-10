using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fizzbuzz
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            int unter = 0, ober = 0;
            //Programm(unter, ober);  
            var unten = Eingabe_Unten(unter);
            var oben = Eingabe_Ober(ober);
            var zahlen = EingabeZahlen(unten, oben);
            var zahlenfb = Verarbeitung(zahlen);
            var ergebnis = Ausgabe(zahlenfb, unter);           
        }

        internal static void Programm(int unter,int ober)
        {
                       
        }

        internal static int Eingabe_Unten(int unter)
        {
            Console.Write("Untergrenze = ");
            unter = unter;
            //unter = Convert.ToInt32(Console.ReadLine());
            return unter;
        }

        internal static int Eingabe_Ober(int ober)
        {
            Console.Write("Obergrenze = ");
            ober = ober;
            //ober = Convert.ToInt32(Console.ReadLine());
            return ober;
        }

        //internal static void ProgrammTest(Dictionary<int, string> zahlenbuch,List<int> zahlenliste, int unter, int ober)
        //{
        //    var zahlen = new List<int>();
        //    var zahlenfb = new Dictionary<int, string>();

        //    for (int zahl = unter; zahl < ober; zahl++)
        //    {
        //        zahlen.Add(zahl);
        //    }

        //    for (int zahl = 0; zahl <= zahlen.Count; zahl++)
        //    {
        //        if (zahl % 3 == 0 && zahl % 5 == 0)
        //        {
        //            zahlenfb.Add(zahl, "fizzbuzz");
        //        }
        //        else if (zahl % 3 == 0)
        //        {
        //            zahlenfb.Add(zahl, "fizz");
        //        }
        //        else if (zahl % 5 == 0)
        //        {
        //            zahlenfb.Add(zahl, "buzz");
        //        }
        //        else
        //        {
        //            zahlenfb.Add(zahl, zahl.ToString());
        //        }
        //    }
        //    return ;
        //}
        
        internal static void EingabeText()
        {
            //Console.Write("Untergrenze = ");
            //unter = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Obergrenze = ");
            //ober = Convert.ToInt32(Console.ReadLine());
            //Console.Clear();


        }

        internal static List<int> EingabeZahlen(int unter, int ober)
        {
            var zahlen = new List<int>();
            for (int zahl = unter; zahl < ober; zahl++)
            {
                zahlen.Add(zahl);
            }
            return zahlen;
        }

        internal static Dictionary<int, string> Verarbeitung(List<int> zahlen)
        {
            var zahlenfb = new Dictionary<int, string>();
            for (int zahl = 0; zahl <= zahlen.Count; zahl++)
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

        internal static Dictionary<int, string> Ausgabe(Dictionary<int, string> zahlenfb, int unter)
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
