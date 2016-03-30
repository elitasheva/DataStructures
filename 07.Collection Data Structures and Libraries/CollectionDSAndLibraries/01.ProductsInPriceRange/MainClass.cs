namespace ProductsInPriceRange
{
    using System;
    using Wintellect.PowerCollections;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var productsByPrice = new OrderedMultiDictionary<decimal, string>(true);

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                productsByPrice.Add(price, product);
            }

            string[] range = Console.ReadLine().Split(' ');
            decimal from = decimal.Parse(range[0]);
            decimal to = decimal.Parse(range[1]);
            if (from > to)
            {
               throw new InvalidOperationException("Invalid range.");
            }

            var productsInRange = productsByPrice.Range(from, true, to, true);
            Console.WriteLine(productsInRange.Count);

            foreach (var product in productsInRange)
            {
                foreach (var value in product.Value)
                {
                    Console.WriteLine("{0} {1}", product.Key, value);
                }
            }


        }
    }
}
