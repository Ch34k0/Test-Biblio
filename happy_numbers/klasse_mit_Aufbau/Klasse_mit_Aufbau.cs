using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasse_mit_Aufbau
{
    public class Klasse_mit_Aufbau
    {

        public static void Haupt(int ursprungszahl)
        {
            var Liste = Liste_schreiben(ursprungszahl);
            Ergebnis(Liste);
            Ausgabe(Liste);
        }

        public static List<string> Liste_schreiben(int ursprungszahl)
        {
            List<string> Liste = Schleife(ursprungszahl);
            return Liste;
        }

        public static List<string> Schleife(int ursprungszahl)
        {
            List<string> Liste = new List<string>();
            int einzelpotenz, summe;
            while (ursprungszahl != 1&& ursprungszahl!= 4)
            {
                summe = 0;
                for (int i = 0; i < ursprungszahl.ToString().Length; i++)
                {
                    einzelpotenz = Convert.ToInt32(Math.Pow(Convert.ToInt32(ursprungszahl.ToString().Substring(i, 1)), 2));
                    summe += einzelpotenz;
                }
                ursprungszahl = summe;
                Liste.Add(ursprungszahl.ToString());                
            }
            return Liste;
        }

        public static void Ergebnis(List<string> Liste)
        {
            if (Liste[Liste.Count-1] == "1")
            {
                Liste.Add("Das ist eine fröhliche Zahl :D");
            }
            else if (Liste[Liste.Count-1] == "4")
            {
                Liste.Add("Das ist eine traurige Zahl :C");
            }
            else
            {
                Liste.Add("Dieser Zahl ist alles egal :|");
            }
        }

        public static void Ausgabe(List<string> Liste)
        {
            for (int i = 0; i < Liste.Count; i++)
            {
                Console.WriteLine(Liste[i]);
            }
        }
    }
}
