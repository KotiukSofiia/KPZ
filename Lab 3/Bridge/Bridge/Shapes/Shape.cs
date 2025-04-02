using System;
namespace Bridge
{
    public abstract class Shape
    {
        protected IRenderingStrategy renderingStrategy;

        public Shape(IRenderingStrategy renderingStrategy)
        {
            this.renderingStrategy = renderingStrategy;
        }

        public abstract void Draw();
    }
}

