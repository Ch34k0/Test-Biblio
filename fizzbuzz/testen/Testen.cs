using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fizzbuzz;
using loesung;
using NUnit.Framework;

namespace testen
{
    [TestFixture]
    public class Testen
    {
        //[Test, Category("Akzeptanztest")]
        //public void Ganzes_Programm()
        //{
        //    Loesung.Durchlauf();
        //    Assert.Pass();
        //}

        [Test, Category("Akzeptanztest")]
        public void Eingabe()
        {
            var ergebnis = Loesung.EingabeZahlen(0, 17);
            Assert.AreEqual(17, ergebnis.Count());
        }

        //[Test, Category("Akzeptanztest")]
        //public void EingabeU()
        //{
        //    var ergU = Loesung.Eingabe_Unten(0);
        //    Assert.AreEqual(0, ergU);
        //}

        //[Test, Category("Akzeptanztest")]
        //public void EingabeO()
        //{
        //    var ergO = Loesung.Eingabe_Ober(9);
        //    Assert.AreEqual(9, ergO);
        //}

        [Test, Category("Akzeptanztest")]
        public void Verarbeitung()
        {

            var dick = Loesung.EingabeZahlen(0, 17);

            var dunn = new Dictionary<int, string>();
            dunn.Add(0, "fizzbuzz");
            dunn.Add(1, "1");
            dunn.Add(2, "2");
            dunn.Add(3, "fizz");
            dunn.Add(4, "4");
            dunn.Add(5, "buzz");
            dunn.Add(6, "fizz");
            dunn.Add(7, "7");
            dunn.Add(8, "8");
            dunn.Add(9, "fizz");
            dunn.Add(10, "buzz");
            dunn.Add(11, "11");
            dunn.Add(12, "fizz");
            dunn.Add(13, "13");
            dunn.Add(14, "14");
            dunn.Add(15, "fizzbuzz");
            dunn.Add(16, "16");
            dunn.Add(17, "17");
            var ergebnis = Loesung.Verarbeitung(dick, 0, 17);

            Assert.AreEqual(dunn.Count, ergebnis.Count);
            //var dick = new List<int>();
            //var dunn = new Dictionary<int, string>();
            //var ergebnis = Loesung.Verarbeitung(dick);
            foreach (var schluss in dunn.Keys)
            {
                Assert.AreEqual(dunn[schluss], ergebnis[schluss]);
            }

        }


        //[Test, Category("Akzeptanztest")]
        //public void Ausgabe()
        //{

        //    var ergebnis = Loesung.Ausgabe(zahlenfb, 5);
        //    Assert.AreEqual(new[] { 3, 4, 5 }, ergebnis.ToArray());
        //}
    }
}
