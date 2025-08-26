using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00292_NimGame_Test
    {
        // Arrange
        private static readonly int a0 = 4;
        private static readonly bool ar = false;

        private static readonly int b0 = 1;
        private static readonly bool br = true;

        private static readonly int c0 = 2;
        private static readonly bool cr = true;

        public static TheoryData<int, bool> _00292_NimGame_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00292_NimGame_Data))]
        public void CanWinNim0(int n, bool expected)
        {
            // Act
            bool actual = _00292_NimGame.CanWinNim0(n);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00292_NimGame_Data))]
        public void CanWinNim1(int n, bool expected)
        {
            // Act
            bool actual = _00292_NimGame.CanWinNim1(n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
