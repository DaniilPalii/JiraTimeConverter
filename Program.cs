using System;

namespace JiraTimeConverter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                WriteTotalNormalHours(args);

                return;
            }

            Console.Write("Please, input a JIRA time: ");
            var jiraTimeItems = Console.ReadLine().Split(' ');

            WriteTotalNormalHours(jiraTimeItems);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void WriteTotalNormalHours(string[] jiraTimeItems)
        {
            var totalHours = new JiraTimeConverter().ConvertToNormalHours(jiraTimeItems);
            Console.WriteLine($"Total normal hours: {totalHours}");
        }
    }
}