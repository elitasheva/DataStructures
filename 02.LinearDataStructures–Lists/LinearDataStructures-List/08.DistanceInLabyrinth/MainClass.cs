namespace DistanceInLabyrinth
{
    using System;
   
    public class MainClass
    {
        public static void Main(string[] args)
        {
            string[,] matrix = new string[,]
            {
                {"0", "0", "0", "x", "0", "x"},
                {"0", "x", "0", "x", "0", "x"},
                {"0", "*", "x", "0", "x", "0"},
                {"0", "x", "0", "0", "0", "0"},
                {"0", "0", "0", "x", "x", "0"},
                {"0", "0", "0", "x", "0", "x"}
            };

            bool[,] isVisited = new bool[matrix.GetLength(0),matrix.GetLength(1)];

            int startRow = 2;
            int startCol = 1;
            int count = 0;

            FindPaths(startRow, startCol, matrix, count, isVisited);

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == "0")
                    {
                        matrix[row, col] = "u";
                    }
                    Console.Write("{0} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static void FindPaths(int startRow, int startCol, string[,] matrix, int count, bool[,] isVisited)
        {

            count++;
            if (startCol + 1 < matrix.GetLength(1) && 
                matrix[startRow, startCol + 1] == "0" && 
                isVisited[startRow, startCol + 1] == false &&
                int.Parse(matrix[startRow,startCol+1]) < count)
            {
                matrix[startRow, startCol + 1] = count.ToString();
                isVisited[startRow, startCol + 1] = true;
                FindPaths(startRow, startCol + 1, matrix, count, isVisited);
            }

            if (startRow - 1 >= 0 && 
                matrix[startRow - 1, startCol] == "0" && 
                isVisited[startRow - 1, startCol] == false &&
                int.Parse(matrix[startRow - 1, startCol]) < count)
            {
                matrix[startRow - 1, startCol] = count.ToString();
                isVisited[startRow - 1, startCol] = true;
                FindPaths(startRow - 1, startCol, matrix, count, isVisited);
            }

            if (startRow + 1 < matrix.GetLength(0) && 
                matrix[startRow + 1, startCol] == "0" && 
                isVisited[startRow + 1, startCol] == false &&
                int.Parse(matrix[startRow + 1, startCol]) < count)
            {
                matrix[startRow + 1, startCol] = count.ToString();
                isVisited[startRow + 1, startCol] = true;
                FindPaths(startRow + 1, startCol, matrix, count, isVisited);

            }
            
            if (startCol - 1 >= 0 && 
                matrix[startRow, startCol - 1] == "0" && 
                isVisited[startRow, startCol - 1] == false &&
                int.Parse(matrix[startRow, startCol - 1]) < count)
            {
                matrix[startRow, startCol - 1] = count.ToString();
                isVisited[startRow, startCol - 1] = true;
                FindPaths(startRow, startCol - 1, matrix, count, isVisited);
            }
        }
    }
}
