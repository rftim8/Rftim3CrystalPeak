namespace Rftim3xUnitLeetCode.Temp
{
    public class _02623_Memoize_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _02623_Memoize_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_02623_Memoize_Data))]
        public void Memoize0(int[] a0, int expected)
        {
            // Act
            //int actual = _02623_Memoize.Memoize0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}