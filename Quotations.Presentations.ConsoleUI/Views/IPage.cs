using System;

namespace Quotations.Presentations.ConsoleUI.Views
{
    public interface IPage : IDisposable
    {
        void DisplayTitle();
        void Display();
        void DisplayMenu();
        Page GetNextPage();
    }
}
