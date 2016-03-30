namespace _04.CollectionOfProducts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            var products = new List<Product>()
            {
              new Product(1, "kiselo mlqko", "Bor Chvor", 1.20M),
              new Product(2, "prqsno mlqko", "Bor Chvor", 2.00M),
              new Product(3, "sirene", "Bor Chvor", 7.50M),
              new Product(4, "sirene", "Olimpys", 7.50M),
              new Product(5, "kiselo mlqko", "Rodopeq", 1.10M),
              new Product(6, "kiselo mlqko", "Vereq", 1.00M),
              new Product(7, "prqsno mlqko", "Vereq", 2.50M),
              new Product(8, "kiselo mlqko", "na baba", 1.10M),
            };

            ProductCollection collection = new ProductCollection();

            foreach (var product in products)
            {
               collection.Add(product.Id,product.Title,product.Supplier, product.Price); 
            }

            var productsByTitle = collection.FindProductsByTitle("kiselo mlqko");

            foreach (var product in productsByTitle)
            {
                Console.WriteLine(product);
            }

            var productsByTitleAndPriceRange1 = collection.FindProductsByTitleAndPriceRange("kiselo mlqko", 2.00M, 3.00M);

            foreach (var product in productsByTitleAndPriceRange1)
            {
                Console.WriteLine(product);
            }

            var productsByTitleAndPriceRange2 = collection.FindProductsByTitleAndPriceRange("kiselo mlqko", 1.00M, 1.10M);

            foreach (DictionaryEntry product in productsByTitleAndPriceRange2)
            {
                Console.WriteLine(product.Key);
                
                foreach (Product pr in product.Value as SortedSet<Product>)
                {
                    Console.WriteLine(pr);
                }
            }

            collection.Remove(3);

            var productByTitleAndPrice = collection.FindProductsByTitleAndPrice("sirene", 7.50M);

            foreach (var product in productByTitleAndPrice)
            {
                Console.WriteLine(product);
            }

            var productsByTitle1 = collection.FindProductsByTitle("ovche sirene");

            foreach (var product in productsByTitle1)
            {
                Console.WriteLine(product);
            }

            
            
        }
    }
}
