using System;

namespace Lab1.Models
{
    public class Product
    {
        public string Name { get; }
        public string Category { get; }
        public Money Price { get; private set; }

        public Product(string name, string category, Money price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        public void SetPrice(Money newPrice)
        {
            Price = newPrice;
        }
    }
}

