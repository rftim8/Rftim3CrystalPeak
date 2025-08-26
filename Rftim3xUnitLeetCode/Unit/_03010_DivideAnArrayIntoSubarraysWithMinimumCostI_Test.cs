using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03010_DivideAnArrayIntoSubarraysWithMinimumCostI_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03010_DivideAnArrayIntoSubarraysWithMinimumCostI))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03010_DivideAnArrayIntoSubarraysWithMinimumCostI))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03010_DivideAnArrayIntoSubarraysWithMinimumCostI))![1]);

        public static TheoryData<List<string>, int> _03010_DivideAnArrayIntoSubarraysWithMinimumCostIPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03010_DivideAnArrayIntoSubarraysWithMinimumCostIPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03010_DivideAnArrayIntoSubarraysWithMinimumCostIPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03010_DivideAnArrayIntoSubarraysWithMinimumCostI.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03010_DivideAnArrayIntoSubarraysWithMinimumCostIPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03010_DivideAnArrayIntoSubarraysWithMinimumCostI.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
