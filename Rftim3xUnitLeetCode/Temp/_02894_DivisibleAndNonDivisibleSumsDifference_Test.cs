namespace Rftim3xUnitLeetCode.Temp
{
    public class _02894_DivisibleAndNonDivisibleSumsDifference_Test
    {
        // Arrange
        private static readonly int a0 = 10, a1 = 3, ar = 19;
        private static readonly int b0 = 5, b1 = 6, br = 15;
        private static readonly int c0 = 5, c1 = 1, cr = -15;

        public static TheoryData<int, int, int> _02894_DivisibleAndNonDivisibleSumsDifference_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_02894_DivisibleAndNonDivisibleSumsDifference_Data))]
        public void DifferenceOfSums0(int a0, int a1, int expected)
        {
            // Act
            //int actual = _02894_DivisibleAndNonDivisibleSumsDifference.DifferenceOfSums0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02894_DivisibleAndNonDivisibleSumsDifference_Data))]
        public void DifferenceOfSums1(int a0, int a1, int expected)
        {
            // Act
            //int actual = _02894_DivisibleAndNonDivisibleSumsDifference.DifferenceOfSums1(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
