namespace Rftim3xUnitLeetCode.Temp
{
    public class _01838_FrequencyOfTheMostFrequentElement_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 4];
        private static readonly int a1 = 5;
        private static readonly int ar = 3;

        private static readonly int[] b0 = [1, 4, 8, 13];
        private static readonly int b1 = 5;
        private static readonly int br = 2;

        private static readonly int[] c0 = [3, 9, 6];
        private static readonly int c1 = 2;
        private static readonly int cr = 1;

        public static TheoryData<int[], int, int> _01838_FrequencyOfTheMostFrequentElement_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_01838_FrequencyOfTheMostFrequentElement_Data))]
        public void MaxFrequency0(int[] a0, int k, int expected)
        {
            // Act
            //int actual = _01838_FrequencyOfTheMostFrequentElement.MaxFrequency0(a0, k);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
