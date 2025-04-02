using System;
namespace Bridge
{
    public class Triangle : Shape
    {
        public Triangle(IRenderingStrategy renderingStrategy) : base(renderingStrategy) { }

        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle");
            renderingStrategy.Render();
        }
    }
}

