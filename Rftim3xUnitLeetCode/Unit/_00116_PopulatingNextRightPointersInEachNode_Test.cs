using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00116_PopulatingNextRightPointersInEachNode_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00116_PopulatingNextRightPointersInEachNode))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00116_PopulatingNextRightPointersInEachNode))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00116_PopulatingNextRightPointersInEachNode))![1]);

        public static TheoryData<List<string>, int> _00116_PopulatingNextRightPointersInEachNodePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00116_PopulatingNextRightPointersInEachNodePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00116_PopulatingNextRightPointersInEachNodePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00116_PopulatingNextRightPointersInEachNode.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00116_PopulatingNextRightPointersInEachNodePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00116_PopulatingNextRightPointersInEachNode.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
