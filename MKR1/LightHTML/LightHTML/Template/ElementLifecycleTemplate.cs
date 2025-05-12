using System;

namespace LightHTML.Template
{
    public abstract class ElementLifecycleTemplate
    {
        public void RenderElement(string tagName, string textContent, List<string> classes)
        {
            OnCreated();
            OnClassListApplied(classes);
            OnStylesApplied();
            OnInserted();
            OnTextRendered(textContent);
            OnRemoved();
        }

        protected abstract void OnCreated();
        protected abstract void OnClassListApplied(List<string> classes);
        protected abstract void OnStylesApplied();
        protected abstract void OnInserted();
        protected abstract void OnTextRendered(string textContent);
        protected abstract void OnRemoved();
    }

}
