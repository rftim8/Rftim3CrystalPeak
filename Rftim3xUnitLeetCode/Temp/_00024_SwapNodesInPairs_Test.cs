using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00024_SwapNodesInPairs_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 4];
        private static readonly List<int> ar = [2, 1, 4, 3];

        private static readonly int[] b0 = [];
        private static readonly List<int> br = [];

        private static readonly int[] c0 = [1];
        private static readonly List<int> cr = [1];

        public static TheoryData<int[], List<int>> _00024_SwapNodesInPairs_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00024_SwapNodesInPairs_Data))]
        public void SwapNodesInPairs0(int[] a0, List<int> expected)
        {
            // Arrange
            ListNode? x = RftListNodesBuilder.RftCreateNodesFromArray(a0);

            // Act
            ListNode? l0 = _00024_SwapNodesInPairs.SwapNodesInPairs0(x);

            List<int> actual = [];
            while (l0 is not null)
            {
                actual.Add(l0.val);
                l0 = l0.next;
            }

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}