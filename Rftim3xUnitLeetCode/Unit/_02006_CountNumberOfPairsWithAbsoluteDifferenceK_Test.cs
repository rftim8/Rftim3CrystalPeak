using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02006_CountNumberOfPairsWithAbsoluteDifferenceK_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02006_CountNumberOfPairsWithAbsoluteDifferenceK))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02006_CountNumberOfPairsWithAbsoluteDifferenceK))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02006_CountNumberOfPairsWithAbsoluteDifferenceK))![1]);

        public static TheoryData<List<string>, int> _02006_CountNumberOfPairsWithAbsoluteDifferenceKPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02006_CountNumberOfPairsWithAbsoluteDifferenceKPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02006_CountNumberOfPairsWithAbsoluteDifferenceKPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02006_CountNumberOfPairsWithAbsoluteDifferenceK.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02006_CountNumberOfPairsWithAbsoluteDifferenceKPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02006_CountNumberOfPairsWithAbsoluteDifferenceK.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
