using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Quotations.Domain;
using Quotations.Domain.Excpetions;
using Quotations.Repositories.Contracts;
using Xunit;

namespace Quotations.Services.Tests
{
    public class QuotationServiceTests
    {
        [Fact]
        public void GetOneByCompanyName_WhenExistingCompanyName_ReturnQuotation()
        {
            // Arrange
            var companyName = "company name";
            var quotation = new Quotation
            (
                companyName,
                123.45m,
                "USD"
            );

            var fileRepository = new Mock<INasdaqFileRepository>();
            fileRepository.Setup(rep => rep.ReadQuotations())
                .Returns(new[] { quotation });

            var sut = new QuotationService(fileRepository.Object);

            // Act
            var actual = sut.GetOneByCompanyName(companyName);

            // Assert
            actual.Should().NotBeNull();
            actual.ShouldBeEquivalentTo(quotation);
        }

        [Fact]
        public void GetOneByCompanyName_WhenCompanyNameNotFound_ThrowCompanyNotFoundException()
        {
            // Arrange
            var companyName = "company name";
            var notExistingCompanyName = "not a company name";
            var quotation = new Quotation
            (
                companyName,
                123.45m,
                "USD"
            );

            var fileRepository = new Mock<INasdaqFileRepository>();
            fileRepository.Setup(rep => rep.ReadQuotations())
            .Returns(new[] { quotation });

            var sut = new QuotationService(fileRepository.Object);

            // Act
            Action action = () => sut.GetOneByCompanyName(notExistingCompanyName);

            // Assert
            action.ShouldThrow<CompanyNotFoundException>();
        }

        [Fact]
        public void GetOneByCompanyName_WhenCompanyNameIsNull_ThrowArgumentNullException()
        {
            // Arrange
            var sut = new QuotationService(null);

            // Act
            Action action = () => sut.GetOneByCompanyName(null);

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetOneByCompanyName_WhenCompanyNameIsEmpty_ThrowArgumentNullException()
        {
            // Arrange
            var sut = new QuotationService(null);

            // Act
            Action action = () => sut.GetOneByCompanyName(string.Empty);

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GetAll_ReturnsEnumerationOfQuotations()
        {
            // Arrange
            Quotation[] quotations = {
                new Quotation
                (
                    "Company 1",
                    123.45m,
                    "USD"
                ),
                new Quotation
                (
                    "Company 2",
                    67.8m,
                    "EUR"
                ),
                new Quotation
                (
                    "Company 3",
                    999m,
                    "USD"
                )
            };

            var fileRepository = new Mock<INasdaqFileRepository>();
            fileRepository.Setup(rep => rep.ReadQuotations())
                .Returns(quotations);

            var sut = new QuotationService(fileRepository.Object);

            // Act
            var actual = sut.GetAll();

            // Assert
            actual.Should().NotBeEmpty()
                .And.HaveSameCount(quotations)
                .And.BeEquivalentTo(quotations)
                .And.ContainItemsAssignableTo<Quotation>();
        }

        [Fact]
        public void GetAll_ReturnsEmptyEnumerations()
        {
            // Arrange
            Quotation[] quotations = { };

            var fileRepository = new Mock<INasdaqFileRepository>();
            fileRepository.Setup(rep => rep.ReadQuotations())
                .Returns(quotations);

            var sut = new QuotationService(fileRepository.Object);

            // Act
            var actual = sut.GetAll();

            // Assert
            actual.Should().BeEmpty()
                .And.NotBeNull();
        }
    }
}