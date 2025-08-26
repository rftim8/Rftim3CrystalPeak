using Rftim3Convoy.Temp.Construct.Trees;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;
using System.Text;
using Xunit.Abstractions;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00515_FindLargestValueInEachTreeRow_Test(ITestOutputHelper testOutputHelper)
    {
        // Arrange
        private static readonly int[] a0 = [1, 3, 2, 5, 3, 0, 9];
        private static readonly int[] ar = [1, 3, 9];

        private static readonly int[] b0 = [1, 2, 3];
        private static readonly int[] br = [1, 3];
        private readonly ITestOutputHelper testOutputHelper = testOutputHelper;

        public static TheoryData<int[], int[]> _00515_FindLargestValueInEachTreeRow_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00515_FindLargestValueInEachTreeRow_Data))]
        public void LargestValues0(int[] list0, int[] expected)
        {
            // Arrange
            TreeNode0? l0 = RftTreeNodesBuilder.RftCreateListOfBinaryTreeNodes(list0);

            // Act
            IList<int> actual = _00515_FindLargestValueInEachTreeRow.LargestValues0(l0);

            StringBuilder sb = new();
            foreach (int item in actual)
            {
                sb.Append($"{item} ");
            }
            testOutputHelper.WriteLine($"{sb}");

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
