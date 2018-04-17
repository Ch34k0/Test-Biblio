using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using klasse_mit_Aufbau;


namespace happy_numbers
{
    class Program
    {
        static void Main(string[] args)
        {           
                Console.WriteLine("Geben Sie eine Zahl zwischen 10 und " + Int32.MaxValue + " ein!");
                var ursprungszahl = Convert.ToInt32(Console.ReadLine());
                Klasse_mit_Aufbau.Haupt(ursprungszahl);
        }
    }
}