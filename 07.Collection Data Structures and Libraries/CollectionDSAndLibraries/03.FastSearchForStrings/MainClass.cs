namespace FastSearchForStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            int countOfInitialSubstrings = int.Parse(Console.ReadLine());
            Dictionary<string, int> countOfSubstrings = new Dictionary<string, int>();
            for (int i = 0; i < countOfInitialSubstrings; i++)
            {
                string subString = Console.ReadLine();
                countOfSubstrings.Add(subString, 0);
            }

            int countOfRow = int.Parse(Console.ReadLine());
            var wordsAsChars = new BigList<char>();
            for (int i = 0; i < countOfRow; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                wordsAsChars.AddRange(row);
            }

            var buffer = new BigList<char>();
            for (int i = 0; i < wordsAsChars.Count; i++)
            {
                buffer.Add(wordsAsChars[i]);
                foreach (var key in countOfSubstrings.Keys.ToList())
                {
                    if (buffer.Count > key.Length)
                    {
                        string subString = string.Concat(buffer.Range(buffer.Count - key.Length, key.Length)).ToLower();
                        if (subString.Contains(key.ToLower()))
                        {
                            countOfSubstrings[key]++;
                        }
                    }
                }
            }

            foreach (var pair in countOfSubstrings)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

        }
    }
}
