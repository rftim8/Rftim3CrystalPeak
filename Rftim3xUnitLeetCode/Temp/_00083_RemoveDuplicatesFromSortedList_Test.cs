using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00083_RemoveDuplicatesFromSortedList_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 1, 2];
        private static readonly int[] ar = [1, 2];

        private static readonly int[] b0 = [1, 1, 2, 3, 3];
        private static readonly int[] br = [1, 2, 3];

        public static TheoryData<int[], int[]> _00083_RemoveDuplicatesFromSortedList_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00083_RemoveDuplicatesFromSortedList_Data))]
        public void DeleteDuplicates0(int[] list1, int[] expected)
        {
            // Arrange
            ListNode[]? l0 = RftListNodesBuilder.RftCreateListOfNodes(list1);

            // Act
            ListNode? ln = _00083_RemoveDuplicatesFromSortedList.DeleteDuplicates0(l0?[0]);

            // Assert
            if (ln is null) Assert.Equal(expected, []);
            else
            {
                List<int> r = [];
                RftReadListOfListNodes(ln);

                void RftReadListOfListNodes(ListNode? ln)
                {
                    r.Add(ln!.val);
                    ln = ln?.next;
                    if (ln is not null) RftReadListOfListNodes(ln);
                }

                int[] actual = [.. r];

                Assert.Equal(expected, actual);
            }
        }
    }
}
