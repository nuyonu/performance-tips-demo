using PerformanceTips.Example;

var businessService = new BusinessService(CustomersGenerator.GenerateCustomers(10));

foreach (var productName in businessService.GetCustomerProductNames("customer5"))
{
    Console.WriteLine(productName);
}