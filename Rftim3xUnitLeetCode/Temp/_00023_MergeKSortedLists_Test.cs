using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00023_MergeKSortedLists_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int[] ar = [];

        public static TheoryData<int[], int[]> _00023_MergeKSortedLists_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00023_MergeKSortedLists_Data))]
        public void MergeKSortedLists0(int[] a0, int[] expected)
        {
            // Act
            ListNode[]? l0 = RftListNodesBuilder.RftCreateListOfNodes(a0);

            ListNode? x = _00023_MergeKSortedLists.MergeKSortedLists0(l0);
            List<int> actual = [];
            while (x is not null)
            {
                actual.Add(x.val);
                x = x.next;
            }

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}