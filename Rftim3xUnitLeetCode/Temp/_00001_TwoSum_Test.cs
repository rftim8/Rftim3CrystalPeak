using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00001_TwoSum_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 7, 11, 15];
        private static readonly int a1 = 9;
        private static readonly int[] ar = [0, 1];

        private static readonly int[] b0 = [3, 2, 4];
        private static readonly int b1 = 6;
        private static readonly int[] br = [1, 2];

        private static readonly int[] c0 = [3, 3];
        private static readonly int c1 = 6;
        private static readonly int[] cr = [0, 1];

        public static TheoryData<int[], int, int[]> _00001_TwoSum_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };


        [Theory]
        [MemberData(nameof(_00001_TwoSum_Data))]
        public void TwoSum0(int[] a0, int a1, int[] expected)
        {
            // Act
            int[] actual = _00001_TwoSum.TwoSum0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}