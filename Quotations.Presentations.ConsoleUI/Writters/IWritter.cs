namespace Quotations.Presentations.ConsoleUI.Writters
{
    public interface IWritter
    {
        void Clean();
        void WriteLine(string line);
        void WriteBlankLine();
        void WriteDottedLine();
        void Write(string message);
    }
}
