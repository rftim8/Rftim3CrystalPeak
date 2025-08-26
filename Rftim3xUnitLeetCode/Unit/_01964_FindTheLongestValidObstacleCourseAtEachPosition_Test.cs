using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01964_FindTheLongestValidObstacleCourseAtEachPosition_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01964_FindTheLongestValidObstacleCourseAtEachPosition))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01964_FindTheLongestValidObstacleCourseAtEachPosition))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01964_FindTheLongestValidObstacleCourseAtEachPosition))![1]);

        public static TheoryData<List<string>, int> _01964_FindTheLongestValidObstacleCourseAtEachPositionPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01964_FindTheLongestValidObstacleCourseAtEachPositionPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01964_FindTheLongestValidObstacleCourseAtEachPositionPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01964_FindTheLongestValidObstacleCourseAtEachPosition.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01964_FindTheLongestValidObstacleCourseAtEachPositionPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01964_FindTheLongestValidObstacleCourseAtEachPosition.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
