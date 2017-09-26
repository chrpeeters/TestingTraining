using Quotations.Presentations.ConsoleUI.Writters;

namespace Quotations.Presentations.ConsoleUI.Views.Pages
{
    public class ExitPage : IPage
    {
        private readonly IWritter writter;

        public ExitPage(IWritter writter)
        {
            this.writter = writter;
        }

        public void Display()
        {
            writter.WriteLine("bye bye");
        }

        public void DisplayMenu()
        {
        }

        public void DisplayTitle()
        {
            writter.WriteLine("EXIT PAGE");
            writter.WriteDottedLine();
        }

        public void Dispose()
        {
        }

        public Page GetNextPage()
        {
            return Page.Kill();
        }
    }
}
