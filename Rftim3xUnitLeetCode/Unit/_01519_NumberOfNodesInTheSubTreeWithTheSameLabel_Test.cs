using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01519_NumberOfNodesInTheSubTreeWithTheSameLabel_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01519_NumberOfNodesInTheSubTreeWithTheSameLabel))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01519_NumberOfNodesInTheSubTreeWithTheSameLabel))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01519_NumberOfNodesInTheSubTreeWithTheSameLabel))![1]);

        public static TheoryData<List<string>, int> _01519_NumberOfNodesInTheSubTreeWithTheSameLabelPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01519_NumberOfNodesInTheSubTreeWithTheSameLabelPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01519_NumberOfNodesInTheSubTreeWithTheSameLabelPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01519_NumberOfNodesInTheSubTreeWithTheSameLabel.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01519_NumberOfNodesInTheSubTreeWithTheSameLabelPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01519_NumberOfNodesInTheSubTreeWithTheSameLabel.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
