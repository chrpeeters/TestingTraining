namespace Quotations.Domain
{
    public class Quotation
    {
        public Quotation(string companyName, decimal value, string currency)
        {
            CompanyName = companyName;
            Value = value;
            Currency = currency;
        }

        public string CompanyName { get; }
        public decimal Value { get; }
        public string Currency { get; }
    }
}
