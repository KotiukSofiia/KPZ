using System;

namespace LightHTML
{
    public class LightTextNode : LightNode
    {
        private string text;

        public LightTextNode(string text)
        {
            this.text = text;
        }

        public override string GetOuterHtml(int indentLevel = 0)
        {
            return new string(' ', indentLevel * 2) + text;
        }

        public override string GetInnerHtml(int indentLevel = 0)
        {
            return text;
        }
    }
}
