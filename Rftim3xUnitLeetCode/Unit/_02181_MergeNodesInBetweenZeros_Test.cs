using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02181_MergeNodesInBetweenZeros_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02181_MergeNodesInBetweenZeros))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02181_MergeNodesInBetweenZeros))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02181_MergeNodesInBetweenZeros))![1]);

        public static TheoryData<List<string>, int> _02181_MergeNodesInBetweenZerosPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02181_MergeNodesInBetweenZerosPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02181_MergeNodesInBetweenZerosPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02181_MergeNodesInBetweenZeros.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02181_MergeNodesInBetweenZerosPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02181_MergeNodesInBetweenZeros.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
