using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00367_ValidPerfectSquare_Test
    {
        // Arrange
        private static readonly int a0 = 16;
        private static readonly bool ar = true;

        private static readonly int b0 = 14;
        private static readonly bool br = false;

        public static TheoryData<int, bool> _00367_ValidPerfectSquare_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00367_ValidPerfectSquare_Data))]
        public void IsPerfectSquare0(int num, bool expected)
        {
            // Act
            bool actual = _00367_ValidPerfectSquare.IsPerfectSquare0(num);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
