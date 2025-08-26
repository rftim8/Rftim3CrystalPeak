using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01269_NumberOfWaysToStayInTheSamePlaceAfterSomeSteps_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01269_NumberOfWaysToStayInTheSamePlaceAfterSomeSteps))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01269_NumberOfWaysToStayInTheSamePlaceAfterSomeSteps))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01269_NumberOfWaysToStayInTheSamePlaceAfterSomeSteps))![1]);

        public static TheoryData<List<string>, int> _01269_NumberOfWaysToStayInTheSamePlaceAfterSomeStepsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01269_NumberOfWaysToStayInTheSamePlaceAfterSomeStepsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01269_NumberOfWaysToStayInTheSamePlaceAfterSomeStepsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01269_NumberOfWaysToStayInTheSamePlaceAfterSomeSteps.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01269_NumberOfWaysToStayInTheSamePlaceAfterSomeStepsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01269_NumberOfWaysToStayInTheSamePlaceAfterSomeSteps.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
