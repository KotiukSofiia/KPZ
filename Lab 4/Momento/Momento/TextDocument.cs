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

        // Метод для виведення вмісту документа
        public void Display()
        {
            Console.WriteLine("Current Content: " + _content);
        }

        // Створює Memento, щоб зберегти поточний стан
        public TextDocumentMemento CreateMemento()
        {
            return new TextDocumentMemento(_content);
        }

        // Відновлення вмісту з Memento
        public void Restore(TextDocumentMemento memento)
        {
            _content = memento.Content;
        }
    }

}

