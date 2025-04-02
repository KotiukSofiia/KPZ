using System;
using System.IO;

namespace Proxy
{
    public class SmartTextReader
    {
        protected string filePath; 

        public SmartTextReader(string filePath)
        {
            this.filePath = filePath;
        }

        public char[][] ReadFile()
        {
            var lines = File.ReadAllLines(filePath);
            char[][] result = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].ToCharArray();  
            }

            return result;
        }
    }

}

