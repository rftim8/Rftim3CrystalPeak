using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00066_PlusOne_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3];
        private static readonly int[] ar = [1, 2, 4];

        private static readonly int[] b0 = [4, 3, 2, 1];
        private static readonly int[] br = [4, 3, 2, 2];

        private static readonly int[] c0 = [9];
        private static readonly int[] cr = [1, 0];

        public static TheoryData<int[], int[]> _00066_PlusOne_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00066_PlusOne_Data))]
        public void PlusOne0(int[] digits, int[] expected)
        {
            // Act
            int[] actual = _00066_PlusOne.PlusOne0(digits);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
