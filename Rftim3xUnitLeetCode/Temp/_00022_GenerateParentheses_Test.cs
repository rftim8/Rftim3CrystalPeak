using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00022_GenerateParentheses_Test
    {
        // Arrange
        private static readonly int a0 = 3;
        private static readonly List<string> ar = ["((()))", "(()())", "(())()", "()(())", "()()()"];

        private static readonly int b0 = 1;
        private static readonly List<string> br = ["()"];

        public static TheoryData<int, List<string>> _00022_GenerateParentheses_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00022_GenerateParentheses_Data))]
        public void GenerateParentheses0(int a0, List<string> expected)
        {
            // Act
            IList<string> actual = _00022_GenerateParentheses.GenerateParenthesis0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00022_GenerateParentheses_Data))]
        public void GenerateParentheses1(int a0, List<string> expected)
        {
            // Act
            IList<string> actual = _00022_GenerateParentheses.GenerateParenthesis1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}