using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00945_MinimumIncrementToMakeArrayUnique_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00945_MinimumIncrementToMakeArrayUnique))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00945_MinimumIncrementToMakeArrayUnique))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00945_MinimumIncrementToMakeArrayUnique))![1]);

        public static TheoryData<List<string>, int> _00945_MinimumIncrementToMakeArrayUniquePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00945_MinimumIncrementToMakeArrayUniquePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00945_MinimumIncrementToMakeArrayUniquePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00945_MinimumIncrementToMakeArrayUnique.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00945_MinimumIncrementToMakeArrayUniquePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00945_MinimumIncrementToMakeArrayUnique.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
