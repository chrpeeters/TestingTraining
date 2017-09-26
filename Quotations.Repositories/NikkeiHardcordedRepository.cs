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
             new Quotation("ingenico japan", 87, "EUR"),
             new Quotation("Toyota", 1, "Yen"),
             new Quotation("Sony", 45654, "Yen"),
             new Quotation("Nissan", 41, "Yen"),
          };
        }
    }
}
