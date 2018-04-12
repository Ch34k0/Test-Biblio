
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
            var ergebnis = Uebersetzen(dezimal_zahl);
            return ergebnis;
        }

        public static string Uebersetzen(string dezimal_zahl)
        {
            int position=0;
            bool richtung=false;
            string temporaer=String.Empty;
            
            Dictionary<int, string> romantext = new Dictionary<int, string>()
            { {  0, "M" }, { 1, "D" }, { 2, "C" }, { 3, "L" }, { 4, "X" },{ 5, "V" },{ 6, "I" } };
            Dictionary<int, int> romanzahl = new Dictionary<int, int>()
            { {  0, 1000 },{ 1, 500 },{ 2, 100 }, { 3,50},{ 4,10 }, { 5,5 }, { 6,1 } };

            var ergebnis = Ueberschreiben(dezimal_zahl,  romantext,  romanzahl, position, richtung, temporaer);
            return ergebnis;
        }
        public static string Ueberschreiben(string dezimal_zahl,Dictionary<int,string> romantext,Dictionary<int,int>romanzahl,int position,bool richtung, string temporaer)
        {
            string ergebnis="";
            for (int zeichen = dezimal_zahl.Length; zeichen > 0; zeichen--)
            {
                position = Convert.ToInt32(dezimal_zahl.Substring(zeichen - 1, 1)) * Convert.ToInt32(Math.Pow(10, dezimal_zahl.Length - zeichen));
                while (position > 0)
                {
                    richtung = false;

                    for (int k = 6; k > 0; k--)
                    {

                        if (romanzahl[k] - position > 0)
                        {
                            if ((romanzahl[k] - position) == Convert.ToInt32(Math.Pow(10, dezimal_zahl.Length - zeichen)))
                            {
                                position = romanzahl[k] - position;
                                temporaer = romantext[k] + temporaer;
                                richtung = true;
                                break;
                            }
                        }
                    }

                    for (int i = 0; i < 7; i++)
                    {
                        if (position - romanzahl[i] >= 0)
                        {
                            position = position - romanzahl[i];
                            if (richtung == false)
                            {
                                temporaer = temporaer + romantext[i];
                            }
                            else
                            {
                                temporaer = romantext[i] + temporaer;
                            }
                            break;
                        }
                    }
                }
                ergebnis = temporaer + ergebnis;
                temporaer = "";
            }
            return ergebnis;
        }
    }
}