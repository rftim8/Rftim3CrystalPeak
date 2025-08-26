using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00212_WordSearchII_Test
    {
        // Arrange
        private static readonly char[][] a0 = [['o', 'a', 'a', 'n'], ['e', 't', 'a', 'e'], ['i', 'h', 'k', 'r'], ['i', 'f', 'l', 'v']];
        private static readonly string[] a1 = ["oath", "pea", "eat", "rain"];
        private static readonly List<string> ar = ["eat", "oath"];

        private static readonly char[][] b0 = [['a', 'b'], ['c', 'd']];
        private static readonly string[] b1 = [];
        private static readonly List<string> br = [];

        public static TheoryData<char[][], string[], List<string>> _00212_WordSearchII_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };


        [Theory]
        [MemberData(nameof(_00212_WordSearchII_Data))]
        public void WordSearchII0(char[][] a0, string[] a1, List<string> expected)
        {
            // Act
            List<string> actual = [.. _00212_WordSearchII.WordSearchII0(a0, a1)];

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}