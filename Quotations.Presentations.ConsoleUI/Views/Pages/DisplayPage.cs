using Quotations.Presentations.ConsoleUI.Readers;
using Quotations.Presentations.ConsoleUI.Writters;
using Quotations.Services;

namespace Quotations.Presentations.ConsoleUI.Views.Pages
{
    public class DisplayPage : IPage
    {
        private readonly IWritter writter;
        private readonly IReader reader;
        private readonly QuotationName quotationName;

        public DisplayPage(IWritter writter, IReader reader, object parameter)
        {
            this.writter = writter;
            this.reader = reader;
            quotationName = (QuotationName)parameter;
        }

        public void Display()
        {
            writter.WriteLine($"I Should probably do something here for : {quotationName}");
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
            writter.WriteLine("DISPLAY PAGE");
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
