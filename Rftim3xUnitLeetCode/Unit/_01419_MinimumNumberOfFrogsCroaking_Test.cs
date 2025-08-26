using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01419_MinimumNumberOfFrogsCroaking_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01419_MinimumNumberOfFrogsCroaking))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01419_MinimumNumberOfFrogsCroaking))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01419_MinimumNumberOfFrogsCroaking))![1]);

        public static TheoryData<List<string>, int> _01419_MinimumNumberOfFrogsCroakingPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01419_MinimumNumberOfFrogsCroakingPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01419_MinimumNumberOfFrogsCroakingPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01419_MinimumNumberOfFrogsCroaking.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01419_MinimumNumberOfFrogsCroakingPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01419_MinimumNumberOfFrogsCroaking.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
