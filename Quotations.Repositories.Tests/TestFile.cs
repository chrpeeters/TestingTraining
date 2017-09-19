using System;
using System.IO;

namespace Quotations.Repositories.Tests
{
    public class TestFile
    {
        public string Path { get; }

        public TestFile(string path, string filename)
        {
            Path = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                path,
                filename);
        }
    }
}