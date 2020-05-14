using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionConditionallyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<AustraliaTax>();
            collection.AddScoped<EuropeTax>();
            collection.AddScoped<Func<Location, ITax>>(
                ServiceProvider => loc =>
                {
                    switch (loc)
                    {
                        case Location.Australia: return ServiceProvider.GetService<AustraliaTax>();
                        case Location.Europe: return ServiceProvider.GetService<EuropeTax>();
                        default: return null;
                    }

                }
            );
            collection.AddScoped<TaxCalculator>();

            var provider = collection.BuildServiceProvider();
            var taxCalculator = provider.GetService<TaxCalculator>();

            var location = Location.Europe;
            var totalTax = taxCalculator.CalculateTax(location, 200);

            Console.WriteLine($"Location- {location}, TotalTax-{totalTax}");
            Console.WriteLine("Press any key...!");
            Console.ReadKey();
        }
    }
}
