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
        private readonly INasdaqFileRepository fileRepository;
        private const string Path = "where the file should be...";

        public QuotationService(INasdaqRepository nasdaqRepository)
        {
            this.fileRepository = fileRepository;
        }

        public IEnumerable<Quotation> GetAll()
        {
            return fileRepository.ReadQuotations(Path);
        }

        public Quotation GetOneByCompanyName(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
                throw new ArgumentNullException(nameof(companyName));

            var quotation = fileRepository.ReadQuotations(Path)
                .SingleOrDefault(q => q.CompanyName == companyName);

            if (quotation == null)
                throw new CompanyNotFoundException(companyName);

            return quotation;
        }
    }
}