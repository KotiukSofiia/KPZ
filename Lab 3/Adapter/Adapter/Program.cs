using Adapter;

class Program
{
    static void Main(string[] args)
    {
        Logger consoleLogger = new Logger();
        consoleLogger.Log("This is a log message.");
        consoleLogger.Error("This is an error message.");
        consoleLogger.Warn("This is a warning message.");

        FileWriter fileWriter = new FileWriter("log.txt");
        FileLoggerAdapter fileLogger = new FileLoggerAdapter(fileWriter);

        fileLogger.Log("This is a log message written to file.");
        fileLogger.Error("This is an error message written to file.");
        fileLogger.Warn("This is a warning message written to file.");

        Console.WriteLine("\nMessages have been written to the file.");
        string fileContent = File.ReadAllText("log.txt");
        Console.WriteLine("\nContents of the log file:");
        Console.WriteLine(fileContent);

        Console.ReadLine(); 
    }

}
