using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03204_BitwiseUserPermissionsAnalysis_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03204_BitwiseUserPermissionsAnalysis))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03204_BitwiseUserPermissionsAnalysis))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03204_BitwiseUserPermissionsAnalysis))![1]);

        public static TheoryData<List<string>, int> _03204_BitwiseUserPermissionsAnalysisPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03204_BitwiseUserPermissionsAnalysisPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03204_BitwiseUserPermissionsAnalysisPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03204_BitwiseUserPermissionsAnalysis.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03204_BitwiseUserPermissionsAnalysisPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03204_BitwiseUserPermissionsAnalysis.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
