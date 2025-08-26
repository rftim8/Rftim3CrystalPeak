using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01423_MaximumPointsYouCanObtainfromCards_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01423_MaximumPointsYouCanObtainfromCards))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01423_MaximumPointsYouCanObtainfromCards))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01423_MaximumPointsYouCanObtainfromCards))![1]);

        public static TheoryData<List<string>, int> _01423_MaximumPointsYouCanObtainfromCardsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01423_MaximumPointsYouCanObtainfromCardsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01423_MaximumPointsYouCanObtainfromCardsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01423_MaximumPointsYouCanObtainfromCards.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01423_MaximumPointsYouCanObtainfromCardsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01423_MaximumPointsYouCanObtainfromCards.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
