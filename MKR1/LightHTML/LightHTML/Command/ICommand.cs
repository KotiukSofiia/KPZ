using System;
namespace LightHTML
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

}

