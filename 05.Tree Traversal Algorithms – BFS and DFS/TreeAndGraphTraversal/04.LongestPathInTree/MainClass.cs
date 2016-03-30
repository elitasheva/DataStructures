namespace LongestPathInTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;

    public class MainClass
    {
        private static Dictionary<int, List<int>> children = new Dictionary<int, List<int>>();
        private static Dictionary<int, int?> parents = new Dictionary<int, int?>();

        public static void Main(string[] args)
        {
            int countOfNodes = int.Parse(Console.ReadLine());
            int countOfEdges = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfEdges; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var parent = input[0];
                var child = input[1];

                if (!children.ContainsKey(parent))
                {
                    children[parent] = new List<int>();
                }

                children[parent].Add(child);

                if (!children.ContainsKey(child))
                {
                    children[child] = new List<int>();
                }

                if (!parents.ContainsKey(child))
                {
                    parents[child] = parent;
                }

                if (!parents.ContainsKey(parent))
                {
                    parents[parent] = null;
                }

                parents[child] = parent;

            }

            int root = parents.FirstOrDefault(node => node.Value == null).Key;
            List<int> leafNodes = children.Where(n => n.Value.Count == 0).Select(n => n.Key).ToList();
            var possiblePaths = new List<List<int>>();
            foreach (var leaf in leafNodes)
            {
                List<int> temp = new List<int>();
                int currentNode = leaf;
                while (currentNode != root)
                {
                    List<int> maxTemp = new List<int>();
                    if (!temp.Contains(currentNode))
                    {
                        temp.Add(currentNode);
                    }
                    currentNode = (int)parents[currentNode];
                    temp.Add(currentNode);
                    if (children[currentNode].Count > 1)
                    {
                        DFS(currentNode, temp, maxTemp);
                        possiblePaths.Add(maxTemp);
                    }
                }

            }

            var countOfLongestPaths = possiblePaths.Max(subList => subList.Count);
            var longestPaths = possiblePaths.Where(subList => subList.Count == countOfLongestPaths).Select(s => s);
            var maxSum = longestPaths.Max(subList => subList.Sum());
            var subListWithMaxSum = longestPaths.FirstOrDefault(subList => subList.Sum() == maxSum);

            Console.WriteLine("Sum: {0}", maxSum);
            Console.WriteLine("Path: {0}", string.Join(" -> ", subListWithMaxSum));

        }

        static void DFS(int node, List<int> temp, List<int> maxTemp)
        {
            foreach (var child in children[node])
            {
                if (temp.Contains(child))
                {
                    continue;
                }

                temp.Add(child);
                DFS(child, temp, maxTemp);
                temp.RemoveAt(temp.Count - 1);
            }
            if (maxTemp.Count < temp.Count)
            {
                maxTemp.Clear();
                maxTemp.AddRange(temp);
            }
        }


    }
}
