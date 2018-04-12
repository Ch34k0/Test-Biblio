using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace die_spinnen_doch
{
    public class Programm
    {
        public static string Main(string y)
        {
            int x, i = 0, k = 6;
            string roman = "", ziel = "";
            bool z;

            Dictionary<int, string> romantext = new Dictionary<int, string>()
            { {  0, "M" }, { 1, "D" }, { 2, "C" }, { 3, "L" }, { 4, "X" },{ 5, "V" },{ 6, "I" } };
            Dictionary<int, int> romanzahl = new Dictionary<int, int>()
            { {  0, 1000 },{ 1, 500 },{ 2, 100 }, { 3, 50 },{ 4, 10 }, { 5, 5 }, { 6, 1 } };

            for (int s = y.Length; s > 0; s--)
            {
                x = Convert.ToInt32(y.Substring(s - 1, 1)) * Convert.ToInt32(Math.Pow(10, y.Length - s));
                while (x > 0)
                {
                    z = false;

                    for (k = 6; k > 0; k--)
                    {

                        if (romanzahl[k] - x > 0)
                        {
                            if ((romanzahl[k] - x) == Convert.ToInt32(Math.Pow(10, y.Length - s)))
                            {
                                x = romanzahl[k] - x;
                                roman = romantext[k] + roman;
                                z = true;
                                break;
                            }
                        }
                    }

                    for (i = 0; i < 7; i++)
                    {
                        if (x - romanzahl[i] >= 0)
                        {
                            x = x - romanzahl[i];
                            if (z == false)
                            {
                                roman = roman + romantext[i];
                            }
                            else
                            {
                                roman = romantext[i] + roman;
                            }
                            break;
                        }
                    }
                }
                ziel = roman + ziel;
                roman = "";
            }
            return ziel;
        }
    }
}
