using System;
namespace LightHTML.Command
{
    public class AddElementCommand : ICommand
    {
        private LightElementNode parent;
        private LightNode child;

        public AddElementCommand(LightElementNode parent, LightNode child)
        {
            this.parent = parent;
            this.child = child;
        }

        public void Execute()
        {
            parent.AddChild(child);
        }

        public void Undo()
        {
            parent.GetChildren().Remove(child);
        }
    }
}

