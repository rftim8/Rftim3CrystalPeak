using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00277_FindTheCelebrity_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00277_FindTheCelebrity))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00277_FindTheCelebrity))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00277_FindTheCelebrity))![1]);

        public static TheoryData<List<string>, int> _00277_FindTheCelebrityPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00277_FindTheCelebrityPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00277_FindTheCelebrityPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00277_FindTheCelebrity.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00277_FindTheCelebrityPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00277_FindTheCelebrity.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
