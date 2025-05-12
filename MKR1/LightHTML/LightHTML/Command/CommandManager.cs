using System;
namespace LightHTML.Command
{
    public class CommandManager
    {
        private Stack<ICommand> history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            history.Push(command);
        }

        public void UndoLast()
        {
            if (history.Count > 0)
            {
                var lastCommand = history.Pop();
                lastCommand.Undo();
            }
        }
    }
}

