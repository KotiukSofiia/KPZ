using System;
namespace Momento
{
    public class TextDocumentMemento
    {
        public string Content { get; private set; }

        public TextDocumentMemento(string content)
        {
            Content = content;
        }
    }

}

