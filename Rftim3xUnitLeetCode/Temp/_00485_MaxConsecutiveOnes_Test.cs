namespace Rftim3xUnitLeetCode.Temp
{
    public class _00485_MaxConsecutiveOnes_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 1, 0, 1, 1, 1];
        private static readonly int ar = 3;

        private static readonly int[] b0 = [1, 0, 1, 1, 0, 1];
        private static readonly int br = 2;

        public static TheoryData<int[], int> _00485_MaxConsecutiveOnes_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00485_MaxConsecutiveOnes_Data))]
        public void FindMaxConsecutiveOnes0(int[] nums, int expected)
        {
            // Act
            //int actual = _00485_MaxConsecutiveOnes.FindMaxConsecutiveOnes0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
