using System;
using System.Collections.Generic;
using LightHTML.Visitor;

namespace LightHTML
{
    public abstract class LightNode
    {
        public abstract string GetOuterHtml(int indentLevel = 0);
        public abstract string GetInnerHtml(int indentLevel = 0);
        public abstract void Accept(ILightNodeVisitor visitor);
    }
}
