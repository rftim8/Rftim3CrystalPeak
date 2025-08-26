using Rftim3Convoy.Temp.Construct.ListNodes;
using Rftim3LeetCode.Temp;
using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00708_InsertIntoASortedCircularLinkedList_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 4, 1];
        private static readonly int a1 = 2;
        private static readonly List<int?> ar = [3, 4, 1, 2];

        private static readonly int[] b0 = [];
        private static readonly int b1 = 1;
        private static readonly List<int?> br = [];

        private static readonly int[] c0 = [1];
        private static readonly int c1 = 0;
        private static readonly List<int?> cr = [1, 0];

        public static TheoryData<int[], int, List<int?>> _00708_InsertIntoASortedCircularLinkedList_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00708_InsertIntoASortedCircularLinkedList_Data))]
        public void InsertIntoASortedCircularLinkedList0(int[] a0, int a1, List<int?> expected)
        {
            // Arrange
            Node0? n = RftListNodesBuilder.RftCreateCircularArrayFromNodes(a0);
            Node0? ar = _00708_InsertIntoASortedCircularLinkedList.InsertIntoASortedCircularLinkedList0(n, a1);

            // Act
            List<int?> actual = [];
            Node0? heada = n is not null ? n!.next : null;
            if (n is not null) actual.Add(n!.val);
            while (heada != n)
            {
                actual.Add(heada!.val);
                heada = heada.next;
            }

            // Assert
            Assert.Equivalent(expected, actual);
        }
    }
}