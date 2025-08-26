using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00237_DeleteNodeInALinkedList_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 5, 1, 9];
        private static readonly int ar = 5;

        public static TheoryData<int[], int> _00237_DeleteNodeInALinkedList_Data =>
            new()
            {
                { a0, ar }
            };

        [Theory]
        [MemberData(nameof(_00237_DeleteNodeInALinkedList_Data))]
        public void MergeTwoLists(int[] list1, int expected)
        {
            // Arrange
            ListNode[]? l0 = RftListNodesBuilder.RftCreateListOfNodes(list1);

            // Act
            //int actual = _00237_DeleteNodeInALinkedList.DeleteNode0(l0?[1]!);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
