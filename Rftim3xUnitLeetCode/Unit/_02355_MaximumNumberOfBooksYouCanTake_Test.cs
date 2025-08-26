using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02355_MaximumNumberOfBooksYouCanTake_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02355_MaximumNumberOfBooksYouCanTake))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02355_MaximumNumberOfBooksYouCanTake))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02355_MaximumNumberOfBooksYouCanTake))![1]);

        public static TheoryData<List<string>, int> _02355_MaximumNumberOfBooksYouCanTakePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02355_MaximumNumberOfBooksYouCanTakePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02355_MaximumNumberOfBooksYouCanTakePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02355_MaximumNumberOfBooksYouCanTake.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02355_MaximumNumberOfBooksYouCanTakePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02355_MaximumNumberOfBooksYouCanTake.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
