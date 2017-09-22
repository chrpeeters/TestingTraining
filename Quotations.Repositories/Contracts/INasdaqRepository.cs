using System.Collections.Generic;
using Quotations.Domain;

namespace Quotations.Repositories.Contracts
{
    public interface INasdaqRepository
    {
        IEnumerable<Quotation> ReadQuotations(string fullPath);
    }
}