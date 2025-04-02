using System;
using Proxy;

public class SmartTextChecker : SmartTextReader
{
    public SmartTextChecker(string filePath) : base(filePath) { }

    public new char[][] ReadFile()
    {
        Console.WriteLine("Opening file: " + filePath);

        char[][] content = base.ReadFile();

        Console.WriteLine("File successfully opened.");
        Console.WriteLine("Reading file...");

        int lineCount = content.Length;
        int charCount = 0;
        foreach (var line in content)
        {
            charCount += line.Length;
        }

        Console.WriteLine($"Total lines: {lineCount}, Total characters: {charCount}");

        Console.WriteLine("File reading completed.");

        return content;
    }
}
