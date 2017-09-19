using System.Collections.Generic;
using Quotations.Domain;
using Quotations.Repositories.Contracts;

namespace Quotations.Repositories
{
    public class NasdaqFileRepository : INasdaqFileRepository
    {
        public IEnumerable<Quotation> ReadQuotations()
        {
            throw new System.NotImplementedException();
        }
    }
}