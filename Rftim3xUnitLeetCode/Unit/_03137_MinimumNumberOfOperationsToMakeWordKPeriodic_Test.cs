using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03137_MinimumNumberOfOperationsToMakeWordKPeriodic_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03137_MinimumNumberOfOperationsToMakeWordKPeriodic))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03137_MinimumNumberOfOperationsToMakeWordKPeriodic))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03137_MinimumNumberOfOperationsToMakeWordKPeriodic))![1]);

        public static TheoryData<List<string>, int> _03137_MinimumNumberOfOperationsToMakeWordKPeriodicPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03137_MinimumNumberOfOperationsToMakeWordKPeriodicPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03137_MinimumNumberOfOperationsToMakeWordKPeriodicPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03137_MinimumNumberOfOperationsToMakeWordKPeriodic.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03137_MinimumNumberOfOperationsToMakeWordKPeriodicPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03137_MinimumNumberOfOperationsToMakeWordKPeriodic.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
