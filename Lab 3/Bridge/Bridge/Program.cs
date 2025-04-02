using System;
using Bridge;

class Program
{
    static void Main()
    {
        IRenderingStrategy vectorStrategy = new VectorRenderingStrategy();
        IRenderingStrategy rasterStrategy = new RasterRenderingStrategy();

        Shape circle = new Circle(vectorStrategy);
        Shape square = new Square(rasterStrategy);
        Shape triangle = new Triangle(vectorStrategy);

        circle.Draw();
        square.Draw();  
        triangle.Draw();  
        Console.ReadLine();
    }
}
