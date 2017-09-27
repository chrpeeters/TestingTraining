using FluentAssertions;
using System.Linq;
using Xunit;

namespace Quotations.Repositories.Tests
{
    public class NikkeiHardcordedRepositoryTests
    {
        [Fact]
        public void ReadQuotations_ReturnsQuotations()
        {
            // Arrange           
            var sut = new NikkeiHardcordedRepository();

            // Act
            var actual = sut.ReadQuotations().ToArray();

            // Assert
            actual.Should().NotBeEmpty();
        }
    }
}
