using System.Collections.Generic;
using Quotations.Domain;
using Quotations.Repositories.Contracts;
using Quotations.Services.Contracts;

namespace Quotations.Services
{
    public class QuotationService: IQuotationService
    {
        private readonly INasdaqFileRepository fileRepository;

        public QuotationService(INasdaqFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
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