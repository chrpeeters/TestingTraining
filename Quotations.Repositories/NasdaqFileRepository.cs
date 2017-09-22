using System.Collections.Generic;
using Quotations.Domain;
using Quotations.Repositories.Contracts;

namespace Quotations.Repositories
{
    public class NasdaqFileRepository : INasdaqRepository
    {
        public IEnumerable<Quotation> ReadQuotations(string fullPath)
        {
            throw new System.NotImplementedException();
        }
    }
}