using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceTips.Example;

public class CustomersGenerator
{
    private static Random random = new();
    
    public static List<Customer> GenerateCustomers(int count)
    {
        return Enumerable.Range(1, count)
            .Select(i => new Customer
            {
                Id = i,
                Name = $"Customer{i}",
                Orders = Enumerable.Range(1, 10)
                    .Select(j => new Order
                    {
                        OrderId = i * 100 + j,
                        Product = $"Product{RandomString(5, 2)}",
                        Quantity = i % 5 + 1
                    })
                    .ToList()
            })
            .ToList();
    }
    
    public static string RandomString(int length, int mode = 1)
    {
        string chars = mode == 1 ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" : "0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
