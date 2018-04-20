using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worterbuch
{
    public class Woerterbuch
    {
        public static void Programm(string input)
        {
            Start(input);
        }
        public static Dictionary<string, string> Start(string input)
        {
            string[] wandel = Umwandeln(new string[9000], input);
            Dictionary<string, string> buch = Buch_schreiben(new Dictionary<string, string>(), wandel);
            return buch;
        }

        public static string[] Umwandeln(string[] wandel, string input)
        {
            wandel = Spalten(input);
            wandel = Leeren(wandel);
            return wandel;
        }

        public static string[] Spalten(string input)
        {
            string[] wandel = input.Split(';');
            return wandel;
        }

        public static string[] Leeren(string[] wandel)
        {
            List<string> liste = new List<string>(wandel);
            liste.Sort();
            liste.Remove("");
            wandel = liste.ToArray();
            return wandel;
        }

        public static Dictionary<string, string> Buch_schreiben(Dictionary<string, string> buch, string[] wandel)
        {
            buch = Eintragen(buch, wandel);
            buch = Buch_leeren(buch);
            return buch;
        }
        public static Dictionary<string, string> Eintragen(Dictionary<string, string> buch, string[] wandel)
        {
            for (int i = 0; i < wandel.Length; i++)
            {
                if (buch.Keys.Contains(wandel[i].Substring(0, wandel[i].IndexOf("="))) == false)
                {
                    buch.Add(wandel[i].Substring(0, wandel[i].IndexOf("=")), wandel[i].Substring(wandel[0].IndexOf("=") + 1, wandel[i].Length - 1 - wandel[i].IndexOf("=")));
                }
                else
                {
                    buch[wandel[i].Substring(0, wandel[i].IndexOf("="))] = wandel[i].Substring(wandel[i].IndexOf("=") + 1, wandel[i].Length - 1 - wandel[i].IndexOf("="));
                }
            }
            return buch;
        }

        public static Dictionary<string, string> Buch_leeren(Dictionary<string, string> buch)
        {
            buch.Remove("");
            return buch;
        }
    }
}
