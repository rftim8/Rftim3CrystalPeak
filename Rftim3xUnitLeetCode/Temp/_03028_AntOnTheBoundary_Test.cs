using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03028_AntOnTheBoundary_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03028_AntOnTheBoundary_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03028_AntOnTheBoundary_Data))]
        public void AntOnTheBoundary0(int[] a0, int expected)
        {
            // Act
            int actual = _03028_AntOnTheBoundary.AntOnTheBoundary0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}