using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Quotations.Repositories.Tests
{
    public class Bel20FakeApiRepositoryTests
    {
        [Fact]
        public void ReadQuotations_ReturnsQuotations()
        {
            // Arrange           
            var fakeUri = new Uri("http://api.bel20.be");
            var sut = new Bel20FakeApiRepository(fakeUri);

            // Act
            var actual = sut.ReadQuotations().ToArray();

            // Assert
            actual.Should().NotBeEmpty();
        }
    }
}
