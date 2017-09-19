using System;
using System.IO;
using FluentAssertions;
using Quotations.Domain;
using Xunit;

namespace Quotations.Repositories.Tests
{
    public class NasdaqFileRepositoryTests
    {
        [Fact]
        public void ReadQuotations_WhenFileNotFound_ThrowFileNotFoundException()
        {
            var file = new TestFile("", "unknown-file.csv");

            var sut = new NasdaqFileRepository();

            // Act
            Action action = () => sut.ReadQuotations(file.Path);

            // Assert
            action.ShouldThrow<FileNotFoundException>();
        }

        [Fact]
        public void ReadQuotations_WhenInvalidFileFormat_ThrowInvalidDataException()
        {
            var file = new TestFile("", "invalid-data.csv");

            var sut = new NasdaqFileRepository();

            // Act
            Action action = () => sut.ReadQuotations(file.Path);

            // Assert
            action.ShouldThrow<InvalidDataException>();
        }

        [Fact]
        public void ReadQuotations_WhenValidFile_ReturnsQuotations()
        {
            // Arrange
            var expected = new[]
            {
                new Quotation("Apple", 123.45m, "USD"),
                new Quotation("Cisco systems", 0.8998m, "USD"),
                new Quotation("Ebay", 1320.12m, "USD"),
                new Quotation("Facebook", 100.00m, "EUR"),
                new Quotation("Intel corp", 45.50m, "USD"),
                new Quotation("Nvidia", 1.32m, "USD"),
                new Quotation("Vodafone group", 2566.45m, "GBP")
            };

            var file = new TestFile("", "valid-data.csv");

            var sut = new NasdaqFileRepository();

            // Act
            var actual = sut.ReadQuotations(file.Path);

            // Assert
            actual.Should().NotBeEmpty()
                .And.HaveSameCount(expected)
                .And.BeEquivalentTo(expected)
                .And.ContainItemsAssignableTo<Quotation>();
        }
    }
}