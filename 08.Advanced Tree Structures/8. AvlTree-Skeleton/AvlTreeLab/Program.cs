using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var set = new AvlTree<int>();

            //for (int i = 0; i < input.Length; i++)
            //{
            //    set.Add(input[i]);
            //}

            //int[] range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            set.Add(20);
            set.Add(30);
            set.Add(5);
            set.Add(8);
            set.Add(14);
            set.Add(18);
            set.Add(-2);
            set.Add(0);
            set.Add(50);
            set.Add(50);

            //List<int> elements = set.Range(range[0], range[1]);

            //foreach (var element in elements)
            //{
            //    Console.WriteLine(element);
            //}

            int b = set[5];
            int c = set[2];
            int d = set[3];
            int e = set[1];

            var a = 5;

        }
    }
}
