using System.IO;
using Xunit;

namespace Quotations.Repositories.Tests
{
    public class NasdaqFileRepositoryTests
    {
        [Fact]
        public void ReadQuotations_WhenFileNotFound_ThrowFileNotFoundException()
        {
        }

        [Fact]
        public void ReadQuotations_WhenInvalidFileFormat_ThrowInvalidDataException()
        {
        }

        [Fact]
        public void ReadQuotations_WhenValidFile_ReturnsQuotations()
        {
            // Arrange


            var sut = new NasdaqFileRepository();
            
            // Act
            var actual = sut.ReadQuotations()

            // Assert
            actual.shou
        }
    }
}