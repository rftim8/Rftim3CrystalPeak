using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02313_MinimumFlipsInBinaryTreeToGetResult_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02313_MinimumFlipsInBinaryTreeToGetResult))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02313_MinimumFlipsInBinaryTreeToGetResult))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02313_MinimumFlipsInBinaryTreeToGetResult))![1]);

        public static TheoryData<List<string>, int> _02313_MinimumFlipsInBinaryTreeToGetResultPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02313_MinimumFlipsInBinaryTreeToGetResultPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02313_MinimumFlipsInBinaryTreeToGetResultPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02313_MinimumFlipsInBinaryTreeToGetResult.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02313_MinimumFlipsInBinaryTreeToGetResultPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02313_MinimumFlipsInBinaryTreeToGetResult.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
