using System;
using Lab1.Models;

namespace Lab1.Services
{
    public class Reporting
    {
        public void GenerateReport(Warehouse warehouse)
        {
            Console.WriteLine("\n=== Звіт по складу ===");
            foreach (var product in warehouse.Products)
            {
                Console.WriteLine($"{product.Name} ({product.Category}) - {product.Price}");
            }
        }
    }
}
