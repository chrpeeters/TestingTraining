using System;

namespace Quotations.Presentations.ConsoleUI.Writters
{
    public class Writter : IWritter
    {
        public void Clean()
        {
            Console.Clear();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteBlankLine()
        {
            Console.WriteLine("");
        }

        public void WriteDottedLine()
        {
            Console.WriteLine("\n-----------------------------\n");
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
