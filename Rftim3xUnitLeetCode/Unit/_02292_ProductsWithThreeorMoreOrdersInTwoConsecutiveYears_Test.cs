using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYears_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYears))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYears))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYears))![1]);

        public static TheoryData<List<string>, int> _02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYearsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYearsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYearsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYears.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYearsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02292_ProductsWithThreeorMoreOrdersInTwoConsecutiveYears.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
