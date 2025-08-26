using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00141_LinkedListCycle_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 2, 0, -4];
        private static readonly int a1 = 1;
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 2];
        private static readonly int b1 = 0;
        private static readonly bool br = true;

        private static readonly int[] c0 = [1];
        private static readonly int c1 = -1;
        private static readonly bool cr = false;

        public static TheoryData<int[], int, bool> _00141_LinkedListCycle_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00141_LinkedListCycle_Data))]
        public void HasCycle0(int[] list0, int pos, bool expected)
        {
            // Arrange
            ListNode[]? l0 = RftListNodesBuilder.RftCreateListOfNodes(list0);
            if (pos > -1) l0![^1].next = l0[pos];

            // Act
            bool actual = _00141_LinkedListCycle.HasCycle0(l0?[0]);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
