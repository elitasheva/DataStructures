namespace ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("(empty)");
            }
            else
            {
                List<int> numbersList = input.Split().Select(int.Parse).ToList();
                Stack<int> numbersStack = new Stack<int>(numbersList);
                foreach (var number in numbersStack)
                {
                    Console.Write("{0} ", number);
                }
            }
        }
    }
}
