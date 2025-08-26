using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree))![1]);

        public static TheoryData<List<string>, int> _01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTreePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTreePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTreePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTreePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01379_FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
