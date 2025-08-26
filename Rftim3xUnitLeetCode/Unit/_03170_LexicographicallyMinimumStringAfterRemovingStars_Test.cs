using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03170_LexicographicallyMinimumStringAfterRemovingStars_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03170_LexicographicallyMinimumStringAfterRemovingStars))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03170_LexicographicallyMinimumStringAfterRemovingStars))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03170_LexicographicallyMinimumStringAfterRemovingStars))![1]);

        public static TheoryData<List<string>, int> _03170_LexicographicallyMinimumStringAfterRemovingStarsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03170_LexicographicallyMinimumStringAfterRemovingStarsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03170_LexicographicallyMinimumStringAfterRemovingStarsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03170_LexicographicallyMinimumStringAfterRemovingStars.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03170_LexicographicallyMinimumStringAfterRemovingStarsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03170_LexicographicallyMinimumStringAfterRemovingStars.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
