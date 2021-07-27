using WhiskyCrate.Application.Helpers;
using Xunit;

namespace WhiskyCrate.Application.Test.Helpers
{
    public class MonthsToyearsTest
    {
        [Theory]
        [InlineData(1, "1 month")]
        [InlineData(2, "2 months")]
        [InlineData(3, "3 months")]
        [InlineData(4, "4 months")]
        [InlineData(5, "5 months")]
        [InlineData(6, "6 months")]
        [InlineData(7, "7 months")]
        [InlineData(8, "8 months")]
        [InlineData(9, "9 months")]
        [InlineData(10, "10 months")]
        [InlineData(11, "11 months")]
        [InlineData(12, "1 year")]
        [InlineData(13, "1 year")]
        [InlineData(23, "1 year")]
        [InlineData(24, "2 years")]
        [InlineData(25, "2 years")]
        [InlineData(47, "3 years")]
        [InlineData(48, "4 years")]
        [InlineData(49, "4 years")]
        [InlineData(143, "11 years")]
        [InlineData(144, "12 years")]
        [InlineData(145, "12 years")]
        [InlineData(215, "17 years")]
        [InlineData(216, "18 years")]
        [InlineData(217, "18 years")]
        public void Resolve(int months, string expected)
        {
            //arrange
            //act
            var result = MonthsToYears.Resolve(months);
            //assert
            Assert.Equal(expected, result);
        }
    }
}