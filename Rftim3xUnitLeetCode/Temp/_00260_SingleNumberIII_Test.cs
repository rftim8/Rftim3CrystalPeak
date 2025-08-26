using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00260_SingleNumberIII_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 1, 3, 2, 5];
        private static readonly int[] ar = [3, 5];

        private static readonly int[] b0 = [-1, 0];
        private static readonly int[] br = [-1, 0];

        private static readonly int[] c0 = [0, 1];
        private static readonly int[] cr = [1, 0];

        public static TheoryData<int[], int[]> _00260_SingleNumberIII_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00260_SingleNumberIII_Data))]
        public void SingleNumberIII0(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00260_SingleNumberIII.SingleNumberIII0(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_00260_SingleNumberIII_Data))]
        public void SingleNumberIII1(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00260_SingleNumberIII.SingleNumberIII1(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_00260_SingleNumberIII_Data))]
        public void SingleNumberIII2(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00260_SingleNumberIII.SingleNumberIII2(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}