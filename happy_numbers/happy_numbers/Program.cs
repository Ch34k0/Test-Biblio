using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace happy_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            wayStart:
            Console.WriteLine("Geben Sie eine Zahl ein!");
            int x = Convert.ToInt32(Console.ReadLine());
            int y, z = 0;
            Console.Clear();
            Console.Write(x);
            while (x.ToString().Length > 1)
            {
                for (int i = 0; i < x.ToString().Length; i++)
                {
                    y = Convert.ToInt32(Math.Pow(Convert.ToInt32(x.ToString().Substring(i, 1)), 2));
                    z += y;
                }
                x = z;
                z = 0;
                Console.Write(" --> " + x);
            }
            if (x == 1)
            {
                Console.WriteLine(Environment.NewLine + "Das ist eine fröhliche Zahl :D");
            }
            else if (x == 4)
            {
                Console.WriteLine(Environment.NewLine + "Das ist eine traurige Zahl :C");
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Dieser Zahl ist alles egal :|");
            }
            Console.ReadLine();
            Console.Clear();
            goto wayStart;
        }
    }
}
