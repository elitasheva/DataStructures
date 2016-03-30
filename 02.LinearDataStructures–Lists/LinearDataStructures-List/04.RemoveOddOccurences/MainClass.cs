namespace RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var evenOccurance = numbers.GroupBy(a => a).Where(a => a.Count() % 2 != 0).SelectMany(a => a).ToList();
            numbers.RemoveAll(item => evenOccurance.Contains(item));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
//var evenOccurences = numbers
//         .Where(v => numbers.Count(n => v == n) % 2 == 0)
//         .ToList();