namespace Rftim3xUnitLeetCode.Temp
{
    public class _00036_ValidSudoku_Test
    {
        // Arrange
        private static readonly char[][] a0 = [];
        private static readonly bool ar = true;

        public static TheoryData<char[][], bool> _00036_ValidSudoku_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00036_ValidSudoku_Data))]
        public void ValidSudoku0(char[][] a0, bool expected)
        {
            // Act
            //bool actual = _00036_ValidSudoku.ValidSudoku0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}