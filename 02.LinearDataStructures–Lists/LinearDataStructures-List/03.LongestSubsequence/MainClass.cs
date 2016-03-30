namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> subsequence = FindLongestSubsequenceOfEqualNumbers(sequence);

            Console.WriteLine(string.Join(" ", subsequence));

        }

        public static List<int> FindLongestSubsequenceOfEqualNumbers(List<int> sequence)
        {
            List<int> subsequence = new List<int>();
            List<int> currentSubsequence = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                currentSubsequence.Add(sequence[i]);
                for (int j = i + 1; j < sequence.Count; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        currentSubsequence.Add(sequence[j]);
                    }
                    else
                    {
                        if (currentSubsequence.Count > subsequence.Count)
                        {
                            subsequence.Clear();
                            subsequence.AddRange(currentSubsequence);

                        }
                        currentSubsequence.Clear();
                        break;
                    }
                }
                if (currentSubsequence.Count > subsequence.Count)
                {
                    subsequence.Clear();
                    subsequence.AddRange(currentSubsequence);

                }
               currentSubsequence.Clear();
            }

            return subsequence;
        }
    }
}

//            if (numbers.Any())
//            {
//                longestSequence = numbers
//                    .Select((n, i) => new { Value = n, Index = i })
//                    .OrderBy(s => s.Value)
//                    .Select((o, i) => new { o.Value, Diff = i - o.Index })
//                    .GroupBy(s => new { s.Value, s.Diff })
//                    .OrderByDescending(g => g.Count())
//                    .First()
//                    .Select(f => f.Value)
//                    .ToList();
//            }
