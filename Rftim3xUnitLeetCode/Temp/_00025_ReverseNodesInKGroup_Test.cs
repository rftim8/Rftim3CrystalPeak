using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00025_ReverseNodesInKGroup_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 4, 5];
        private static readonly int a1 = 2;
        private static readonly int[] ar = [2, 1, 4, 3, 5];

        public static TheoryData<int[], int, int[]> _00025_ReverseNodesInKGroup_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00025_ReverseNodesInKGroup_Data))]
        public void ReverseNodesInKGroup0(int[] a0, int a1, int[] expected)
        {
            // Act
            ListNode? l0 = RftListNodesBuilder.RftCreateNodesFromArray(a0);


            ListNode? r = _00025_ReverseNodesInKGroup.ReverseKGroup0(l0, a1);
            List<int> actual = [];
            while (r is not null)
            {
                actual.Add(r.val);
                r = r.next;
            }

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}