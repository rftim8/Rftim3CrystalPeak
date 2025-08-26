using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02997_MinimumNumberOfOperationsToMakeArrayXOREqualToK_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02997_MinimumNumberOfOperationsToMakeArrayXOREqualToK))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02997_MinimumNumberOfOperationsToMakeArrayXOREqualToK))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02997_MinimumNumberOfOperationsToMakeArrayXOREqualToK))![1]);

        public static TheoryData<List<string>, int> _02997_MinimumNumberOfOperationsToMakeArrayXOREqualToKPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02997_MinimumNumberOfOperationsToMakeArrayXOREqualToKPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02997_MinimumNumberOfOperationsToMakeArrayXOREqualToKPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02997_MinimumNumberOfOperationsToMakeArrayXOREqualToK.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02997_MinimumNumberOfOperationsToMakeArrayXOREqualToKPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02997_MinimumNumberOfOperationsToMakeArrayXOREqualToK.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
