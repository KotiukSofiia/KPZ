using System;

namespace LightHTML.Visitor
{
    public class LightNodeCounterVisitor : ILightNodeVisitor
    {
        public int ElementCount { get; private set; } = 0;
        public int TextNodeCount { get; private set; } = 0;

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
        }

        public void VisitText(LightTextNode text)
        {
            TextNodeCount++;
        }
    }
}
