namespace CountSymbols
{
    using System;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var hashTable = new HashTable<char, int>();
            foreach (var symbol in input)
            {
                if (!hashTable.ContainsKey(symbol))
                {
                    hashTable[symbol] = 0;
                }

                hashTable[symbol]++;
            }

            var keys = hashTable.Keys.OrderBy(a => a);
            foreach (var key in keys)
            {
                Console.WriteLine("{0}: {1} time/s", key, hashTable[key]);
            }

        }
    }
}
