using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTree_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTree))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTree))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTree))![1]);

        public static TheoryData<List<string>, int> _01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTreePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTreePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTreePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTree.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTreePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01430_CheckIfaStringIsaValidSequenceFromRootToLeavesPathInABinaryTree.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
