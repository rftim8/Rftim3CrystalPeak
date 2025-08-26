using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00203_RemoveLinkedListElements_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 6, 3, 4, 5, 6];
        private static readonly int a1 = 6;
        private static readonly int[] ar = [1, 2, 3, 4, 5];

        private static readonly int[] b0 = [];
        private static readonly int b1 = 1;
        private static readonly int[] br = [];

        private static readonly int[] c0 = [7, 7, 7, 7];
        private static readonly int c1 = 7;
        private static readonly int[] cr = [];


        public static TheoryData<int[], int, int[]> _00203_RemoveLinkedListElements_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00203_RemoveLinkedListElements_Data))]
        public void RemoveElements0(int[] list0, int val, int[] expected)
        {
            // Arrange
            ListNode[]? l0 = RftListNodesBuilder.RftCreateListOfNodes(list0);

            // Act
            ListNode? ln = l0?.Length > 0 ? _00203_RemoveLinkedListElements.RemoveElements0(l0[0], val) : null;
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
