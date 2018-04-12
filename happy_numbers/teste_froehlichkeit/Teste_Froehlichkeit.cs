using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using happy_numbers;
using klasse_mit_Aufbau;

namespace teste_froehlichkeit
{
    [TestFixture]
    public class Teste_Froehlichkeit
    {
        [Test]
        public void Happy()
        {
            var erg = Klasse_mit_Aufbau.Liste_schreiben(19);
            Klasse_mit_Aufbau.Ergebnis(erg);
            Assert.AreEqual("82", erg[0]);
            Assert.AreEqual("68", erg[1]);
            Assert.AreEqual("100", erg[2]);
            Assert.AreEqual("1", erg[3]);
            Assert.AreEqual("Das ist eine fröhliche Zahl :D", erg[erg.Count - 1]);
        }

        [Test]
        public void Sad()
        {
            var erg = Klasse_mit_Aufbau.Liste_schreiben(62);
            Klasse_mit_Aufbau.Ergebnis(erg);
            Assert.AreEqual("40", erg[0]);
            Assert.AreEqual("16", erg[1]);
            Assert.AreEqual("89", erg[4]);
            Assert.AreEqual("4", erg[8]);
            Assert.AreEqual("Das ist eine traurige Zahl :C", erg[erg.Count - 1]);
        }

        [Test]
        public void Maximum()
        {
            var erg = Klasse_mit_Aufbau.Liste_schreiben(Int32.MaxValue);
            Klasse_mit_Aufbau.Ergebnis(erg);
            Assert.AreEqual("Das ist eine traurige Zahl :C", erg[erg.Count - 1]);
        }
    }
}
