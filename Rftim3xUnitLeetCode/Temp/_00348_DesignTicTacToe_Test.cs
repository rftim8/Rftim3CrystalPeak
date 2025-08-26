using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00348_DesignTicTacToe_Test
    {
        // Arrange
        private static readonly string[] a0 = ["TicTacToe", "move", "move", "move", "move", "move", "move", "move"];
        private static readonly int[][] a1 = [[3], [0, 0, 1], [0, 2, 2], [2, 2, 1], [1, 1, 2], [2, 0, 1], [1, 0, 2], [2, 1, 1]];
        private static readonly List<object?> ar = [null, 0, 0, 0, 0, 0, 0, 1];

        public static TheoryData<string[], int[][], List<object?>> _00348_DesignTicTacToe_Data =>
            new()
            {
                { a0, a1, ar }
            };

        [Theory]
        [MemberData(nameof(_00348_DesignTicTacToe_Data))]
        public void DesignTicTacToe0(string[] a0, int[][] a1, List<object?> expected)
        {
            // Act
            List<object?> actual = _00348_DesignTicTacToe.DesignTicTacToe0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00348_DesignTicTacToe_Data))]
        public void DesignTicTacToe1(string[] a0, int[][] a1, List<object?> expected)
        {
            // Act
            List<object?> actual = _00348_DesignTicTacToe.DesignTicTacToe1(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00348_DesignTicTacToe_Data))]
        public void DesignTicTacToe2(string[] a0, int[][] a1, List<object?> expected)
        {
            // Act
            List<object?> actual = _00348_DesignTicTacToe.DesignTicTacToe2(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
