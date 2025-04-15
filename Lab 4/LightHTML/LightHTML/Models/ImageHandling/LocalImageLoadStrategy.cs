using System;

namespace LightHTML
{
    public class LocalImageLoadStrategy : IImageLoadStrategy
    {
        public void LoadImage(string href)
        {
            Console.WriteLine($"Loading image from local file system: {href}");
        }
    }
}
