using System;

namespace LightHTML
{
    public class LocalImageLoadStrategy : IImageLoadStrategy
    {
        public void LoadImage(string href)
        {
            // Логіка для завантаження зображення з локальної файлової системи
            Console.WriteLine($"Loading image from local file system: {href}");
        }
    }
}
