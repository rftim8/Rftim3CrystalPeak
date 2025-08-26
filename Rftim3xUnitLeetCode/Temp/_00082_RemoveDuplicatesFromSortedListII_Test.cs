using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00082_RemoveDuplicatesFromSortedListII_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int[] ar = [];

        public static TheoryData<int[], int[]> _00082_RemoveDuplicatesFromSortedListII_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00082_RemoveDuplicatesFromSortedListII_Data))]
        public void RemoveDuplicatesFromSortedListII0(int[] a0, int[] expected)
        {
            // Act
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);

            ListNode? x = _00082_RemoveDuplicatesFromSortedListII.RemoveDuplicatesFromSortedListII0(l0);
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