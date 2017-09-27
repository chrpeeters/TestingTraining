using Quotations.Repositories.Contracts;
using System.Collections.Generic;
using Quotations.Domain;

namespace Quotations.Repositories
{
    public class NikkeiHardcordedRepository : IQuotationRepository
    {
        public IEnumerable<Quotation> ReadQuotations()
        {
            return new List<Quotation>
            {
                new Quotation("Ingenico japan", 87.12m, "EUR"),
                new Quotation("Toyota", 12.8m, "YEN"),
                new Quotation("Sony", 456.5m, "YEN"),
                new Quotation("Nissan", 41, "YEN"),
            };
        }
    }
}
