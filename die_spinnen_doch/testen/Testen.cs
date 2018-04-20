using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using die_spinnen_doch;

namespace testen
{
    [TestFixture]
    public class Testen
    {        
        [Test]
        public static void Test()
        {            
            Assert.AreEqual(Programm.Main("1"), "I");
            Assert.AreEqual(Programm.Main("2"), "II");
            Assert.AreEqual(Programm.Main("3"), "III");
            Assert.AreEqual(Programm.Main("4"), "IV");
            Assert.AreEqual(Programm.Main("5"), "V");
            Assert.AreEqual(Programm.Main("6"), "VI");
            Assert.AreEqual(Programm.Main("7"), "VII");
            Assert.AreEqual(Programm.Main("8"), "VIII");
            Assert.AreEqual(Programm.Main("9"), "IX");
            Assert.AreEqual(Programm.Main("10"), "X");
            Assert.AreEqual(Programm.Main("19"), "XIX");
            Assert.AreEqual(Programm.Main("69"), "LXIX");
            Assert.AreEqual(Programm.Main("42"), "XLII");
            Assert.AreEqual(Programm.Main("99"), "XCIX");
            Assert.AreEqual(Programm.Main("2018"), "MMXVIII");
            Assert.AreEqual(Programm.Main("3001"), "MMMI");
        }
    }
}
