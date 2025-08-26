using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01171_RemoveZeroSumConsecutiveNodesFromLinkedList_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, -3, 3, 1];
        private static readonly int[] ar = [3, 1];

        private static readonly int[] b0 = [-1, 1, 0, 1];
        private static readonly int[] br = [1];

        private static readonly int[] c0 = [1, 2, 3, -3, 4];
        private static readonly int[] cr = [1, 2, 4];

        private static readonly int[] d0 = [1, 2, 3, -3, -2];
        private static readonly int[] dr = [1];

        public static TheoryData<int[], int[]> _01171_RemoveZeroSumConsecutiveNodesFromLinkedList_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr },
                { d0, dr }
            };

        [Theory]
        [MemberData(nameof(_01171_RemoveZeroSumConsecutiveNodesFromLinkedList_Data))]
        public void RemoveZeroSumConsecutiveNodesFromLinkedList0(int[] a0, int[] expected)
        {
            // Arrange
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);

            // Act
            ListNode? l1 = _01171_RemoveZeroSumConsecutiveNodesFromLinkedList.RemoveZeroSumConsecutiveNodesFromLinkedList0(l0!);
            List<int> actual = [];
            while (l1 is not null)
            {
                actual.Add(l1.val);
                l1 = l1.next;
            }

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01171_RemoveZeroSumConsecutiveNodesFromLinkedList_Data))]
        public void RemoveZeroSumConsecutiveNodesFromLinkedList1(int[] a0, int[] expected)
        {
            // Arrange
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);

            // Act
            ListNode? l1 = _01171_RemoveZeroSumConsecutiveNodesFromLinkedList.RemoveZeroSumConsecutiveNodesFromLinkedList1(l0!);
            List<int> actual = [];
            while (l1 is not null)
            {
                actual.Add(l1.val);
                l1 = l1.next;
            }

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}