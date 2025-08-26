using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00206_ReverseLinkedList_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 4, 5];
        private static readonly int[] ar = [5, 4, 3, 2, 1];

        private static readonly int[] b0 = [1, 2];
        private static readonly int[] br = [2, 1];

        private static readonly int[] c0 = [];
        private static readonly int[] cr = [];

        public static TheoryData<int[], int[]> _00206_ReverseLinkedList_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00206_ReverseLinkedList_Data))]
        public void ReverseList0(int[] list0, int[] expected)
        {
            // Arrange
            ListNode[]? l0 = RftListNodesBuilder.RftCreateListOfNodes(list0);

            // Act
            ListNode? ln = l0?.Length > 0 ? _00206_ReverseLinkedList.ReverseList0(l0[0]) : null;
            List<int> r = [];

            while (ln is not null)
            {
                r.Add(ln.val);
                ln = ln.next;
            }
            int[] actual = [.. r];

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
