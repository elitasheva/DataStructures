namespace CalculateSequence
{
    using System;
    using System.Collections.Generic;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Queue<int> sequence = new Queue<int>();
            int input = int.Parse(Console.ReadLine());
            sequence.Enqueue(input);

            for (int i = 0; i < 50; i++)
            {
                int firstNumber = sequence.Dequeue();
                Console.Write("{0} ",firstNumber);
                int seconNumber = firstNumber + 1;
                sequence.Enqueue(seconNumber);
                int thirdNumber = 2 * firstNumber + 1;
                sequence.Enqueue(thirdNumber);
                int fourthNumbers = firstNumber + 2;
                sequence.Enqueue(fourthNumbers);
            }
        }
    }
}
