using System;
using System.Collections.Generic;
using System.Linq;

public class ShoppingCenterSlow
{
    private const string PRODUCT_ADDED = "Product added";
    private const string X_PRODUCTS_DELETED = " products deleted";
    private const string NO_PRODUCTS_FOUND = "No products found";
    private const string INCORRECT_COMMAND = "Incorrect command";

    private readonly List<Product> products = new List<Product>();

    private string AddProduct(string name, string price, string producer)
    {
        var newProduct = new Product()
        {
            Name = name,
            Price = decimal.Parse(price),
            Producer = producer
        };

        this.products.Add(newProduct);

        return PRODUCT_ADDED;
    }

    private string FindProductsByName(string name)
    {
        var productsFound = this.products.Where(p => p.Name == name).OrderBy(p => p);

        return PrintProducts(productsFound);
    }

    private string FindProductsByProducer(string producer)
    {
        var productsFound = this.products.Where(p => p.Producer == producer).OrderBy(p => p);

        return PrintProducts(productsFound);
    }

    private string FindProductsByPriceRange(string from, string to)
    {
        var startRange = decimal.Parse(from);
        var endRange = decimal.Parse(to);
        var productsFound = this.products.Where(p => p.Price >= startRange && p.Price <= endRange).OrderBy(p => p);

        return PrintProducts(productsFound);
    }

    private string PrintProducts(IEnumerable<Product> products)
    {
        if (products.Any())
        {
            return string.Join(Environment.NewLine, products);
        }

        return NO_PRODUCTS_FOUND;
    }

    private string DeleteProductsByNameAndProducer(string name, string producer)
    {
        var foundProducts = this.products.RemoveAll(p => p.Name == name && p.Producer == producer);
        if (foundProducts == 0)
        {
            return NO_PRODUCTS_FOUND;
        }
         
        return string.Format("{0}{1}", foundProducts, X_PRODUCTS_DELETED);
    }

    private string DeleteProductsByProducer(string producer)
    {
        var foundProducts = this.products.RemoveAll(p => p.Producer == producer);
        if (foundProducts == 0)
        {
            return NO_PRODUCTS_FOUND;
        }

        return string.Format("{0}{1}", foundProducts, X_PRODUCTS_DELETED);
    }

    public string ProcessCommand(string command)
    {
        int indexOfFirstSpace = command.IndexOf(' ');
        string method = command.Substring(0, indexOfFirstSpace);
        string parameterValues = command.Substring(indexOfFirstSpace + 1);
        string[] parameters = parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        switch (method)
        {
            case "AddProduct":
                return AddProduct(parameters[0], parameters[1], parameters[2]);
            case "DeleteProducts":
                if (parameters.Length == 1)
                {
                    return DeleteProductsByProducer(parameters[0]);
                }
                else
                {
                    return DeleteProductsByNameAndProducer(parameters[0], parameters[1]);
                }
            case "FindProductsByName":
                return FindProductsByName(parameters[0]);
            case "FindProductsByPriceRange":
                return FindProductsByPriceRange(parameters[0], parameters[1]);
            case "FindProductsByProducer":
                return FindProductsByProducer(parameters[0]);
            default:
                return INCORRECT_COMMAND;
        }
    }
}
