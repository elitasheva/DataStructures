namespace Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {

            int countOfNumbers = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int countOfConsecutiveElements = int.Parse(Console.ReadLine());

            int operationNeeded = -1;
            int numberOfPossibleCombinations = (countOfNumbers - countOfConsecutiveElements) + 1;
            Queue<int[]> combinations = new Queue<int[]>();
            Queue<int[]> prevCombinations = new Queue<int[]>();
            combinations.Enqueue(numbers);
            prevCombinations.Enqueue(numbers);

            while (combinations.Count > 0)
            {
                var currentCombination = combinations.Dequeue();
                operationNeeded++;
                if (CheckIfTheSequenceWasSorted(currentCombination))
                {
                    Console.WriteLine(string.Join(", ", currentCombination));
                    break;
                }

                for (int i = 0; i < numberOfPossibleCombinations; i++)
                {
                    int[] next = new int[currentCombination.Length];
                    Array.Copy(currentCombination, next, currentCombination.Length);
                    Array.Reverse(next, i, countOfConsecutiveElements);
                    if (!CheckForDuplicates(prevCombinations, next))
                    {
                        combinations.Enqueue(next);
                        prevCombinations.Enqueue(next);
                    }

                }

            }
            Console.WriteLine(operationNeeded);
        }

        private static bool CheckForDuplicates(Queue<int[]> combinations, int[] next)
        {
            bool hasDublicate = false;
            foreach (var combination in combinations)
            {
                if (combination.SequenceEqual(next))
                {
                    hasDublicate = true;
                    break;
                }
            }

            return hasDublicate;
        }

        private static bool CheckIfTheSequenceWasSorted(int[] currentCombination)
        {
            int[] sortedArray = new int[currentCombination.Length];
            Array.Copy(currentCombination, sortedArray, currentCombination.Length);
            Array.Sort(sortedArray);

            return currentCombination.SequenceEqual(sortedArray);
        }
    }
}
