namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        public static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodeCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            Tree<int> root = FindRootNode();
            Console.WriteLine("Root: {0}", root.Value);

            IEnumerable<Tree<int>> middleNodes = FindMiddleNodes();
            Console.Write("Middle nodes: ");
            foreach (var node in middleNodes.OrderBy(a => a.Value))
            {
                Console.Write("{0} ", node.Value);
            }
            Console.WriteLine();

            IEnumerable<Tree<int>> leafNodes = FindLeafNodes();
            Console.Write("Leaf nodes: ");
            foreach (var node in leafNodes.OrderBy(a => a.Value))
            {
                Console.Write("{0} ", node.Value);
            }
            Console.WriteLine();

            var longestPath = new List<int>();
            var currentPath = new List<int>();
            FindLongestPath(root, longestPath, currentPath);
            Console.WriteLine("Longest path:");
            Console.WriteLine("{0} (length = {1})", string.Join(" -> ", longestPath), longestPath.Count);

            currentPath.Clear();
            Console.WriteLine("Paths of sum {0}:", pathSum);
            FindPathEqualsToSum(root, pathSum, currentPath);

            currentPath.Clear();
            Console.WriteLine("Subtrees of sum {0}:",subtreeSum);
            FindSubtreeSum(root, subtreeSum, currentPath);

        }

        private static void FindSubtreeSum(Tree<int> root, int subtreeSum, List<int> currentPath)
        {
            currentPath.Add(root.Value);
            foreach (var child in root.Children)
            {
                currentPath.Add(child.Value);
            }

            if (currentPath.Sum() == subtreeSum)
            {
                Console.WriteLine("{0}", string.Join(" + ", currentPath));
            }

            currentPath.Clear();
            foreach (var child in root.Children)
            {
                FindSubtreeSum(child,subtreeSum,currentPath);
            }

        }

        private static void FindPathEqualsToSum(Tree<int> root, int pathSum, List<int> currentPath)
        {
            currentPath.Add(root.Value);
            foreach (var child in root.Children)
            {
                FindPathEqualsToSum(child, pathSum, currentPath);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            if (currentPath.Sum() == pathSum)
            {
                Console.WriteLine("{0}", string.Join(" -> ", currentPath));
            }
        }

        private static void FindLongestPath(Tree<int> root, List<int> longestPath, List<int> currentPath)
        {
            currentPath.Add(root.Value);
            foreach (var child in root.Children)
            {
                FindLongestPath(child, longestPath, currentPath);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            if (currentPath.Count > longestPath.Count)
            {
                longestPath.Clear();
                longestPath.AddRange(currentPath);

            }

        }


        private static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values.Where(node => node.Children.Count == 0);
            return leafNodes;
        }

        private static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values.Where(node => node.Parent != null && node.Children.Count > 0);
            return middleNodes;
        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }
    }
}
