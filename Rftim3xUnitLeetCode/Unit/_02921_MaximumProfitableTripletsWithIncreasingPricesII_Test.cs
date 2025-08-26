using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02921_MaximumProfitableTripletsWithIncreasingPricesII_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02921_MaximumProfitableTripletsWithIncreasingPricesII))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02921_MaximumProfitableTripletsWithIncreasingPricesII))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02921_MaximumProfitableTripletsWithIncreasingPricesII))![1]);

        public static TheoryData<List<string>, int> _02921_MaximumProfitableTripletsWithIncreasingPricesIIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02921_MaximumProfitableTripletsWithIncreasingPricesIIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02921_MaximumProfitableTripletsWithIncreasingPricesIIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02921_MaximumProfitableTripletsWithIncreasingPricesII.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02921_MaximumProfitableTripletsWithIncreasingPricesIIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02921_MaximumProfitableTripletsWithIncreasingPricesII.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
