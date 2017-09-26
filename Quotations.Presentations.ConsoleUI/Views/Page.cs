namespace Quotations.Presentations.ConsoleUI.Views
{
    public class Page
    {
        public PageName PageName { get; }
        public object Parameter { get; }

        private Page(PageName pageName)
        {
            PageName = pageName;
        }
        private Page(PageName pageName, object parameter)
        {
            PageName = pageName;
            Parameter = parameter;
        }

        public static Page Unkown() => new Page(PageName.Unkown);
        public static Page Display(object parameter) => new Page(PageName.Display, parameter);
        public static Page Exit() => new Page(PageName.Exit);
        public static Page Home() => new Page(PageName.Home);
        public static Page Kill() => new Page(PageName.Kill);
    }

    public enum PageName
    {
        Unkown,
        Display,
        Exit,
        Home,
        Kill
    }
}
