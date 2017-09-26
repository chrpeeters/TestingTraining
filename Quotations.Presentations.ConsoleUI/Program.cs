using Quotations.Presentations.ConsoleUI.Readers;
using Quotations.Presentations.ConsoleUI.Views;
using Quotations.Presentations.ConsoleUI.Writters;

namespace Quotations.Presentations.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Services
            IWritter writter = new Writter();
            IReader reader = new Reader();
            IPageFactory factory = new PageFactory(writter, reader);
            var page = Page.Home();

            while (page.PageName != PageName.Kill)
            {
                using (var pageInstance = factory.GetInstance(page))
                {
                    pageInstance.DisplayTitle();
                    pageInstance.Display();
                    pageInstance.DisplayMenu();
                    page = pageInstance.GetNextPage();
                }
                writter.Clean();
            }
        }
    }
}

