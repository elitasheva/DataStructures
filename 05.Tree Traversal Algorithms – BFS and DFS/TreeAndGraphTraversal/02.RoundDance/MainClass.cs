namespace RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        static Dictionary<int, List<int>> friendShips = new Dictionary<int, List<int>>();

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int startNode = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var first = input[0];
                var second = input[1];

                if (!friendShips.ContainsKey(first))
                {
                    friendShips[first] = new List<int>();
                }

                friendShips[first].Add(second);

                if (!friendShips.ContainsKey(second))
                {
                    friendShips[second] = new List<int>();
                }

                friendShips[second].Add(first);
            }

            List<int> currentSequence = new List<int>();
            List<int> maxSequence = new List<int>();
            DFS(startNode, startNode, currentSequence, maxSequence);

            Console.WriteLine(maxSequence.Count);
        }

        private static void DFS(int node, int prevNod, List<int> currentSequence, List<int> maxSequence)
        {
            currentSequence.Add(node);
            foreach (var child in friendShips[node])
            {
                if (child == prevNod)
                {
                    continue;
                }

                DFS(child, node, currentSequence, maxSequence);
                currentSequence.RemoveAt(currentSequence.Count - 1);
            }

            if (currentSequence.Count > maxSequence.Count)
            {
                maxSequence.Clear();
                maxSequence.AddRange(currentSequence);
                
            }

        }
    }
}
