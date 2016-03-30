namespace CountOfOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var allOccurances = numbers.GroupBy(a => a).ToDictionary(a => a.Key, a => a.Count());
            var sortedOccurances = allOccurances.OrderBy(a => a.Key);

            foreach (var occurance in sortedOccurances)
            {
                Console.WriteLine("{0} -> {1} times", occurance.Key, occurance.Value);
            }
        }
    }
}
