using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01327_ListTheProductsOrderedInAPeriod_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01327_ListTheProductsOrderedInAPeriod))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01327_ListTheProductsOrderedInAPeriod))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01327_ListTheProductsOrderedInAPeriod))![1]);

        public static TheoryData<List<string>, int> _01327_ListTheProductsOrderedInAPeriodPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01327_ListTheProductsOrderedInAPeriodPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01327_ListTheProductsOrderedInAPeriodPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01327_ListTheProductsOrderedInAPeriod.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01327_ListTheProductsOrderedInAPeriodPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01327_ListTheProductsOrderedInAPeriod.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
