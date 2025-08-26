using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00119_PascalsTriangle2_Test
    {
        // Arrange
        private static readonly int a0 = 3;
        private static readonly int[] ar = [1, 3, 3, 1];

        private static readonly int b0 = 0;
        private static readonly int[] br = [1];

        private static readonly int c0 = 1;
        private static readonly int[] cr = [1, 1];

        public static TheoryData<int, int[]> _00119_PascalsTriangle2_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00119_PascalsTriangle2_Data))]
        public void GetRow0(int a0, IList<int> expected)
        {
            // Act
            IList<int> actual = _00119_PascalsTriangle2.GetRow0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00119_PascalsTriangle2_Data))]
        public void GetRow1(int rowIndex, IList<int> expected)
        {
            // Act
            IList<int> actual = _00119_PascalsTriangle2.GetRow1(rowIndex);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
