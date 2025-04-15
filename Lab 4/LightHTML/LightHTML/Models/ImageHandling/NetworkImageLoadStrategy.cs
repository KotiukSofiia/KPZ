using System;

namespace LightHTML
{
    public class NetworkImageLoadStrategy : IImageLoadStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Loading image from network: {href}");
        }
    }
}
