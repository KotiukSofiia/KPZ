using System;
using Lab1.Models;
using Lab1.Services;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Тестування функціональності ===");

            var productService = new ProductService();
            var warehouseService = new WarehouseService();
            var reportingService = new Reporting();

            var warehouse = new Warehouse();

            var apple = new Product("Яблуко", "Фрукти", new Money(10, 50, "UAH"));
            var bread = new Product("Хліб", "Випічка", new Money(20, 75, "UAH"));
            var milk = new Product("Молоко", "Молочні продукти", new Money(30, 99, "UAH"));

            
            warehouse.AddProduct(apple);
            warehouse.AddProduct(bread);
            warehouse.AddProduct(milk);

            warehouseService.ShowInventory(warehouse);
            Console.WriteLine("\n=== Список товарів після зниження ціни ===");
            productService.ReducePrice(apple, 2);
            productService.ReducePrice(bread, 5);
            productService.ReducePrice(milk, 8);

            warehouseService.ShowInventory(warehouse);

            reportingService.GenerateReport(warehouse);

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
