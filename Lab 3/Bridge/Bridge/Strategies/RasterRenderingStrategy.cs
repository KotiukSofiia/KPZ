using System;
namespace Bridge
{
    public class RasterRenderingStrategy : IRenderingStrategy
    {
        public void Render()
        {
            Console.WriteLine("Rendering as raster graphics (pixels)");
        }
    }

}

