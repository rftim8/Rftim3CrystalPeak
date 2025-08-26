namespace Rftim3xUnitLeetCode.Temp
{
    public class _01860_IncrementalMemoryLeak_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _01860_IncrementalMemoryLeak_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_01860_IncrementalMemoryLeak_Data))]
        public void IncrementalMemoryLeak0(int[] a0, int expected)
        {
            // Act
            //int actual = _01860_IncrementalMemoryLeak.IncrementalMemoryLeak0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}