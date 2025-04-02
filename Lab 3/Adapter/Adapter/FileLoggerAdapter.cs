using System;
namespace Adapter
{
    public class FileLoggerAdapter : Logger
    {
        private FileWriter _fileWriter;

        public FileLoggerAdapter(FileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public new void Log(string message)
        {
            _fileWriter.WriteLine($"Log: {message}");
        }

        public new void Error(string message)
        {
            _fileWriter.WriteLine($"Error: {message}");
        }

        public new void Warn(string message)
        {
            _fileWriter.WriteLine($"Warn: {message}");
        }
    }

}

