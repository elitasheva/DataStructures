using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    private static List<int>[] graph;
    //{
    //    new List<int>() {3, 6},
    //    new List<int>() {3, 4, 5, 6},
    //    new List<int>() {8},
    //    new List<int>() {0, 1, 5},
    //    new List<int>() {1, 6},
    //    new List<int>() {1, 3},
    //    new List<int>() {0, 1, 4},
    //    new List<int>() {},
    //    new List<int>() {2},
    //};

    static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        //visited = new bool[graph.Length];
        //DFS(0);
        //Console.WriteLine();

        FindGraphConnectedComponent();
    }

    public static List<int>[] ReadGraph()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        List<int>[] graph = new List<int>[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {

            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        return graph;
    }

    public static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child);
            }

            Console.Write(" " + node);
        }
    }

    public static void FindGraphConnectedComponent()
    {
        visited = new bool[graph.Length];

        for (int startIndex = 0; startIndex < graph.Length; startIndex++)
        {
            if (!visited[startIndex])
            {
                Console.Write("Connected component:");
                DFS(startIndex);
                Console.WriteLine();
            }
        }
    }
}
