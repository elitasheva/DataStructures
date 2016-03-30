namespace OrderedSetWithAVL
{
    using System;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var set = new OrderedSetWithAVL<int>();

            //Act
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);
            set.Add(3);

            //set.Remove(6);
            //set.Remove(19);
            //set.Remove(12);

            set.Remove(12);
            set.Remove(3);
            set.Remove(6);

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
