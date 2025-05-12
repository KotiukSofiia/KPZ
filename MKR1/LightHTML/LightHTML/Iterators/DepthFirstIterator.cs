using System;
using System.Collections.Generic;

namespace LightHTML
{
    public class DepthFirstIterator : ILightNodeIterator
    {
        public IEnumerable<LightNode> Traverse(LightNode root)
        {
            if (root == null) yield break;

            Stack<LightNode> stack = new Stack<LightNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;

                if (current is LightHTML.LightElementNode element)
                {
                    var children = element.GetChildren();
                    for (int i = children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(children[i]);
                    }
                }
            }
        }
    }
}

