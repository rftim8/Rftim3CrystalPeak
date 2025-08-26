using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00002_AddTwoNumbers_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 4, 3];
        private static readonly int[] a1 = [5, 6, 4];
        private static readonly int[] ar = [7, 0, 8];

        private static readonly int[] b0 = [0];
        private static readonly int[] b1 = [0];
        private static readonly int[] br = [0];

        public static TheoryData<int[], int[], int[]> _00002_AddTwoNumbers_Data =>
            new()
            {
                { a0, a1, ar},
                { b0, b1, br}
            };

        [Theory]
        [MemberData(nameof(_00002_AddTwoNumbers_Data))]
        public void AddTwoNumbers0(int[] a0, int[] a1, int[] expected)
        {
            // Arrange
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);
            ListNode? l1 = RftListNodesBuilder.RftCreateNodesFromArray(a1);

            // Act
            ListNode? lr = _00002_AddTwoNumbers.AddTwoNumbers0(l0, l1);

            List<int> actual = [];
            while (lr is not null)
            {
                actual.Add(lr.val);
                lr = lr.next;
            }

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
