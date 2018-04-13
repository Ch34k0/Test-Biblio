
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace die_spinnen_doch
{
    public class Programm
    {
        public static string Main(string dezimal_zahl)
        {
            var ergebnis = Zahl_Teilen(dezimal_zahl);
            Position_bestimmen(ergebnis);
            string ende = Zusammenfuehren(ergebnis, String.Empty);
            return ende;
        }

        public static string[] Zahl_Teilen(string dezimal_zahl)
        {
            var ergebnis = dezimal_zahl.Split();
            
            return ergebnis;
        }

        public static void Position_bestimmen(string[] dezimal_zahl)
        {
            var ergebnis = 0;
            
        }

        public static string Zusammenfuehren(string[] dezimal_zahl, string ergebnis)
        {
            ergebnis = Zusammen_Schleife(dezimal_zahl, ergebnis);
            return ergebnis;
        }

        public static string Zusammen_Schleife(string[] dezimal_zahl, string ergebnis)
        {
            for (int i = 0; i < dezimal_zahl.Length; i++)
            {
                ergebnis += dezimal_zahl[i];
            }
            return ergebnis;
        }
    }
}