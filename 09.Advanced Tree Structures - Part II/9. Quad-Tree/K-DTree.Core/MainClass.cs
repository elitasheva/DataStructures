namespace K_DTree.Core
{
    using System;
    using System.Collections.Generic;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<Star> stars = new List<Star>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0];
                double x = double.Parse(input[1]);
                double y = double.Parse(input[2]);
                stars.Add(new Star(name, x, y));

            }

            string[] range = Console.ReadLine().Split(' ');
            double centerX = double.Parse(range[1]);
            double centerY = double.Parse(range[2]);
            double radius = double.Parse(range[3]);

            K_DTree<Star> tree = new K_DTree<Star>(stars);

            foreach (var star in tree)
            {
                Console.WriteLine(star); 
            }

            var targets = tree.Range(centerX, centerY, radius);

            foreach (var target in targets)
            {
                Console.WriteLine(target);
            }

        }
    }
}
