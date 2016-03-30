namespace _04.CollectionOfProducts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProductCollection
    {
        private readonly Dictionary<int, Product> productsById;
        private readonly OrderedDictionary<decimal, SortedSet<Product>> productsByPriceRange;
        private readonly Dictionary<string, SortedSet<Product>> productsByTitle;
        private readonly Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByTitleAndPrice;
        private readonly Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsBySupplierAndPrice;

        public ProductCollection()
        {
            this.productsById = new Dictionary<int, Product>();
            this.productsByPriceRange = new OrderedDictionary<decimal, SortedSet<Product>>();
            this.productsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPrice = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            this.productsBySupplierAndPrice = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
        }

        public void Add(int id, string title, string supplier, decimal price)
        {
            if (this.productsById.ContainsKey(id))
            {
                this.Remove(id);
            }

            var newProduct = new Product(id, title, supplier, price);
            this.productsById[id] = newProduct;

            if (!this.productsByPriceRange.ContainsKey(price))
            {
                this.productsByPriceRange[price] = new SortedSet<Product>();
            }
            this.productsByPriceRange[price].Add(newProduct);

            if (!this.productsByTitle.ContainsKey(title))
            {
                 this.productsByTitle[title] = new SortedSet<Product>();
            }
            this.productsByTitle[title].Add(newProduct);

            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
               this.productsByTitleAndPrice[title] = new OrderedDictionary<decimal, SortedSet<Product>>(); 
            }

            if (!this.productsByTitleAndPrice[title].ContainsKey(price))
            {
                this.productsByTitleAndPrice[title][price] = new SortedSet<Product>();
            }
            this.productsByTitleAndPrice[title][price].Add(newProduct);

            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                 this.productsBySupplierAndPrice[supplier] = new OrderedDictionary<decimal, SortedSet<Product>>();
            }

            if (!this.productsBySupplierAndPrice[supplier].ContainsKey(price))
            {
               this.productsBySupplierAndPrice[supplier][price] = new SortedSet<Product>(); 
            }
            this.productsBySupplierAndPrice[supplier][price].Add(newProduct);

        }

        public bool Remove(int id)
        {
            var productForDelete = this.productsById[id];
            if (productForDelete == null)
            {
                return false;
            }

            this.productsById.Remove(id);
            this.productsByPriceRange[productForDelete.Price].Remove(productForDelete);
            this.productsByTitle[productForDelete.Title].Remove(productForDelete);
            this.productsByTitleAndPrice[productForDelete.Title][productForDelete.Price].Remove(productForDelete);
            this.productsBySupplierAndPrice[productForDelete.Supplier][productForDelete.Price].Remove(productForDelete);

            return true;

        }

        public IEnumerable FindProductsInPriceRange(decimal startPrice, decimal endPrice)
        {
            return this.productsByPriceRange.Range(startPrice, true, endPrice, true);
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            if (!this.productsByTitle.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitle[title];
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, decimal price)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(title) || !this.productsByTitleAndPrice[title].ContainsKey(price))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitleAndPrice[title][price];
        }

        public IEnumerable FindProductsByTitleAndPriceRange(string title, decimal startPrice, decimal endPrice)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }
            return this.productsByTitleAndPrice[title].Range(startPrice, true, endPrice, true);
        }

        public IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, decimal price)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(supplier) || !this.productsBySupplierAndPrice[supplier].ContainsKey(price))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsBySupplierAndPrice[supplier][price];
        }

        public IEnumerable FindProductsBySupplierAndPriceRange(string supplier, decimal startPrice, decimal endPrice)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(supplier))
            {
                return Enumerable.Empty<Product>();
            }
            return this.productsBySupplierAndPrice[supplier].Range(startPrice, true, endPrice, true);
        }
    }
}
