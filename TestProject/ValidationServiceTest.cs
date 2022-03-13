using mps360test;
using Xunit;

namespace TestProject
{
    public class ValidationServiceTest
    {

        [Theory]
        [InlineData("1 1 E")]
        public void ValidationCoordinateTestTrue(string coordinate)
        {
            ValidationService validationService = new ValidationService();

            Assert.True(validationService.ValidationCoordinate(coordinate));
        }

        [Theory]
        [InlineData("1 1E")]
        [InlineData("8 1 E")]
        [InlineData("1 R E")]
        [InlineData("11 E")]
        [InlineData("1 1 e")]
        [InlineData("1 1 j")]
        public void ValidationCoordinateTestFalse(string coordinate)
        {
            ValidationService validationService = new ValidationService();

            Assert.False(validationService.ValidationCoordinate(coordinate));
        }

        [Theory]
        [InlineData("RFLF")]
        public void ValidationPathTestTrue(string path)
        {
            ValidationService validationService = new ValidationService();

            Assert.True(validationService.ValidationPath(path));
        }

        [Theory]
        [InlineData("R FLF")]
        [InlineData("RFL F")]
        [InlineData("RFlF")]
        [InlineData("RKL1")]
        [InlineData("RFjO")]
        public void ValidationPathTestFalse(string path)
        {
            ValidationService validationService = new ValidationService();

            Assert.False(validationService.ValidationPath(path));
        }
    }
}
