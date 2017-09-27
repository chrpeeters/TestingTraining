using Quotations.Repositories.Contracts;
using System;
using System.Collections.Generic;
using Quotations.Domain;

namespace Quotations.Repositories
{
    public class Bel20FakeApiRepository : IQuotationRepository
    {
        private readonly Uri serviceUrl;

        public Bel20FakeApiRepository(Uri serviceUrl)
        {
            this.serviceUrl = serviceUrl;
        }

        public IEnumerable<Quotation> ReadQuotations()
        {
            return new List<Quotation>
            {
                new Quotation("Ingenico Belgium", 102.12m, "EUR"),
                new Quotation("Microsoft Belgium", 89.8m, "EUR"),
                new Quotation("Delhaize", 76.5m, "EUR"),
                new Quotation("Bruxelles Air line", 54.61m, "EUR"),
                new Quotation("Uncle Sam", 504.61m, "USD"),
                new Quotation("Papple", 504.61m, "USD"),
            };
        }
    }
}
