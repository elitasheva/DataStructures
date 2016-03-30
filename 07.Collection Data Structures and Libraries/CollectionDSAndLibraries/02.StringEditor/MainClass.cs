namespace StringEditor
{
    using System;
    using System.Text;
    using Wintellect.PowerCollections;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var text = new BigList<char>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] parameters = input.Split(' ');
                string commnad = parameters[0];
                string newString = string.Empty;
                int startIndex = 0;
                int count = 0;
                switch (commnad)
                {
                    case "APPEND":
                        newString = GetNewString(parameters);
                        text.AddRange(newString);
                        Console.WriteLine("OK");
                        break;

                    case "INSERT":
                        newString = parameters[2];
                        int position = int.Parse(parameters[1]);
                        if (position < 0 || position > text.Count)
                        {
                            Console.WriteLine("ERROR");
                        }
                        else
                        {
                            text.InsertRange(position, newString);
                            Console.WriteLine("OK");
                        }
                        break;

                    case "DELETE":
                        startIndex = int.Parse(parameters[1]);
                        count = int.Parse(parameters[2]);
                        if (startIndex < 0 || startIndex + count > text.Count)
                        {
                            Console.WriteLine("ERROR");
                        }
                        else
                        {
                            text.RemoveRange(startIndex, count);
                            Console.WriteLine("OK");
                        }
                        break;

                    case "REPLACE":
                        startIndex = int.Parse(parameters[1]);
                        count = int.Parse(parameters[2]);
                        newString = parameters[3];
                        if (startIndex < 0 || startIndex + count > text.Count)
                        {
                            Console.WriteLine("ERROR");
                        }
                        else
                        {
                            text.RemoveRange(startIndex, count);
                            text.InsertRange(startIndex, newString);
                            Console.WriteLine("OK");
                        }
                        break;

                    case "PRINT":
                        StringBuilder sb = new StringBuilder();
                        foreach (var symbol in text)
                        {
                            sb.Append(symbol);
                        }
                        Console.WriteLine(sb);
                        break;
                }

                input = Console.ReadLine();
            }

        }

        private static string GetNewString(string[] parameters)
        {
            string newString = string.Empty;
            if (parameters.Length > 2)
            {
                for (int i = 1; i < parameters.Length; i++)
                {
                    newString += parameters[i] + " ";
                }
            }
            else
            {
                newString = parameters[1];
            }
            return newString;
        }
    }
}
