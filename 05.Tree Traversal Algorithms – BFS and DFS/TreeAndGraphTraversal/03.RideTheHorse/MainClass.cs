namespace RideTheHorse
{
    using System;
    using System.Collections.Generic;

    public class MainClass
    {
        private class Cell
        {
            public Cell(int row, int col, int value)
            {
                this.Row = row;
                this.Col = col;
                this.Value = value;
            }

            public int Row { get; set; }
            public int Col { get; set; }
            public int Value { get; set; }
        }

        private static Queue<Cell> positions = new Queue<Cell>();

        public static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfCols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            int[,] matrix = new int[numberOfRows, numberOfCols];

            positions.Enqueue(new Cell(startRow, startCol, 1));

            while (positions.Count > 0)
            {
                var currentCell = positions.Dequeue();
                matrix[currentCell.Row, currentCell.Col] = currentCell.Value;

                TryDirection(matrix, currentCell, -2, 1);
                TryDirection(matrix, currentCell, -1, 2);
                TryDirection(matrix, currentCell, 1, 2);
                TryDirection(matrix, currentCell, 2, 1);
                TryDirection(matrix, currentCell, 2, -1);
                TryDirection(matrix, currentCell, 1, -2);
                TryDirection(matrix, currentCell, -1, -2);
                TryDirection(matrix, currentCell, -2, -1);
            }

            Console.WriteLine();
            PrintResult(matrix);
        }

        private static void PrintResult(int[,] matrix)
        {
            int col = matrix.GetLength(1) / 2;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(matrix[row,col]);
            }
        }

        private static void TryDirection(int[,] matrix, Cell currentCell, int dr, int dc)
        {
            int newRow = currentCell.Row + dr;
            int newCol = currentCell.Col + dc;

            if (newRow >= 0 && newRow < matrix.GetLength(0) &&
                newCol >= 0 && newCol < matrix.GetLength(1) &&
                matrix[newRow, newCol] == 0)
            {
                var nextCell = new Cell(newRow, newCol, currentCell.Value + 1);
                positions.Enqueue(nextCell);
            }
        }
    }
}
