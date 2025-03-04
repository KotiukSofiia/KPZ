using Lab1.Models;

namespace Lab1.Services
{
    public class ProductService
    {
        public void ReducePrice(Product product, int amount)
        {
            int newWholePart = product.Price.WholePart - amount;
            if (newWholePart < 0) newWholePart = 0;

            Money newPrice = new Money(newWholePart, product.Price.Cents, product.Price.Currency);
            product.SetPrice(newPrice);
        }
    }
}
