using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02086_MinimumNumberOfFoodBucketsToFeedtheHamsters_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02086_MinimumNumberOfFoodBucketsToFeedtheHamsters))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02086_MinimumNumberOfFoodBucketsToFeedtheHamsters))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02086_MinimumNumberOfFoodBucketsToFeedtheHamsters))![1]);

        public static TheoryData<List<string>, int> _02086_MinimumNumberOfFoodBucketsToFeedtheHamstersPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02086_MinimumNumberOfFoodBucketsToFeedtheHamstersPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02086_MinimumNumberOfFoodBucketsToFeedtheHamstersPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02086_MinimumNumberOfFoodBucketsToFeedtheHamsters.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02086_MinimumNumberOfFoodBucketsToFeedtheHamstersPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02086_MinimumNumberOfFoodBucketsToFeedtheHamsters.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
