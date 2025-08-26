using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable))![1]);

        public static TheoryData<List<string>, int> _01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversablePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversablePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversablePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversablePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01579_RemoveMaxNumberOfEdgesToKeepGraphFullyTraversable.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
