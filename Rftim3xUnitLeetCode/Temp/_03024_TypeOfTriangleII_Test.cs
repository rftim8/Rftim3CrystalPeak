using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03024_TypeOfTriangleII_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03024_TypeOfTriangleII_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03024_TypeOfTriangleII_Data))]
        public void TypeOfTriangleII0(int[] a0, int expected)
        {
            // Act
            int actual = _03024_TypeOfTriangleII.TypeOfTriangleII0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}