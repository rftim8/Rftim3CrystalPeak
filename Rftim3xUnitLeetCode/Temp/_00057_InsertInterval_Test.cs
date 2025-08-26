using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00057_InsertInterval_Test
    {
        // Arrange
        private static readonly int[][] a0 = [];
        private static readonly int[] a1 = [];
        private static readonly int[][] ar = [];

        public static TheoryData<int[][], int[], int[][]> _00057_InsertInterval_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00057_InsertInterval_Data))]
        public void InsertInterval0(int[][] a0, int[] a1, int[][] expected)
        {
            // Act
            int[][] actual = _00057_InsertInterval.InsertInterval0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}