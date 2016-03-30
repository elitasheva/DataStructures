namespace SweepAndPrune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<GameObject> objects = new List<GameObject>();
            int tickCount = 0;
            while (input != "start")
            {
                string[] parameters = input.Split(' ');
                string name = parameters[1];
                int x1 = int.Parse(parameters[2]);
                int y1 = int.Parse(parameters[3]);
                objects.Add(new GameObject(name, x1, y1));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] parameters = input.Split(' ');
                string command = parameters[0];

                tickCount++;

                if (command == "move")
                {
                    string name = parameters[1];
                    var currentObject = objects.FirstOrDefault(o => o.Name == name);
                    int newX1 = int.Parse(parameters[2]);
                    int newY1 = int.Parse(parameters[3]);

                    currentObject.Bounds.X1 = newX1;
                    currentObject.Bounds.Y1 = newY1;

                }

                SweepAndPrune(objects, tickCount);
                input = Console.ReadLine();
            }

        }

        private static void SweepAndPrune(List<GameObject> objects, int tickCount)
        {
            InsertionSort(objects);
            for (int i = 0; i < objects.Count; i++)
            {
                var currentObject = objects[i];
                for (int j = i + 1; j < objects.Count; j++)
                {
                    var candidateCollisionObject = objects[j];
                    if (currentObject.Bounds.X2 < candidateCollisionObject.Bounds.X1)
                    {
                        break;
                    }

                    if (currentObject.Bounds.Intersects(candidateCollisionObject.Bounds))
                    {
                        Console.WriteLine("({0}) {1} collides with {2}",
                            tickCount, currentObject.Name, candidateCollisionObject.Name);
                    }
                }
            }
        }

        private static void InsertionSort(List<GameObject> objects)
        {
            for (int i = 1; i < objects.Count; i++)
            {
                var currentObject = objects[i];
                int j = i - 1;

                while (j >= 0 && objects[j].Bounds.X1 > currentObject.Bounds.X1)
                {
                    objects[j + 1] = objects[j];
                    j--;
                }

                objects[j + 1] = currentObject;
            }
        }
    }
}
