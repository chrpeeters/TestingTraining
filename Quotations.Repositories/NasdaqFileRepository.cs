using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Quotations.Domain;
using Quotations.Repositories.Contracts;

namespace Quotations.Repositories
{
    public class NasdaqFileRepository : INasdaqFileRepository
    {
        public IEnumerable<Quotation> ReadQuotations(string fullPath)
        {
            var content = File.ReadAllLines(fullPath);

            foreach (var line in content)
                yield return CreateQuotation(line);
        }

        private Quotation CreateQuotation(string line)
        {
            try
            {
                var items = line.Split(';');
                return new Quotation(
                    items[0],
                    decimal.Parse(items[1],CultureInfo.InvariantCulture),
                    items[2]);
            }
            catch (Exception e)
            {
                throw new InvalidDataException($"Invalid data when parsing: {line}", e);
            }
        }
    }
}