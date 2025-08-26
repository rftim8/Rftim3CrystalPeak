using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximum_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximum))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximum))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximum))![1]);

        public static TheoryData<List<string>, int> _03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximumPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximumPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximumPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximum.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximumPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03113_FindTheNumberOfSubarraysWhereBoundaryElementsAreMaximum.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
