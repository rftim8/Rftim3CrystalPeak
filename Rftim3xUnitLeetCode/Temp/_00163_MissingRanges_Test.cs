using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00163_MissingRanges_Test
    {
        // Arrange
        private static readonly int[] a0 = [0, 1, 3, 50, 75];
        private static readonly int a1 = 0;
        private static readonly int a2 = 99;
        private static readonly List<IList<int>> ar = [[2, 2], [4, 49], [51, 74], [76, 99]];

        private static readonly int[] b0 = [-1];
        private static readonly int b1 = -1;
        private static readonly int b2 = -1;
        private static readonly List<IList<int>> br = [];

        public static TheoryData<int[], int, int, List<IList<int>>> _00163_MissingRanges_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br }
            };

        [Theory]
        [MemberData(nameof(_00163_MissingRanges_Data))]
        public void FindMissingRanges0(int[] a0, int a1, int a2, List<IList<int>> expected)
        {
            // Act
            List<IList<int>> actual = _00163_MissingRanges.FindMissingRanges0(a0, a1, a2);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00163_MissingRanges_Data))]
        public void FindMissingRanges1(int[] a0, int a1, int a2, List<IList<int>> expected)
        {
            // Act
            List<IList<int>> actual = _00163_MissingRanges.FindMissingRanges1(a0, a1, a2);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
