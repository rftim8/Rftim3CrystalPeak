using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00338_CountingBits_Test
    {
        // Arrange
        private static readonly int a0 = 2;
        private static readonly int[] ar = [0, 1, 1];

        private static readonly int b0 = 5;
        private static readonly int[] br = [0, 1, 1, 2, 1, 2];

        public static TheoryData<int, int[]> _00338_CountingBits_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00338_CountingBits_Data))]
        public void CountBits0(int n, int[] expected)
        {
            // Act
            int[] actual = _00338_CountingBits.CountBits0(n);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00338_CountingBits_Data))]
        public void CountBits1(int n, int[] expected)
        {
            // Act
            int[] actual = _00338_CountingBits.CountBits1(n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
