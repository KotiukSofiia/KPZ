using System.Collections.Generic;

namespace Lab1.Models
{
    public class Warehouse
    {
        public List<Product> Products { get; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
