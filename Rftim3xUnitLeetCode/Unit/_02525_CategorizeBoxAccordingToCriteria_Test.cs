using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02525_CategorizeBoxAccordingToCriteria_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02525_CategorizeBoxAccordingToCriteria))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02525_CategorizeBoxAccordingToCriteria))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02525_CategorizeBoxAccordingToCriteria))![1]);

        public static TheoryData<List<string>, int> _02525_CategorizeBoxAccordingToCriteriaPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02525_CategorizeBoxAccordingToCriteriaPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02525_CategorizeBoxAccordingToCriteriaPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02525_CategorizeBoxAccordingToCriteria.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02525_CategorizeBoxAccordingToCriteriaPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02525_CategorizeBoxAccordingToCriteria.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
