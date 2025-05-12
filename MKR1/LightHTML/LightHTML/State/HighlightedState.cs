using System;
namespace LightHTML.State
{
    public class HighlightedState : IRenderState
    {
        public void ApplyState(LightElementNode element)
        {
            element.AddCssClass("highlight");
        }
    }
}

