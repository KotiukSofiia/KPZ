using System;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "test.txt";
        System.IO.File.WriteAllLines(filePath, new string[] {
            "first line.",
            "second line.",
            "third line."
        });

        SmartTextChecker checker = new SmartTextChecker(filePath);
        var content = checker.ReadFile(); 

        SmartTextReaderLocker locker = new SmartTextReaderLocker(filePath, ".*forbidden.*");  
        locker.ReadFile();  

        locker = new SmartTextReaderLocker(filePath, "test.txt");
        locker.ReadFile();  
        Console.ReadLine();
    }
}
