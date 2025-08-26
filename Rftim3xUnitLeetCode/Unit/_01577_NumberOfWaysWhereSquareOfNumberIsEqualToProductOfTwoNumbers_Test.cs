using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbers_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbers))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbers))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbers))![1]);

        public static TheoryData<List<string>, int> _01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbersPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbersPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbersPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbers.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbersPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01577_NumberOfWaysWhereSquareOfNumberIsEqualToProductOfTwoNumbers.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
