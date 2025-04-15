using Momento;

class Program
{
    static void Main(string[] args)
    {
        TextDocument doc = new TextDocument("Initial Content");

        TextEditor editor = new TextEditor(doc);

        doc.Display();

        editor.Edit("First Edit");
        doc.Display();

        editor.Undo();
        doc.Display();

        editor.Edit("Second Edit");
        doc.Display();

        editor.Undo();
        doc.Display();

        Console.ReadLine();
    }
}
