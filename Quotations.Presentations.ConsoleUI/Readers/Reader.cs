using System;

namespace Quotations.Presentations.ConsoleUI.Readers
{
    public class Reader : IReader
    {
        public int ReadSingleInt()
        {
            var key = Console.ReadKey();
            var keyChar = key.KeyChar;
            int.TryParse(keyChar.ToString(), out int value);
            return value;
        }
    }
}
