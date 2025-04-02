using System;
using System.Text.RegularExpressions;
using Proxy;

public class SmartTextReaderLocker : SmartTextReader
{
    private Regex filePattern;

    public SmartTextReaderLocker(string filePath, string pattern) : base(filePath)
    {
        filePattern = new Regex(pattern);
    }

    public new char[][] ReadFile()
    {
        if (filePattern.IsMatch(filePath))
        {
            Console.WriteLine("Access denied!");
            return null; 
        }

        return base.ReadFile();
    }
}
