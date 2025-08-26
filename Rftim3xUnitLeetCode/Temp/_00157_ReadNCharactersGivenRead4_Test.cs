using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00157_ReadNCharactersGivenRead4_Test
    {
        // Arrange
        private static readonly char[] a0 = [.. "abc"];
        private static readonly int a1 = 4, ar = 3;

        private static readonly char[] b0 = [.. "abcde"];
        private static readonly int b1 = 5, br = 5;

        private static readonly char[] c0 = [.. "abcdABCD1234"];
        private static readonly int c1 = 12, cr = 12;

        public static TheoryData<char[], int, int> _00157_ReadNCharactersGivenRead4_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };


        [Theory]
        [MemberData(nameof(_00157_ReadNCharactersGivenRead4_Data))]
        public void ReadNCharactersGivenRead40(char[] a0, int a1, int expected)
        {
            // Act
            int actual = _00157_ReadNCharactersGivenRead4.ReadNCharactersGivenRead40(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}