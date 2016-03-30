using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Escape_from_Labyrinth;

public class EscapeFromLabyrinth
{
    private const char VisitedCell = 's';
    private static int width;
    private static int height;
    private static char[,] labyrinth;

    public static void Main()
    {
        ReadLabyrinth();
        var shortestPathToExit = FindShortestPathToExit();
        if (shortestPathToExit == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (shortestPathToExit == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + shortestPathToExit);
        }
    }

    static void ReadLabyrinth()
    {
        //height = int.Parse(Console.ReadLine());
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());

        labyrinth = new char[height, width];
        for (int row = 0; row < height; row++)
        {
            string input = Console.ReadLine();
            for (int col = 0; col < width; col++)
            {
                labyrinth[row, col] = input[col];
            }
        }

    }

    static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();
        if (startPosition == null)
        {
            return null;
        }

        queue.Enqueue(startPosition);

        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();

            if (IsExit(currentCell))
            {
                return TraceBackPath(currentCell);
            }

            TryDirection(queue, currentCell, "U", -1, 0);
            TryDirection(queue, currentCell, "R", 0, 1);
            TryDirection(queue, currentCell, "D", 1, 0);
            TryDirection(queue, currentCell, "L", 0, -1);
        }

        return null;
    }

    private static string TraceBackPath(Point currentCell)
    {
        var path = new StringBuilder();
        while (currentCell.PriviousPoint != null)
        {
            path.Append(currentCell.Direction);
            currentCell = currentCell.PriviousPoint;
        }

        var pathReversed = new StringBuilder(path.Length);
        for (int i = path.Length - 1; i >= 0; i--)
        {
            pathReversed.Append(path[i]);
        }

        return pathReversed.ToString();
    }

    private static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int dx, int dy)
    {
        int newX = currentCell.X + dx;
        int newY = currentCell.Y + dy;

        if (newX >= 0 && newX < height && newY >= 0 && newY < width && labyrinth[newX, newY] == '-')
        {
            labyrinth[newX, newY] = VisitedCell;
            var nextCell = new Point(newX, newY, direction, currentCell);
            queue.Enqueue(nextCell);
        }
    }

    private static bool IsExit(Point currentCell)
    {
        bool isOnBorderX = currentCell.X == 0 || currentCell.X == height - 1;
        bool isOnBorderY = currentCell.Y == 0 || currentCell.Y == width - 1;
        return isOnBorderX || isOnBorderY;
    }

    private static Point FindStartPosition()
    {
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                if (labyrinth[x, y] == VisitedCell)
                {
                    var startPoint = new Point(x, y, "s", null);
                    return startPoint;
                }
            }
        }

        return null;
    }
}

