using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using arbeit;
namespace Kalender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Jahr:                 "); int Jahr = Convert.ToInt32(Console.ReadLine());                
            Console.Write("Monat:                "); int Monat = Convert.ToInt32(Console.ReadLine());
            Console.Write("Wochentag (optional): "); string Wochentag = Console.ReadLine();
            Console.Clear();
            Arbeit.Start(Jahr,Monat,Wochentag);
        }
        
    }
}
