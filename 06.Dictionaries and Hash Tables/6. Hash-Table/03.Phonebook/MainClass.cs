namespace Phonebook
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var hashTable = new HashTable<string, string>();

            while (input != "search")
            {
                string[] parameters = input.Split('-');
                string name = parameters[0];
                string phone = parameters[1];
                if (!hashTable.ContainsKey(name))
                {
                    hashTable[name] = string.Empty;
                }

                hashTable[name] = phone;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                if (!hashTable.ContainsKey(input))
                {
                    Console.WriteLine("Contact {0} does not exist", input);
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", input, hashTable[input]);
                }

                input = Console.ReadLine();
            }
        }
    }
}
