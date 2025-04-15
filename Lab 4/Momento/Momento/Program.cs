using Momento;

class Program
{
    static void Main(string[] args)
    {
        // Створення початкового документа
        TextDocument doc = new TextDocument("Initial Content");

        // Створення редактора
        TextEditor editor = new TextEditor(doc);

        // Виведення початкового документа
        doc.Display();

        // Зміна тексту
        editor.Edit("First Edit");
        doc.Display();

        // Скасування змін
        editor.Undo();
        doc.Display();

        // Знову змінимо текст
        editor.Edit("Second Edit");
        doc.Display();

        // Скасування змін
        editor.Undo();
        doc.Display();

        // Завершення
        Console.ReadLine();
    }
}
