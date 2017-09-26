using Quotations.Presentations.ConsoleUI.Readers;
using Quotations.Presentations.ConsoleUI.Views.Pages;
using Quotations.Presentations.ConsoleUI.Writters;

namespace Quotations.Presentations.ConsoleUI.Views
{
    public class PageFactory : IPageFactory
    {
        private readonly IWritter writter;
        private readonly IReader reader;

        public PageFactory(IWritter writter, IReader reader)
        {
            this.writter = writter;
            this.reader = reader;
        }
        public IPage GetInstance(Page page)
        {
            switch (page.PageName)
            {
                case PageName.Display:
                    return new DisplayPage(writter, reader, page.Parameter);
                case PageName.Exit:
                    return new ExitPage(writter);
                case PageName.Home:
                    return new HomePage(writter, reader);
                default:
                    return new UnknownPage(writter, reader);
            }
        }
    }
}
