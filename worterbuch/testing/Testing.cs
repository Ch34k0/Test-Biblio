using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worterbuch;
using NUnit.Framework;

namespace testing
{
    public class Testing
    {

        [TestFixture]
        public class Teste_Werte
        {
            //[Test]
            //public void Laeuft_es_denn()
            //{
            //   // Assert.Pass(Woerterbuch.Start("a=1;b=2;c=3"));
            //}

            [Test]
            public void Test1()
            {
                var erg = Woerterbuch.Spalten("a=1;b=2;c=3");
                Assert.AreEqual(erg[0], "a=1");
                Assert.AreEqual(erg[1], "b=2");
                Assert.AreEqual(erg[2], "c=3");
            }

            [Test]
            public void Test2()
            {
                var erg = Woerterbuch.Start("a=1;a=2;c=3");
                Assert.AreEqual(erg["a"], "2");
                Assert.AreEqual(erg["c"], "3");
            }

            [Test]
            public void Test3()
            {
                var erg = Woerterbuch.Start("a=1;;b=2");
                Assert.AreEqual(erg["a"], "1");
                Assert.AreEqual(erg["b"], "2");
            }

            [Test]
            public void Test4()
            {
                var erg = Woerterbuch.Start("a=");
                Assert.AreEqual(erg["a"], "");
            }

            [Test]
            public void Test5()
            {
                var erg = Woerterbuch.Start("=1");
                Assert.AreEqual(erg.Count, 0);
            }

            [Test]
            public void Test6()
            {
                var erg = Woerterbuch.Start("");
                Assert.AreEqual(erg.Count, 0);
            }

            [Test]
            public void Test7()
            {
                var erg = Woerterbuch.Start("a==1");
                Assert.AreEqual(erg["a"], "=1");
            }

            [Test]
            public void Test8()
            {
                var erg = Woerterbuch.Start("a=1;b=2;c=;a=5;;c=3;d=1;b=2;z=Ich werde gezwungen CleanCode zu schreiben");
                Assert.AreEqual(erg["a"], "5");
                Assert.AreEqual(erg["b"], "2");
                Assert.AreEqual(erg["c"], "3");
                Assert.AreEqual(erg["d"], "1");
                Assert.AreEqual(erg["z"], "Ich werde gezwungen CleanCode zu schreiben");
            }
        }
    }
}
