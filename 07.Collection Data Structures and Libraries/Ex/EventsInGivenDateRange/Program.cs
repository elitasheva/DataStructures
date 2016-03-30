namespace EventsInGivenDateRange
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var events = new OrderedMultiDictionary<DateTime, string>(true);

            int countOfevents = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfevents; i++)
            {
                string[] input = Console.ReadLine().Split('|').ToArray();

                DateTime date = DateTime.Parse(input[1].Trim());
                string typeEvenet = input[0].Trim();

                events.Add(date, typeEvenet);
            }

            int ranges = int.Parse(Console.ReadLine());
            for (int i = 0; i < ranges; i++)
            {
                string[] parameters = Console.ReadLine().Split('|');
                DateTime startDate = DateTime.Parse(parameters[0].Trim());
                DateTime endDate = DateTime.Parse(parameters[1].Trim());

                var eventsInRange = events.Range(startDate, true, endDate, true);
                Console.WriteLine(eventsInRange.KeyValuePairs.Count);
                foreach (var item in eventsInRange)
                {
                    foreach (var value in item.Value)
                    {
                        Console.WriteLine("{0} | {1:dd-MMM-yyyy}", value, item.Key);
                    }
                }
            }

        }
    }
}
