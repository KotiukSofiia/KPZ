using System;
namespace Momento
{
    public class TextDocument
    {
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public TextDocument(string initialContent)
        {
            _content = initialContent;
        }

        public void Display()
        {
            Console.WriteLine("Current Content: " + _content);
        }

        public TextDocumentMemento CreateMemento()
        {
            return new TextDocumentMemento(_content);
        }

        public void Restore(TextDocumentMemento memento)
        {
            _content = memento.Content;
        }
    }

}

