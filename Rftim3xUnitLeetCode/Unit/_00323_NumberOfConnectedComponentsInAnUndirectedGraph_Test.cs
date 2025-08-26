using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00323_NumberOfConnectedComponentsInAnUndirectedGraph_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00323_NumberOfConnectedComponentsInAnUndirectedGraph))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00323_NumberOfConnectedComponentsInAnUndirectedGraph))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00323_NumberOfConnectedComponentsInAnUndirectedGraph))![1]);

        public static TheoryData<List<string>, int> _00323_NumberOfConnectedComponentsInAnUndirectedGraphPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00323_NumberOfConnectedComponentsInAnUndirectedGraphPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00323_NumberOfConnectedComponentsInAnUndirectedGraphPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00323_NumberOfConnectedComponentsInAnUndirectedGraph.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00323_NumberOfConnectedComponentsInAnUndirectedGraphPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00323_NumberOfConnectedComponentsInAnUndirectedGraph.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
