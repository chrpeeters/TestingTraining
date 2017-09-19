using System;
using System.Collections.Generic;
using System.Linq;
using Quotations.Domain;
using Quotations.Domain.Excpetions;
using Quotations.Repositories.Contracts;
using Quotations.Services.Contracts;

namespace Quotations.Services
{
    public class QuotationService : IQuotationService
    {
        public QuotationService(INasdaqFileRepository fileRepository)
        {
        }

        public IEnumerable<Quotation> GetAll()
        {
            return fileRepository.ReadQuotations();
        }

        public Quotation GetOneByCompanyName(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
                throw new ArgumentNullException(nameof(companyName));

            var quotation = fileRepository.ReadQuotations()
                .SingleOrDefault(q => q.CompanyName == companyName);

            if (quotation == null)
                throw new CompanyNotFoundException();

            return quotation;
        }
    }
}