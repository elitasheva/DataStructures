namespace ImplementationOfReversedList
{
    using System;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);

            int count = reversedList.Count;
            foreach (var item in reversedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var element = reversedList.Remove(3);
            count = reversedList.Count;
            foreach (var item in reversedList)
            {
                Console.WriteLine(item);
            }

            var element1 = reversedList[0];
            var capacity = reversedList.Capacity;
        }
    }
}
