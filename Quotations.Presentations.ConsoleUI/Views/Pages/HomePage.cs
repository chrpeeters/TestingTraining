using Quotations.Presentations.ConsoleUI.Readers;
using Quotations.Presentations.ConsoleUI.Writters;
using Quotations.Services;

namespace Quotations.Presentations.ConsoleUI.Views.Pages
{
    public class HomePage : IPage
    {
        private readonly IWritter writter;
        private readonly IReader reader;

        public HomePage(IWritter writter, IReader reader)
        {
            this.writter = writter;
            this.reader = reader;
        }

        public void Display()
        {
            writter.WriteLine("Welcome in the best world trade center");
        }

        public void DisplayMenu()
        {
            writter.WriteDottedLine();
            writter.WriteLine("MENU");
            writter.WriteLine("[1] display the nasdaq values");
            writter.WriteLine("[2] display the bel20 values");
            writter.WriteLine("[3] display the nikkei values");
            writter.WriteLine("[9] exit");
        }

        public void DisplayTitle()
        {
            writter.WriteLine("HOME PAGE");
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

            if (action >= 1 && action <= 3)
            {
                return Page.Display((QuotationName)action);
            }

            return Page.Unkown();
        }
    }
}
