using System;
using System.Collections.Generic;

namespace LightHTML
{
    public abstract class LightNode
    {
        public abstract string GetOuterHtml(int indentLevel = 0);
        public abstract string GetInnerHtml(int indentLevel = 0);
    }
}
