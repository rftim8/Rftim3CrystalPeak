using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02068_CheckWhetherTwoStringsAreAlmostEquivalent_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02068_CheckWhetherTwoStringsAreAlmostEquivalent))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02068_CheckWhetherTwoStringsAreAlmostEquivalent))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02068_CheckWhetherTwoStringsAreAlmostEquivalent))![1]);

        public static TheoryData<List<string>, int> _02068_CheckWhetherTwoStringsAreAlmostEquivalentPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02068_CheckWhetherTwoStringsAreAlmostEquivalentPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02068_CheckWhetherTwoStringsAreAlmostEquivalentPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02068_CheckWhetherTwoStringsAreAlmostEquivalent.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02068_CheckWhetherTwoStringsAreAlmostEquivalentPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02068_CheckWhetherTwoStringsAreAlmostEquivalent.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
