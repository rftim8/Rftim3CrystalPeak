namespace Rftim3xUnitLeetCode.Temp
{
    public class _00021_MergeTwoSortedLists_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 4];
        private static readonly int[] a1 = [1, 3, 4];
        private static readonly int[] ar = [1, 1, 2, 3, 4, 4];

        private static readonly int[] b0 = [];
        private static readonly int[] b1 = [];
        private static readonly int[] br = [];

        private static readonly int[] c0 = [];
        private static readonly int[] c1 = [0];
        private static readonly int[] cr = [0];

        public static TheoryData<int[], int[], int[]> _00021_MergeTwoSortedLists_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00021_MergeTwoSortedLists_Data))]
        public void MergeTwoLists0(int[] list1, int[] list2, int[] expected)
        {
            //// Arrange
            //ListNode[]? l0 = RftListNodesBuilder.RftCreateListOfNodes(list1);
            //ListNode[]? l1 = RftListNodesBuilder.RftCreateListOfNodes(list2);

            //// Act
            //ListNode? ln = _00021_MergeTwoSortedLists.MergeTwoLists0(l0?[0], l1?[0]);

            //// Assert
            //if (ln is null) Assert.Equal(expected, []);
            //else
            //{
            //    List<int> r = [];
            //    RftReadListOfListNodes(ln);

            //    void RftReadListOfListNodes(ListNode? ln)
            //    {
            //        r.Add(ln!.val);
            //        ln = ln?.next;
            //        if (ln is not null) RftReadListOfListNodes(ln);
            //    }

            //    int[] actual = [.. r];

            //    Assert.Equal(expected, actual);
            //}
        }
    }
}
