using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02809_MinimumTimeToMakeArraySumAtMostX_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02809_MinimumTimeToMakeArraySumAtMostX))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02809_MinimumTimeToMakeArraySumAtMostX))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02809_MinimumTimeToMakeArraySumAtMostX))![1]);

        public static TheoryData<List<string>, int> _02809_MinimumTimeToMakeArraySumAtMostXPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02809_MinimumTimeToMakeArraySumAtMostXPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02809_MinimumTimeToMakeArraySumAtMostXPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02809_MinimumTimeToMakeArraySumAtMostX.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02809_MinimumTimeToMakeArraySumAtMostXPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02809_MinimumTimeToMakeArraySumAtMostX.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
