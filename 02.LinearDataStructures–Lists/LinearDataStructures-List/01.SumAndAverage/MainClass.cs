namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<int> numbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (string.IsNullOrEmpty(input[i]))
                {
                    numbers.Add(0);
                }
                else
                {
                    numbers.Add(int.Parse(input[i]));
                }
            }
            Console.WriteLine("Sum={0}; Average={1}",numbers.Sum(),numbers.Average());
        }
    }
}
