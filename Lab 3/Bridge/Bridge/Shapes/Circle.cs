using System;
namespace Bridge
{
    public class Circle : Shape
    {
        public Circle(IRenderingStrategy renderingStrategy) : base(renderingStrategy) { }

        public override void Draw()
        {
            Console.WriteLine("Drawing Circle");
            renderingStrategy.Render();
        }
    }
}

