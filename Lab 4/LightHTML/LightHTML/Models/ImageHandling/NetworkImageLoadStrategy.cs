using System;

namespace LightHTML
{
    public class NetworkImageLoadStrategy : IImageLoadStrategy
    {
        public void LoadImage(string href)
        {
            // Логіка для завантаження зображення з мережі
            Console.WriteLine($"Loading image from network: {href}");
        }
    }
}
