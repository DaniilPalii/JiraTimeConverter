using System;
using System.Text.RegularExpressions;

namespace JiraTimeConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var isItInteractiveMode = false;

            if (args.Length == 0)
            {
                isItInteractiveMode = true;

                Console.Write("Please, input a JIRA time: ");
                args = Console.ReadLine().Split(' ');
            }

            var totalHours = CountTotalNormalHours(args);
            Console.WriteLine($"Total normal hours: {totalHours}");

            if (isItInteractiveMode)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static double CountTotalNormalHours(string[] args)
        {
            var totalHours = 0d;

            foreach (var item in args)
            {
                if (WeekRegex.TryMatchInt(item, out var weeks))
                {
                    totalHours += weeks.Value * DaysInWeek * HoursInDay;
                }
                else if (DayRegex.TryMatchInt(item, out var days))
                {
                    totalHours += days.Value * HoursInDay;
                }
                else if (HourRegex.TryMatchInt(item, out var hours))
                {
                    totalHours += hours.Value;
                }
                else if (MinutesRegex.TryMatchInt(item, out var minutes))
                {
                    totalHours += (double)minutes.Value / MinutesInHour;
                }
                else
                {
                    Console.WriteLine($"Error: can't understand \"{item}\"");
                }
            }

            return totalHours;
        }

        private static readonly Regex WeekRegex = new Regex(@"(?<=(\s|^))\d+(?=(w|W)(\s|$))");
        private static readonly Regex DayRegex = new Regex(@"(?<=(\s|^))\d+(?=(d|D)(\s|$))");
        private static readonly Regex HourRegex = new Regex(@"(?<=(\s|^))\d+(?=(h|H)(\s|$))");
        private static readonly Regex MinutesRegex = new Regex(@"(?<=(\s|^))\d+(?=(m|M)(\s|$))");

        private const int DaysInWeek = 5;
        private const int HoursInDay = 8;
        private const int MinutesInHour = 60;
    }
}
