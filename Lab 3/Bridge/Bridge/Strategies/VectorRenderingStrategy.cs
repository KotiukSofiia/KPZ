using System;
namespace Bridge
{
    public class VectorRenderingStrategy : IRenderingStrategy
    {
        public void Render()
        {
            Console.WriteLine("Rendering as vector graphics");
        }
    }
}

