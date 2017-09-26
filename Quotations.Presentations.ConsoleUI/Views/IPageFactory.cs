namespace Quotations.Presentations.ConsoleUI.Views
{
    public interface IPageFactory
    {
        IPage GetInstance(Page page);
    }
}