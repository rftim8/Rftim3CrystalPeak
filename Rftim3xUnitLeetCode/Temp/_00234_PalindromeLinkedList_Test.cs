using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00234_PalindromeLinkedList_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 2, 1];
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 2];
        private static readonly bool br = false;

        public static TheoryData<int[], bool> _00234_PalindromeLinkedList_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00234_PalindromeLinkedList_Data))]
        public void IsPalindrome0(int[] list0, bool expected)
        {
            // Arrange
            ListNode[]? l0 = RftListNodesBuilder.RftCreateListOfNodes(list0);

            // Act
            bool actual = _00234_PalindromeLinkedList.IsPalindrome0(l0?[0]);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
