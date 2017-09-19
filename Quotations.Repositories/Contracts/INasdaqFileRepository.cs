using System.Collections.Generic;
using Quotations.Domain;

namespace Quotations.Repositories.Contracts
{
    public interface INasdaqFileRepository
    {
        IEnumerable<Quotation> ReadQuotations(string fullPath);
    }
}