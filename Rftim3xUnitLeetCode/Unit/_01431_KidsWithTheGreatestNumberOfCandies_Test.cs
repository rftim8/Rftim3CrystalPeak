using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01431_KidsWithTheGreatestNumberOfCandies_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01431_KidsWithTheGreatestNumberOfCandies))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01431_KidsWithTheGreatestNumberOfCandies))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01431_KidsWithTheGreatestNumberOfCandies))![1]);

        public static TheoryData<List<string>, int> _01431_KidsWithTheGreatestNumberOfCandiesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01431_KidsWithTheGreatestNumberOfCandiesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01431_KidsWithTheGreatestNumberOfCandiesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01431_KidsWithTheGreatestNumberOfCandies.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01431_KidsWithTheGreatestNumberOfCandiesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01431_KidsWithTheGreatestNumberOfCandies.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
