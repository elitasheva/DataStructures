namespace RopeForEfficientStringEditing
{
    using System;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main(string[] args)
        {
           BigList<char> list = new BigList<char>();

            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] parameters = input.Split(' ');
                string command = parameters[0];
                string text = string.Empty;
                switch (command)
                {
                    case "INSERT":
                        text = parameters[1];
                        list.AddRangeToFront(text);
                        Console.WriteLine("OK");
                        break;
                    case "APPEND":
                        text = parameters[1];
                        list.AddRange(text);
                        Console.WriteLine("OK");
                        break;
                    case "DELETE":
                        int startIndex = int.Parse(parameters[1]);
                        int count = int.Parse(parameters[2]);
                        if (startIndex < 0 || startIndex + count < list.Count)
                        {
                            list.RemoveRange(startIndex, count);
                            Console.WriteLine("OK");
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                        }
                        break;
                    case "PRINT":
                        Console.WriteLine(list.ToString());
                        break;    
                }

                input = Console.ReadLine();
            }
        }
    }
}
