using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00059_SpiralMatrixII_Test
    {
        // Arrange
        private static readonly int a0 = 0;
        private static readonly int[][] ar = [];

        public static TheoryData<int, int[][]> _00059_SpiralMatrixII_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00059_SpiralMatrixII_Data))]
        public void SpiralMatrixII0(int a0, int[][] expected)
        {
            // Act
            int[][] actual = _00059_SpiralMatrixII.SpiralMatrixII0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}