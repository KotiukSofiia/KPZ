using System;
using Lab1.Models;

namespace Lab1.Services
{
    public class WarehouseService
    {
        public void ShowInventory(Warehouse warehouse)
        {
            Console.WriteLine("\n=== Список товарів ===");
            foreach (var product in warehouse.Products)
            {
                Console.WriteLine($"{product.Name} ({product.Category}) - {product.Price}");
            }
        }
    }
}
