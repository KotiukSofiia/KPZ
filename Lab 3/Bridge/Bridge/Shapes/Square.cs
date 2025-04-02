using System;
namespace Bridge
{
    public class Square : Shape
    {
        public Square(IRenderingStrategy renderingStrategy) : base(renderingStrategy) { }

        public override void Draw()
        {
            Console.WriteLine("Drawing Square");
            renderingStrategy.Render();
        }
    }
}

