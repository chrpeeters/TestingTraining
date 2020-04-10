using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Quotations.Domain;
using Quotations.Domain.Exceptions;
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

            var nasdaqRepository = new Mock<INasdaqRepository>();
            nasdaqRepository.Setup(rep => rep.ReadQuotations(It.IsAny<string>()))
                .Returns(new[] { quotation });

            var sut = new QuotationService(nasdaqRepository.Object);

            // Act
            var actual = sut.GetOneByCompanyName(companyName);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(quotation);
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

            var nasdaqRepository = new Mock<INasdaqRepository>();
            nasdaqRepository.Setup(rep => rep.ReadQuotations(It.IsAny<string>()))
            .Returns(new[] { quotation });

            var sut = new QuotationService(nasdaqRepository.Object);

            // Act
            Action action = () => sut.GetOneByCompanyName(notExistingCompanyName);

            // Assert
            action.Should().Throw<CompanyNotFoundException>()
                .And.NotFoundCompanyName.Should().Be(notExistingCompanyName);

        }

        [Fact]
        public void GetOneByCompanyName_WhenCompanyNameIsNull_ThrowArgumentNullException()
        {
            // Arrange
            var sut = new QuotationService(null);

            // Act
            Action action = () => sut.GetOneByCompanyName(null);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetOneByCompanyName_WhenCompanyNameIsEmpty_ThrowArgumentNullException()
        {
            // Arrange
            var sut = new QuotationService(null);

            // Act
            Action action = () => sut.GetOneByCompanyName(string.Empty);

            // Assert
            action.Should().Throw<ArgumentNullException>();
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

            var nasdaqRepository = new Mock<INasdaqRepository>();
            nasdaqRepository.Setup(rep => rep.ReadQuotations(It.IsAny<string>()))
                .Returns(quotations);

            var sut = new QuotationService(nasdaqRepository.Object);

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

            var nasdaqRepository = new Mock<INasdaqRepository>();
            nasdaqRepository.Setup(rep => rep.ReadQuotations(It.IsAny<string>()))
                .Returns(quotations);

            var sut = new QuotationService(nasdaqRepository.Object);

            // Act
            var actual = sut.GetAll();

            // Assert
            actual.Should().BeEmpty()
                .And.NotBeNull();
        }
    }
}