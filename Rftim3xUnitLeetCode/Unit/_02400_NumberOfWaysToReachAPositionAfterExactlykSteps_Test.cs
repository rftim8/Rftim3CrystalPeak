using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02400_NumberOfWaysToReachAPositionAfterExactlykSteps_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02400_NumberOfWaysToReachAPositionAfterExactlykSteps))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02400_NumberOfWaysToReachAPositionAfterExactlykSteps))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02400_NumberOfWaysToReachAPositionAfterExactlykSteps))![1]);

        public static TheoryData<List<string>, int> _02400_NumberOfWaysToReachAPositionAfterExactlykStepsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02400_NumberOfWaysToReachAPositionAfterExactlykStepsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02400_NumberOfWaysToReachAPositionAfterExactlykStepsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02400_NumberOfWaysToReachAPositionAfterExactlykSteps.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02400_NumberOfWaysToReachAPositionAfterExactlykStepsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02400_NumberOfWaysToReachAPositionAfterExactlykSteps.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
