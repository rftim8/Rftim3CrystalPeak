using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00019_RemoveNthNodeFromEndOfList_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 4, 5];
        private static readonly int a1 = 2;
        private static readonly List<int> ar = [1, 2, 3, 5];

        private static readonly int[] b0 = [1];
        private static readonly int b1 = 1;
        private static readonly List<int> br = [];

        private static readonly int[] c0 = [1, 2];
        private static readonly int c1 = 1;
        private static readonly List<int> cr = [1];

        public static TheoryData<int[], int, List<int>> _00019_RemoveNthNodeFromEndOfList_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };


        [Theory]
        [MemberData(nameof(_00019_RemoveNthNodeFromEndOfList_Data))]
        public void RemoveNthNodeFromEndOfList0(int[] a0, int a1, List<int> expected)
        {
            // Arrange
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);

            // Act
            ListNode? x = _00019_RemoveNthNodeFromEndOfList.RemoveNthNodeFromEndOfList0(l0, a1);

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