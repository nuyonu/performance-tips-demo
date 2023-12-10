using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceTips.Example;

public class CustomersGenerator
{
    public static List<Customer> GenerateCustomers(int count)
    {
        var random = new Random();
        
        return Enumerable.Range(1, count)
            .Select(i => new Customer
            {
                Id = i,
                Name = $"Customer{i}",
                Orders = Enumerable.Range(1, 10)
                    .Select(j => new Order
                    {
                        OrderId = i * 100 + j,
                        Product = $"Product{j}",
                        Quantity = i % 5 + 1
                    })
                    .ToList()
            })
            .ToList();
    }
}
