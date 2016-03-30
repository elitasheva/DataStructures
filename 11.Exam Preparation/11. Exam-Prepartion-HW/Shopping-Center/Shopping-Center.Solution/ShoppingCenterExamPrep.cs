using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class ShoppingCenterExamPrep
{
    private Dictionary<string, OrderedBag<Product>> productsByProducer =
        new Dictionary<string, OrderedBag<Product>>();

    private Dictionary<string, OrderedBag<Product>> productsByNameAndProducer =
        new Dictionary<string, OrderedBag<Product>>();

    private Dictionary<string, OrderedBag<Product>> productsByName =
        new Dictionary<string, OrderedBag<Product>>();

    private OrderedDictionary<decimal, OrderedBag<Product>> productsByPrice =
        new OrderedDictionary<decimal, OrderedBag<Product>>();

    public string AddProduct(string name, decimal price, string producer)
    {
        var newProduct = new Product()
        {
            Name = name,
            Price = price,
            Producer = producer
        };

        if (!this.productsByProducer.ContainsKey(producer))
        {
            this.productsByProducer[producer] = new OrderedBag<Product>();
        }
        this.productsByProducer[producer].Add(newProduct);

        var key = this.GetKey(name, producer);
        if (!this.productsByNameAndProducer.ContainsKey(key))
        {
            this.productsByNameAndProducer[key] = new OrderedBag<Product>();
        }
        this.productsByNameAndProducer[key].Add(newProduct);

        if (!this.productsByName.ContainsKey(name))
        {
            this.productsByName[name] = new OrderedBag<Product>();
        }
        this.productsByName[name].Add(newProduct);

        if (!this.productsByPrice.ContainsKey(price))
        {
             this.productsByPrice[price] = new OrderedBag<Product>();
        }
        this.productsByPrice[price].Add(newProduct);

        return "Product added";
    }

    private string GetKey(string name, string producer)
    {
        string key = name + producer;
        return key;
    }

    public string FindProductsByName(string name)
    {
        if (!this.productsByName.ContainsKey(name))
        {
            return "No products found";
        }

        var productsFound = this.productsByName[name];
        return PrintProducts(productsFound);
    }

    private string PrintProducts(IEnumerable<Product> products)
    {
        if (products.Any())
        {
            var sortedProducts = products.OrderBy(p => p);
            return string.Join(Environment.NewLine, sortedProducts);
        }

        return "No products found";
    }

    public string FindProductsByProducer(string producer)
    {
        if (!this.productsByProducer.ContainsKey(producer))
        {
            return "No products found";
        }

        var productsFound = this.productsByProducer[producer];
        return PrintProducts(productsFound);
    }

    public string FindProductsByPriceRange(
        decimal startPrice, decimal endPrice)
    {
        var productsFound = this.productsByPrice.Range(startPrice, true, endPrice, true).SelectMany(a => a.Value);
        return PrintProducts(productsFound);
    }

    public string DeleteProductsByProducer(string producer)
    {
        if (!this.productsByProducer.ContainsKey(producer))
        {
            return "No products found";
        }

        var productsForDelete = this.productsByProducer[producer];
        this.productsByProducer.Remove(producer);
        foreach (var product in productsForDelete)
        {
            this.productsByName[product.Name].Remove(product);
            this.productsByPrice[product.Price].Remove(product);
            var key = this.GetKey(product.Name, product.Producer);
            this.productsByNameAndProducer[key].Remove(product);
        }

        return string.Format("{0} products deleted", productsForDelete.Count);
    }

    public string DeleteProductsByNameAndProducer(
        string name, string producer)
    {
        var key = this.GetKey(name,producer);
        if (!this.productsByNameAndProducer.ContainsKey(key))
        {
            return "No products found";
        }

        var productsForDelete = this.productsByNameAndProducer[key];
        this.productsByNameAndProducer.Remove(key);
        foreach (var product in productsForDelete)
        {
            this.productsByName[product.Name].Remove(product);
            this.productsByProducer[product.Producer].Remove(product);
            this.productsByPrice[product.Price].Remove(product);
        }

        return string.Format("{0} products deleted", productsForDelete.Count);
    }

    public string ProcessCommand(string commandLine)
    {
        int spaceIndex = commandLine.IndexOf(' ');
        if (spaceIndex == -1)
        {
            return "Invalid command";
        }

        string command = commandLine.Substring(0, spaceIndex);
        string paramsStr = commandLine.Substring(spaceIndex + 1);
        string[] cmdParams = paramsStr.Split(';');
        switch (command)
        {
            case "AddProduct":
                return this.AddProduct(
                    cmdParams[0], decimal.Parse(cmdParams[1]), cmdParams[2]);
            case "DeleteProducts":
                if (cmdParams.Length == 1)
                    return this.DeleteProductsByProducer(
                        cmdParams[0]);
                else
                    return this.DeleteProductsByNameAndProducer(
                        cmdParams[0], cmdParams[1]);
            case "FindProductsByName":
                return this.FindProductsByName(cmdParams[0]);
            case "FindProductsByProducer":
                return this.FindProductsByProducer(cmdParams[0]);
            case "FindProductsByPriceRange":
                return this.FindProductsByPriceRange(
                    decimal.Parse(cmdParams[0]), decimal.Parse(cmdParams[1]));
            default:
                return "Invalid command";
        }
    }
}
