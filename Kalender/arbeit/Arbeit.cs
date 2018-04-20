using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace arbeit
{
    public class Arbeit
    {
        public static void Start(int jahr, int monat, string wochentag)
        {
            int Umbruch = new int();
            string text;
            string[] Tage = new string[14] { "So", "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So", "Mo", "Di", "Mi", "Do", "Fr", "Sa" };
            string[] Days = new string[14] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
            string[] Monate = new string[12] { "Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };
            DateTime myDT = new DateTime(jahr, monat, 1, new GregorianCalendar());
            Calendar myCal = CultureInfo.InvariantCulture.Calendar;

            int Tag = Tag_rechnen(myCal, jahr, monat, new int());
            wochentag = Wochentag_rechnen(wochentag, Tage, Days, myCal, myDT);

            Schreibe_Kopf(Monate, myCal, myDT, wochentag, Tage);

            Umbruch = Schreibe_Luecke(myCal, myDT, wochentag, Tage, Days, new int());

            Schreibe_Kalender(myCal, myDT, Umbruch, Tag, string.Empty);
            Console.ReadKey();
        }

        public static int Tag_rechnen(Calendar myCal, int jahr, int monat, int tag)
        {
            tag = myCal.GetDaysInMonth(jahr, monat);
            return tag;
        }

        public static string Wochentag_rechnen(string Wochentag, string[] Tage, string[] Days, Calendar myCal, DateTime myDT)
        {
            if (Wochentag.Length == 0)
            {
                Wochentag = Tage[Array.IndexOf(Days, myCal.GetDayOfWeek(myDT).ToString().Substring(0, 2))];
            }
            else
            {
                Wochentag = Wochentag.Substring(0, 2);
            }
            Wochentag = Wochentag.Substring(0, 1).ToUpper() + Wochentag.Substring(1, 1);
            return Wochentag;
        }

        public static void Schreibe_Kopf(string[] Monate, Calendar myCal, DateTime myDT, string wochentag, string[] Tage)
        {
            Console.WriteLine(Monate[myCal.GetMonth(myDT) - 1] + "  " + myCal.GetYear(myDT) + "  " + wochentag);
            for (int i = 0; i < 7; i++)
            {
                Console.Write(" " + Tage[Array.IndexOf(Tage, wochentag) + i]);
            }
            Console.WriteLine();
        }

        public static int Schreibe_Luecke(Calendar myCal, DateTime myDT, string wochentag, string[] Tage, string[] Days, int Umbruch)
        {
            if (Tage[Array.IndexOf(Days, myCal.GetDayOfWeek(myDT).ToString().Substring(0, 2))] != wochentag)
            {
                for (int i = 7 - Array.IndexOf(Tage, wochentag); i >= 0; i--)
                {
                    if (Umbruch >= 6)
                    {
                        Console.CursorLeft = 0;
                    }
                    Console.Write("   ");
                    Umbruch++;
                }
            }
            return Umbruch;
        }

        public static void Schreibe_Kalender(Calendar myCal, DateTime myDT, int Umbruch, int Tag, string text)
        {
            for (int i = 0; i < Tag; i++)
            {
                if (Umbruch % 7 == 0 && Umbruch != 0)
                {
                    Console.WriteLine();
                }
                text = myCal.GetDayOfMonth((myCal.AddDays(myDT, i))).ToString();
                do
                {
                    text = " " + text;
                } while (text.Length != 3);
                Console.Write(text);
                Umbruch++;
            }
        }
    }
}
