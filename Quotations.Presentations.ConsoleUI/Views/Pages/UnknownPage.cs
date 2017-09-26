using Quotations.Presentations.ConsoleUI.Readers;
using Quotations.Presentations.ConsoleUI.Writters;

namespace Quotations.Presentations.ConsoleUI.Views.Pages
{
    public class UnknownPage : IPage
    {
        private readonly IWritter writter;
        private readonly IReader reader;

        public UnknownPage(IWritter writter, IReader reader)
        {
            this.writter = writter;
            this.reader = reader;
        }

        public void Display()
        {
            writter.WriteLine("Page unknown !!!");
        }

        public void DisplayMenu()
        {
            writter.WriteDottedLine();
            writter.WriteLine("MENU");
            writter.WriteLine("[1] home");
            writter.WriteLine("[9] exit");
        }
        public void DisplayTitle()
        {
            writter.WriteLine("UNKNOWN PAGE");
            writter.WriteDottedLine();
        }

        public void Dispose()
        {

        }

        public Page GetNextPage()
        {
            writter.Write("\nYour choice : ");
            var action = reader.ReadSingleInt();
            writter.WriteBlankLine();

            if (action == 9)
                return Page.Exit();

            if (action == 1)
                return Page.Home();

            return Page.Unkown();
        }
    }
}
