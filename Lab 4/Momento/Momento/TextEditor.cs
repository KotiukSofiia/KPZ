using System;
namespace Momento
{
    public class TextEditor
    {
        private TextDocument _document;
        private Stack<TextDocumentMemento> _history = new Stack<TextDocumentMemento>();

        public TextEditor(TextDocument document)
        {
            _document = document;
        }

        public void Edit(string newContent)
        {
            _history.Push(_document.CreateMemento());
            _document.Content = newContent;
            Console.WriteLine("Edited Content: " + _document.Content);
        }

        public void Undo()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("No history to undo.");
                return;
            }

            var memento = _history.Pop();
            _document.Restore(memento);
            Console.WriteLine("Undo: " + _document.Content);
        }
    }

}

