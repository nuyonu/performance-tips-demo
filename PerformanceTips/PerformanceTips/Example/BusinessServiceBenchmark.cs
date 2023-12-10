using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace PerformanceTips.Example;

[BaselineColumn]
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net70)]
public class BusinessServiceBenchmark
{
    public List<Customer> customers;
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        customers = CustomersGenerator.GenerateCustomers(100_000);
    }
    
    [Benchmark(Baseline = true)]
    public void BaseMethod()
    {
        var businessService = new BusinessService(customers);

        var products = businessService.GetCustomerProductNames("Customer50000");
    }
    
    [Benchmark]
    public void OptimizedMethod1()
    {
        var businessService = new BusinessService(customers);

        var products = businessService.GetCustomerProductNamesOptimized1("Customer50000");
    }
    
    [Benchmark]
    public void OptimizedMethod2()
    {
        var businessService = new BusinessService(customers);

        var products = businessService.GetCustomerProductNamesOptimized2("Customer50000");
    }
}