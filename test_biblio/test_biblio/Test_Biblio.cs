using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_biblio
{
    public class Test_Biblio
    {
        public static List<int> Start_Zahlen_testen(int unter, int ober)
        {
            var zahlen = Zahlen_testen(unter, ober);
            return zahlen;

        }

        internal static List<int> Zahlen_testen(int unter, int ober)
        {
            var zahlen = new List<int>();
            for (int zahl = unter; zahl <= ober; zahl++)
            {
                zahlen.Add(zahl);
            }
            return zahlen;
        }
    }
}
