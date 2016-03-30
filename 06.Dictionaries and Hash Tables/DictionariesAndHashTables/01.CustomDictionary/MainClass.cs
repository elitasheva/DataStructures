namespace CustomDictionary
{
    using System;
    using System.Collections;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var hashtable = new Hashtable();
            hashtable.Add(2, "az");
            hashtable.Add("shhh", 5);

            foreach (DictionaryEntry pair in hashtable)
            {
                Console.WriteLine("{0}-{1}", pair.Key, pair.Value);
            }

            int a = (int)hashtable["shhh"];
            Console.WriteLine(a);

            var keys = hashtable.Keys;
        }
    }
}
