using System;
using System.Text.RegularExpressions;

namespace JiraTimeConverter
{
    public class JiraTimeConverter
    {
        public double ConvertToNormalHours(string[] jiraTimeItems)
        {
            var totalHours = 0d;

            foreach (var item in jiraTimeItems)
            {
                if (weekRegex.TryMatchInt(item, out var weeks))
                {
                    totalHours += weeks.Value * DaysInWeek * HoursInDay;
                }
                else if (dayRegex.TryMatchInt(item, out var days))
                {
                    totalHours += days.Value * HoursInDay;
                }
                else if (hourRegex.TryMatchInt(item, out var hours))
                {
                    totalHours += hours.Value;
                }
                else if (minutesRegex.TryMatchInt(item, out var minutes))
                {
                    totalHours += (double) minutes.Value / MinutesInHour;
                }
                else
                {
                    Console.WriteLine($"Error: can't parse \"{item}\"");
                }
            }

            return totalHours;
        }
        
        private static Regex CreateJiraTimeItemRegex(char smallItemLetter, char bigItemLetter)
        {
            return new Regex($@"(?<=(\s|^))\d+(?=({smallItemLetter}|{bigItemLetter})(\s|$))");
        }

        private readonly Regex weekRegex = CreateJiraTimeItemRegex(smallItemLetter: 'w', bigItemLetter: 'W');
        private readonly Regex dayRegex = CreateJiraTimeItemRegex(smallItemLetter: 'd', bigItemLetter: 'D');
        private readonly Regex hourRegex = CreateJiraTimeItemRegex(smallItemLetter: 'h', bigItemLetter: 'H');
        private readonly Regex minutesRegex = CreateJiraTimeItemRegex(smallItemLetter: 'm', bigItemLetter: 'M');

        private const int DaysInWeek = 5;
        private const int HoursInDay = 8;
        private const int MinutesInHour = 60;
    }
}