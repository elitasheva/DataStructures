namespace FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            int countOfNodes = int.Parse(Console.ReadLine());
            int countOfEdges = int.Parse(Console.ReadLine());

            bool[] hasParent = new bool[countOfNodes];

            List<int>[] graph = new List<int>[countOfEdges];

            for (int i = 0; i < countOfEdges; i++)
            {
                graph[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                int node = graph[i][1];
                hasParent[node] = true;
            }

            Console.WriteLine();
            var nodesWithoutParent = hasParent.Count(n => n == false);

            if (nodesWithoutParent == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (nodesWithoutParent == 1)
            {
                int index = Array.IndexOf(hasParent, false);
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }

        }
    }
}
