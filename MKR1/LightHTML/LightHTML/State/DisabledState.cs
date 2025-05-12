using System;
namespace LightHTML.State
{
    public class DisabledState : IRenderState
    {
        public void ApplyState(LightElementNode element)
        {
            element.AddCssClass("disabled");
        }
    }
}

