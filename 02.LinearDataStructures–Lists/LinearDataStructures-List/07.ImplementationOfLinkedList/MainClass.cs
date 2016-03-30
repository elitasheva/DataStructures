namespace ImplementationOfLinkedList
{
    using System;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);
           
            
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine(list.Count);

            Console.WriteLine("Remove {0}",list.Remove(0));
            Console.WriteLine("Remove {0}", list.Remove(0));
            Console.WriteLine("Remove {0}", list.Remove(0));

            Console.WriteLine(list.Count);

            list.Add(5);
            list.Add(8);
            list.Add(10);
            list.Add(8);
            list.Add(8);
            var index = list.FirstIndexOf(8);
            var index1 = list.LastIndexOf(8);
        }
    }
}
