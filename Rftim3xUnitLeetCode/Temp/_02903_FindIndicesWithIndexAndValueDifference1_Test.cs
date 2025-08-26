using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02903_FindIndicesWithIndexAndValueDifference1_Test
    {
        // Arrange
        private static readonly int[] a0 = [5, 1, 4, 1];
        private static readonly int a1 = 2, a2 = 4;
        private static readonly int[] ar = [0, 3];

        private static readonly int[] b0 = [2, 1];
        private static readonly int b1 = 0, b2 = 0;
        private static readonly int[] br = [0, 0];

        private static readonly int[] c0 = [1, 2, 3];
        private static readonly int c1 = 2, c2 = 4;
        private static readonly int[] cr = [-1, -1];

        public static TheoryData<int[], int, int, int[]> _02903_FindIndicesWithIndexAndValueDifference1_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br },
                { c0, c1, c2, cr }
            };

        [Theory]
        [MemberData(nameof(_02903_FindIndicesWithIndexAndValueDifference1_Data))]
        public void FindIndices0(int[] a0, int a1, int a2, int[] expected)
        {
            // Act
            int[] actual = _02903_FindIndicesWithIndexAndValueDifference1.FindIndices0(a0, a1, a2);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
