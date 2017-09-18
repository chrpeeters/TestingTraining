using System.Collections;
using System.Collections.Generic;
using Quotations.Domain;

namespace Quotations.Services.Contracts
{
    public interface IQuotationService
    {
        IEnumerable<Quotation> GetAll();
        Quotation GetOneByCompanyName(string companyName);
    }
}