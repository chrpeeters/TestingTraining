using System.Collections.Generic;
using Quotations.Domain;
using Quotations.Repositories.Contracts;
using Quotations.Services.Contracts;

namespace Quotations.Services
{
    public class QuotationService: IQuotationService
    {
        public QuotationService(INasdaqRepository nasdaqRepository)
        {
        }

        public IEnumerable<Quotation> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Quotation GetOneByCompanyName(string companyName)
        {
            throw new System.NotImplementedException();
        }
    }
}