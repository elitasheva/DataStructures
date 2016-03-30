namespace SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            words.Sort();
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
