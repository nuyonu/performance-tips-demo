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
}