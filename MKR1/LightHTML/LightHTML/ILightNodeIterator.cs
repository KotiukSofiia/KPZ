using System;
namespace LightHTML
{

        public interface ILightNodeIterator
        {
            IEnumerable<LightNode> Traverse(LightNode root);
        }
}