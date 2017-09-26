using System.Collections.Generic;
using Quotations.Domain;

namespace Quotations.Repositories.Contracts
{
    public interface IQuotationRepository
    {
        IEnumerable<Quotation> ReadQuotations();
    }
}