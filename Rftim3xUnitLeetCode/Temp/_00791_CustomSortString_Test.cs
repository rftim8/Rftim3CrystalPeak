using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00791_CustomSortString_Test
    {
        // Arrange
        private static readonly string a0 = "cba", a1 = "abcd", ar = "cbad";

        private static readonly string b0 = "bcafg", b1 = "abcd", br = "bcad";

        public static TheoryData<string, string, string> _00791_CustomSortString_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
            };


        [Theory]
        [MemberData(nameof(_00791_CustomSortString_Data))]
        public void CustomSortString0(string a0, string a1, string expected)
        {
            // Act
            string actual = _00791_CustomSortString.CustomSortString0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00791_CustomSortString_Data))]
        public void CustomSortString1(string a0, string a1, string expected)
        {
            // Act
            string actual = _00791_CustomSortString.CustomSortString1(a0, a1);

            // Assert
            Assert.Equivalent(expected.ToCharArray(), actual.ToCharArray(), true);
        }
    }
}