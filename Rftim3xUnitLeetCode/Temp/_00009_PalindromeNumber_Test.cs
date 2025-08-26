using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00009_PalindromeNumber_Test
    {
        // Arrange
        private static readonly int a0 = 121;
        private static readonly bool ar = true;

        private static readonly int b0 = -121;
        private static readonly bool br = false;

        private static readonly int c0 = 10;
        private static readonly bool cr = false;

        public static TheoryData<int, bool> _00009_PalindromeNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00009_PalindromeNumber_Data))]
        public void PalindromeNumber0(int x, bool expected)
        {
            // Act
            bool actual = _00009_PalindromeNumber.PalindromeNumber0(x);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00009_PalindromeNumber_Data))]
        public void PalindromeNumber1(int x, bool expected)
        {
            // Act
            bool actual = _00009_PalindromeNumber.PalindromeNumber1(x);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
