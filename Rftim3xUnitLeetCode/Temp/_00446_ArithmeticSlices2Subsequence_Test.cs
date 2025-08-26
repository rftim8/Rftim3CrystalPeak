namespace Rftim3xUnitLeetCode.Temp
{
    public class _00446_ArithmeticSlices2Subsequence_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 4, 6, 8, 10];
        private static readonly int ar = 7;

        private static readonly int[] b0 = [7, 7, 7, 7, 7];
        private static readonly int br = 16;

        public static TheoryData<int[], int> _00446_ArithmeticSlices2Subsequence_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00446_ArithmeticSlices2Subsequence_Data))]
        public void NumberOfArithmeticSlices0(int[] a0, int expected)
        {
            // Act
            //int actual = _00446_ArithmeticSlices2Subsequence.NumberOfArithmeticSlices0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00446_ArithmeticSlices2Subsequence_Data))]
        public void NumberOfArithmeticSlices1(int[] a0, int expected)
        {
            // Act
            //int actual = _00446_ArithmeticSlices2Subsequence.NumberOfArithmeticSlices1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
