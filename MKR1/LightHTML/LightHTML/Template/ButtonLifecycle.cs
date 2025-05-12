using System;

namespace LightHTML.Template
{
    public class ButtonLifecycle : ElementLifecycleTemplate
    {
        protected override void OnCreated()
        {
            Console.WriteLine("[Button] Created");
        }

        protected override void OnClassListApplied(List<string> classes)
        {
            Console.WriteLine("[Button] Classes applied: " + string.Join(", ", classes));
        }

        protected override void OnStylesApplied()
        {
            Console.WriteLine("[Button] Styles applied");
        }

        protected override void OnInserted()
        {
            Console.WriteLine("[Button] Inserted into DOM");
        }

        protected override void OnTextRendered(string textContent)
        {
            Console.WriteLine("[Button] Text rendered: " + textContent);
        }

        protected override void OnRemoved()
        {
            Console.WriteLine("[Button] Removed from DOM");
        }
    }

}
