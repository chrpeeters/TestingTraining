using System;

namespace Quotations.Domain.Excpetions
{
    public class CompanyNotFoundException : Exception
    {
        public string NotFoundCompanyName { get; }

        public CompanyNotFoundException(string notFoundCompanyName)
        {
            NotFoundCompanyName = notFoundCompanyName;
        }
    }
}