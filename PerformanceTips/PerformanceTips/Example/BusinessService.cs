using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceTips.Example;

public class BusinessService
{
    private List<Customer> customers;

    public BusinessService(List<Customer> customers)
    {
        this.customers = customers;
    }

    public List<string> GetCustomerProductNames(string customerName)
    {
        // Obținem o listă de produse pentru un anumit client
        var products = customers
            .Where(c => c.Name.ToUpper() == customerName.ToUpper())
            .SelectMany(c => c.Orders.Select(o => o.Product))
            .ToList();

        // Sortăm produsele alfabetic
        var sortedProducts = products.OrderBy(p => p).ToList();

        // Eliminăm duplicatatele
        var uniqueProducts = sortedProducts.Distinct().ToList();

        return uniqueProducts;
    }
    
    public List<string> GetCustomerProductNamesOptimized1(string customerName)
    {
        // Obținem o listă de produse pentru un anumit client
        var products = new List<string>();

        foreach (var customer in customers)
        {
            if (customer.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase))
            {
                foreach (var order in customer.Orders)
                {
                    products.Add(order.Product);
                }
            }
        }

        // Sortăm produsele alfabetic
        products.Sort();

        // Eliminăm duplicatatele
        var uniqueProducts = new List<string>();
        string previousProduct = null;

        foreach (var product in products)
        {
            if (product != previousProduct)
            {
                uniqueProducts.Add(product);
                previousProduct = product;
            }
        }

        return uniqueProducts;
    }
    
    public List<string> GetCustomerProductNamesOptimized2(string customerName)
    {
        // Obținem o listă de produse pentru un anumit client
        var products = new List<string>();

        foreach (var customer in customers)
        {
            if (customer.Name == customerName)
            {
                foreach (var order in customer.Orders)
                {
                    products.Add(order.Product);
                }
            }
        }

        // Utilizăm HashSet pentru eliminarea duplicatelor
        var uniqueProductsSet = new HashSet<string>(products);
        var uniqueProducts = new List<string>(uniqueProductsSet);

        // Sortăm produsele alfabetic
        uniqueProducts.Sort();

        return uniqueProducts;
    }
}