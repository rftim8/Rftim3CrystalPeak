namespace Rftim3xUnitLeetCode.Temp
{
    public class _00487_MaxConsecutiveOnesII_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 0, 1, 1, 0];
        private static readonly int ar = 4;

        private static readonly int[] b0 = [1, 0, 1, 1, 0, 1];
        private static readonly int br = 4;

        public static TheoryData<int[], int> _00487_MaxConsecutiveOnesII_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00487_MaxConsecutiveOnesII_Data))]
        public void FindMaxConsecutiveOnes0(int[] a0, int expected)
        {
            // Act
            //int actual = _00487_MaxConsecutiveOnesII.FindMaxConsecutiveOnes0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00487_MaxConsecutiveOnesII_Data))]
        public void FindMaxConsecutiveOnes1(int[] a0, int expected)
        {
            // Act
            //int actual = _00487_MaxConsecutiveOnesII.FindMaxConsecutiveOnes1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00487_MaxConsecutiveOnesII_Data))]
        public void FindMaxConsecutiveOnes2(int[] a0, int expected)
        {
            // Act
            //int actual = _00487_MaxConsecutiveOnesII.FindMaxConsecutiveOnes2(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
