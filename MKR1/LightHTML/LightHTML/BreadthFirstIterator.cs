using System;
using System.Collections.Generic;

namespace LightHTML
{
    public class BreadthFirstIterator : ILightNodeIterator
    {
        public IEnumerable<LightNode> Traverse(LightNode root)
        {
            if (root == null) yield break;

            Queue<LightNode> queue = new Queue<LightNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current;

                if (current is LightHTML.LightElementNode element)
                {
                    var children = element.GetChildren();
                    foreach (var child in children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }
}

