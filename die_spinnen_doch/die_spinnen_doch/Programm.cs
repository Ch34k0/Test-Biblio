
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
            //dezimal_zahl = Reverse(dezimal_zahl);
            var array_zahl = Arrayisieren(Reverse(dezimal_zahl));             
            string ende = Zusammenfuehren(array_zahl, String.Empty);
            return ende;
        }

        public static string[] Arrayisieren(string dezimal_zahl)
        {
            
            string[] ergebnis = Zahl_Teilen(dezimal_zahl);
            ergebnis = Position_bestimmen(ergebnis);
            return ergebnis;
        }

        public static string[] Zahl_Teilen(string dezimal_zahl)
        {
            string[] ergebnis = new string[4] { "0", "0", "0", "0" };
            for (int i = 0; i < dezimal_zahl.Length; i++)
            {
                ergebnis[i] = dezimal_zahl.Substring(i, 1);
            }
            return ergebnis;
        }

        public static string Reverse(string dezimal_zahl)
        {
            char[] charArray = dezimal_zahl.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string[] Position_bestimmen(string[] array_zahl)
        {
            string[] ergebnis = new string[4];
            ergebnis[0] = Uebersetzen_Einer(array_zahl[0]);
            ergebnis[1] = Uebersetzen_Zehner(array_zahl[1]);
            ergebnis[2] = Uebersetzen_Hunderter(array_zahl[2]);
            ergebnis[3] = Uebersetzen_Tausender(array_zahl[3]);
            Array.Reverse(ergebnis);
            return ergebnis;
        }

        public static string Uebersetzen_Einer(string array)
        {
            string text = String.Empty;
            string[] romantext = new string[]
            {"", "I","II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
            text = romantext[Convert.ToInt32(array)];

            return text;
        }

        public static string Uebersetzen_Zehner(string array)
        {
            string text = String.Empty;
            string[] romantext = new string[]
            {"", "X","XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
            text = romantext[Convert.ToInt32(array)];
            return text;
        }

        public static string Uebersetzen_Hunderter(string array)
        {
            string text = String.Empty;
            string[] romantext = new string[]
            {"", "C","CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "DM"};
            text = romantext[Convert.ToInt32(array)];
            return text;
        }

        public static string Uebersetzen_Tausender(string array)
        {
            string text = String.Empty;
            string[] romantext = new string[]
            {"", "M","MM", "MMM"};
            text = romantext[Convert.ToInt32(array)];
            return text;
        }


        public static string Zusammenfuehren(string[] array_zahl, string ergebnis)
        {
            ergebnis = Zusammen_Schleife(array_zahl, ergebnis);
            return ergebnis;
        }

        public static string Zusammen_Schleife(string[] array_zahl, string ergebnis)
        {
            for (int i = 0; i < array_zahl.Length; i++)
            {
                ergebnis += array_zahl[i];
            }
            return ergebnis;
        }
    }
}