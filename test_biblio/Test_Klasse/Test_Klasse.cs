using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_biblio;
using NUnit.Framework;

namespace Test_Klasse
{
    [TestFixture]
    public class Test_Klasse
    {
        [Test, Category("Akzeptanztest")]
        public void Zahlen_zwischen_unten_und_oben()
        {
            var ergebnis = Test_Biblio.Start_Zahlen_testen(3, 5);
            Assert.AreEqual(new[] { 3, 4, 5 }, ergebnis.ToArray());
        }

        [Test, Category("Gerüsttest")]
        public void Anzahl_Zahlen()
        {
            var ergebnis = Test_Biblio.Zahlen_testen(-1, 45);
            Assert.AreEqual(46,ergebnis.Count());
        }
    }
}
