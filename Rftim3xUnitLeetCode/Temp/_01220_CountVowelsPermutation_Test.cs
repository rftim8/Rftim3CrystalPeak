namespace Rftim3xUnitLeetCode.Temp
{
    public class _01220_CountVowelsPermutation_Test
    {
        // Arrange
        private static readonly int a0 = 1;
        private static readonly int ar = 5;

        private static readonly int b0 = 2;
        private static readonly int br = 10;

        private static readonly int c0 = 5;
        private static readonly int cr = 68;

        public static TheoryData<int, int> _01220_CountVowelsPermutation_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01220_CountVowelsPermutation_Data))]
        public void CountVowelPermutation0(int input, int expected)
        {
            // Act
            //int actual = _01220_CountVowelsPermutation.CountVowelPermutation0(input);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01220_CountVowelsPermutation_Data))]
        public void CountVowelPermutation1(int input, int expected)
        {
            // Act
            //int actual = _01220_CountVowelsPermutation.CountVowelPermutation1(input);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
