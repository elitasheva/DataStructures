namespace OrderedSet
{
    using System;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var set = new OrderedSet<int>();
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);
            set.Add(3);

            foreach (var element in set)
            {
                Console.WriteLine(element);  
            }

           
        }
    }
}
