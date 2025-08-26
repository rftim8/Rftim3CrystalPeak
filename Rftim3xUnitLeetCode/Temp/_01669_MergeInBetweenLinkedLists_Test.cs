using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01669_MergeInBetweenLinkedLists_Test
    {
        // Arrange
        private static readonly int[] a0 = [10, 1, 13, 6, 9, 5];
        private static readonly int a1 = 3, a2 = 4;
        private static readonly int[] a3 = [1000000, 1000001, 1000002];
        private static readonly List<int> ar = [10, 1, 13, 1000000, 1000001, 1000002, 5];

        private static readonly int[] b0 = [0, 1, 2, 3, 4, 5, 6];
        private static readonly int b1 = 2, b2 = 5;
        private static readonly int[] b3 = [1000000, 1000001, 1000002, 1000003, 1000004];
        private static readonly List<int> br = [0, 1, 1000000, 1000001, 1000002, 1000003, 1000004, 6];

        public static TheoryData<int[], int, int, int[], List<int>> _01669_MergeInBetweenLinkedLists_Data =>
            new()
            {
                { a0, a1, a2, a3, ar },
                { b0, b1, b2, b3, br }
            };


        [Theory]
        [MemberData(nameof(_01669_MergeInBetweenLinkedLists_Data))]
        public void MergeInBetweenLinkedLists0(int[] a0, int a1, int a2, int[] a3, List<int> expected)
        {
            // Arrange
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);
            ListNode? l3 = RftListNodesBuilder.RftCreateNodesFromArray(a3);

            // Act
            ListNode? r0 = _01669_MergeInBetweenLinkedLists.MergeInBetweenLinkedLists0(l0, a1, a2, l3);

            List<int> actual = [];
            while (r0 is not null)
            {
                actual.Add(r0.val);
                r0 = r0.next;
            }

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}