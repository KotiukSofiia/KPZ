using System;
using System.Collections.Generic;
using LightHTML.State;
using LightHTML.Visitor;

namespace LightHTML
{
    public class LightElementNode : LightNode
    {
        private string tagName;
        private string displayType;
        private bool isSelfClosing;
        private List<string> cssClasses;
        private List<LightNode> children;

        public LightElementNode(string tagName, string displayType = "block", bool isSelfClosing = false)
        {
            this.tagName = tagName;
            this.displayType = displayType;
            this.isSelfClosing = isSelfClosing;
            this.cssClasses = new List<string>();
            this.children = new List<LightNode>();
        }

        public void AddChild(LightNode child)
        {
            children.Add(child);
        }

        public void AddCssClass(string cssClass)
        {
            cssClasses.Add(cssClass);
        }

        public List<LightNode> GetChildren()
        {
            return children;
        }

        public void SetRenderState(IRenderState state)
        {
            state.ApplyState(this);
        }

        // LightElementNode.cs
        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.VisitElement(this);

            foreach (var child in GetChildren()) // або: children
            {
                child.Accept(visitor);
            }
        }


        public override string GetOuterHtml(int indentLevel = 0)
        {
            string indent = new string(' ', indentLevel * 2);
            string outerHtml = $"{indent}<{tagName}";

            if (cssClasses.Count > 0)
            {
                outerHtml += " class=\"" + string.Join(" ", cssClasses) + "\"";
            }

            if (isSelfClosing)
            {
                outerHtml += " />";
            }
            else
            {
                outerHtml += ">\n";
                outerHtml += GetInnerHtml(indentLevel + 1);
                outerHtml += $"{indent}</{tagName}>\n";
            }

            return outerHtml;
        }

        public override string GetInnerHtml(int indentLevel = 0)
        {
            string indent = new string(' ', indentLevel * 2);
            string innerHtml = "";

            foreach (var child in children)
            {
                innerHtml += child.GetOuterHtml(indentLevel);
            }

            return innerHtml;
        }
    }
}
