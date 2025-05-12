using System.Collections.Generic;

namespace LightHTML
{
    public class HTMLNodeFactory
    {
        private Dictionary<string, LightElementNode> elementNodes = new Dictionary<string, LightElementNode>();

        public LightElementNode GetNode(string tagName)
        {
            if (!elementNodes.ContainsKey(tagName))
            {
                elementNodes[tagName] = new LightElementNode(tagName);
            }

            return elementNodes[tagName];
        }

        public int GetCachedNodeCount()
        {
            return elementNodes.Count;
        }
    }
}
