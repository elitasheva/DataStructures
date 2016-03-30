namespace _03.CollectionOfProducts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProductCollection
    {
        private readonly Dictionary<int, Product> productsById;
        private readonly OrderedDictionary<decimal, SortedSet<Product>> productsByPriceRange;
        private readonly Dictionary<string, SortedSet<Product>> productsByTitle;
        private readonly Dictionary<Tuple<string, decimal>, SortedSet<Product>> productsByTitleAndPrice;
        private readonly Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByTitleAndPriceRange;
        private readonly Dictionary<Tuple<string, decimal>, SortedSet<Product>> productsBySupplierAndPrice;
        private readonly Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsBySupplierAndPriceRange;

        public ProductCollection()
        {
            this.productsById = new Dictionary<int, Product>();
            this.productsByPriceRange = new OrderedDictionary<decimal, SortedSet<Product>>();
            this.productsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPrice = new Dictionary<Tuple<string, decimal>, SortedSet<Product>>();
            this.productsByTitleAndPriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            this.productsBySupplierAndPrice = new Dictionary<Tuple<string, decimal>, SortedSet<Product>>();
            this.productsBySupplierAndPriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
        }

        public void Add(int id, string title, string supplier, decimal price)
        {
            var productForAdd = new Product(id, title, supplier, price);
            if (this.productsById.ContainsKey(id))
            {
                Remove(id);
            }
            this.productsById[id] = productForAdd;

            if (!this.productsByPriceRange.ContainsKey(price))
            {
                this.productsByPriceRange[price] = new SortedSet<Product>();
            }
            this.productsByPriceRange[price].Add(productForAdd);

            if (!this.productsByTitle.ContainsKey(title))
            {
                this.productsByTitle[title] = new SortedSet<Product>();
            }
            this.productsByTitle[title].Add(productForAdd);

            if (!this.productsByTitleAndPrice.ContainsKey(new Tuple<string, decimal>(title, price)))
            {
                this.productsByTitleAndPrice[new Tuple<string, decimal>(title, price)] = new SortedSet<Product>();
            }
            this.productsByTitleAndPrice[new Tuple<string, decimal>(title, price)].Add(productForAdd);

            if (!this.productsByTitleAndPriceRange.ContainsKey(title))
            {
                this.productsByTitleAndPriceRange[title] = new OrderedDictionary<decimal, SortedSet<Product>>();
            }

            if (!this.productsByTitleAndPriceRange[title].ContainsKey(price))
            {
                this.productsByTitleAndPriceRange[title][price] = new SortedSet<Product>();
            }
            this.productsByTitleAndPriceRange[title][price].Add(productForAdd);

            if (!this.productsBySupplierAndPrice.ContainsKey(new Tuple<string, decimal>(supplier,price)))
            {
              this.productsBySupplierAndPrice[new Tuple<string, decimal>(supplier,price)] = new SortedSet<Product>();  
            }
            this.productsBySupplierAndPrice[new Tuple<string, decimal>(supplier, price)].Add(productForAdd);

            if (!this.productsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                this.productsBySupplierAndPriceRange[supplier] = new OrderedDictionary<decimal, SortedSet<Product>>();
            }

            if (!this.productsBySupplierAndPriceRange[supplier].ContainsKey(price))
            {
                this.productsBySupplierAndPriceRange[supplier][price] = new SortedSet<Product>();
            }
            this.productsBySupplierAndPriceRange[supplier][price].Add(productForAdd);

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
            this.productsByTitleAndPrice[new Tuple<string, decimal>(productForDelete.Title, productForDelete.Price)]
                .Remove(productForDelete);
            this.productsByTitleAndPriceRange[productForDelete.Title][productForDelete.Price].Remove(productForDelete);
            this.productsBySupplierAndPrice[new Tuple<string, decimal>(productForDelete.Supplier, productForDelete.Price)]
                .Remove(productForDelete);
            this.productsBySupplierAndPriceRange[productForDelete.Supplier][productForDelete.Price].Remove(productForDelete);
            return true;
        }

        public IEnumerable FindProductsInPriceRange(decimal start, decimal end)
        {
            return this.productsByPriceRange.Range(start, true, end, true);
        }

        public IEnumerable FindProductsByTitle(string title)
        {
            if (!this.productsByTitle.ContainsKey(title))
            {
                 return Enumerable.Empty<Product>();
            }

            return this.productsByTitle[title];
        }

        public IEnumerable FindProductsByTitleAndPrice(string title, decimal price)
        {
            if (!this.productsByTitleAndPrice.ContainsKey(new Tuple<string, decimal>(title,price)))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitleAndPrice[new Tuple<string, decimal>(title, price)];
        }

        public IEnumerable FindProductsByTitleAndPriceRange(string title, decimal start, decimal end)
        {
            if (!this.productsByTitleAndPriceRange.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsByTitleAndPriceRange[title].Range(start, true, end, true);
        }

        public IEnumerable FindProductsBySupplierAndPrice(string supplier, decimal price)
        {
            if (!this.productsBySupplierAndPrice.ContainsKey(new Tuple<string, decimal>(supplier,price)))
            {
               return Enumerable.Empty<Product>();
            }

            return this.productsBySupplierAndPrice[new Tuple<string, decimal>(supplier, price)];
        }

        public IEnumerable FindProductsBySupplierAndPriceRange(string supplier, decimal start, decimal end)
        {
            if (!this.productsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                return Enumerable.Empty<Product>();
            }

            return this.productsBySupplierAndPriceRange[supplier].Range(start, true, end, true);
        }
    }
}
