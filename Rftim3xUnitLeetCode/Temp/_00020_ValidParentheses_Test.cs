using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00020_ValidParentheses_Test
    {
        // Arrange
        private static readonly string a0 = "()";
        private static readonly bool ar = true;

        private static readonly string b0 = "()[]{}";
        private static readonly bool br = true;

        private static readonly string c0 = "(]";
        private static readonly bool cr = false;

        private static readonly string d0 = "((([])))";
        private static readonly bool dr = true;

        private static readonly string e0 = "({{([()(])}})";
        private static readonly bool er = false;

        public static TheoryData<string, bool> _00020_ValidParentheses_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr },
                { d0, dr },
                { e0, er }
            };

        [Theory]
        [MemberData(nameof(_00020_ValidParentheses_Data))]
        public void ValidParentheses0(string s, bool expected)
        {
            // Act
            bool actual = _00020_ValidParentheses.ValidParentheses0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
