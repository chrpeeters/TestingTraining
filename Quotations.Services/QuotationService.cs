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
        private readonly IQuotationRepository quotationRepository;
        private const string Path = "where the file should be...";

        public QuotationService(IQuotationRepository quotationRepository)
        {
            this.quotationRepository = quotationRepository;
        }

        public IEnumerable<Quotation> GetAll()
        {
            return quotationRepository.ReadQuotations();
        }

        public Quotation GetOneByCompanyName(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
                throw new ArgumentNullException(nameof(companyName));

            var quotation = quotationRepository.ReadQuotations()
                .SingleOrDefault(q => q.CompanyName == companyName);

            if (quotation == null)
                throw new CompanyNotFoundException(companyName);

            return quotation;
        }
    }
}