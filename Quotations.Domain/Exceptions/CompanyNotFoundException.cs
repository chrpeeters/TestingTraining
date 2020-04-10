using System;

namespace Quotations.Domain.Exceptions
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