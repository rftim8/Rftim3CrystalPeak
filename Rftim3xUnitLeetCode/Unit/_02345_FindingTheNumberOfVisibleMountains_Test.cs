using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02345_FindingTheNumberOfVisibleMountains_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02345_FindingTheNumberOfVisibleMountains))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02345_FindingTheNumberOfVisibleMountains))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02345_FindingTheNumberOfVisibleMountains))![1]);

        public static TheoryData<List<string>, int> _02345_FindingTheNumberOfVisibleMountainsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02345_FindingTheNumberOfVisibleMountainsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02345_FindingTheNumberOfVisibleMountainsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02345_FindingTheNumberOfVisibleMountains.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02345_FindingTheNumberOfVisibleMountainsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02345_FindingTheNumberOfVisibleMountains.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
