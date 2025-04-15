using System;

namespace LightHTML
{
    public class Image : LightElementNode
    {
        private IImageLoadStrategy _loadStrategy;
        private string _src;

        public Image(string href, IImageLoadStrategy loadStrategy)
            : base("img", "inline", true)
        {
            this._loadStrategy = loadStrategy;
            this._src = href;
            this.AddCssClass("image-element");
            this.AddChild(new LightTextNode("Image"));
            LoadImage(href);
        }

        public void LoadImage(string href)
        {
            _loadStrategy.LoadImage(href); 
        }

        public override string GetOuterHtml(int indentLevel = 0)
        {
            string indent = new string(' ', indentLevel * 2);
            string outerHtml = $"{indent}<{tagName}";

            if (cssClasses.Count > 0)
            {
                outerHtml += " class=\"" + string.Join(" ", cssClasses) + "\"";
            }

            outerHtml += $" src=\"{_src}\"";

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
    }
}
