using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02009_MinimumNumberOfOperationsToMakeArrayContinuous_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02009_MinimumNumberOfOperationsToMakeArrayContinuous))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02009_MinimumNumberOfOperationsToMakeArrayContinuous))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02009_MinimumNumberOfOperationsToMakeArrayContinuous))![1]);

        public static TheoryData<List<string>, int> _02009_MinimumNumberOfOperationsToMakeArrayContinuousPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02009_MinimumNumberOfOperationsToMakeArrayContinuousPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02009_MinimumNumberOfOperationsToMakeArrayContinuousPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02009_MinimumNumberOfOperationsToMakeArrayContinuous.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02009_MinimumNumberOfOperationsToMakeArrayContinuousPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02009_MinimumNumberOfOperationsToMakeArrayContinuous.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
