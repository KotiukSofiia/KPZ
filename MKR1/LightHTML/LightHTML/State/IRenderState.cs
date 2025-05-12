using System;
namespace LightHTML.State
{
    public interface IRenderState
    {
        void ApplyState(LightElementNode element);
    }
}

