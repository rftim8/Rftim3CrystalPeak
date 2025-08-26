namespace Rftim3xUnitLeetCode.Temp
{
    public class _00037_SudokuSolver_Test
    {
        // Arrange
        private static readonly char[][] a0 = [];
        private static readonly bool ar = true;

        public static TheoryData<char[][], bool> _00037_SudokuSolver_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00037_SudokuSolver_Data))]
        public void SudokuSolver0(char[][] a0, bool expected)
        {
            // Act
            //bool actual = _00037_SudokuSolver.SudokuSolver0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}