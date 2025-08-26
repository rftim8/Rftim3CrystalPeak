using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThreshold_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThreshold))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThreshold))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThreshold))![1]);

        public static TheoryData<List<string>, int> _01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThresholdPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThresholdPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThresholdPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThreshold.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThresholdPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01343_NumberOfSubarraysOfSizeKandAverageGreaterThanOrEqualToThreshold.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
