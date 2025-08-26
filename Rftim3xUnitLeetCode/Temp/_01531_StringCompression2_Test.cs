using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01531_StringCompression2_Test
    {
        // Arrange
        private static readonly string a0 = "aaabcccd";
        private static readonly int a1 = 2;
        private static readonly int ar = 4;

        private static readonly string b0 = "aabbaa";
        private static readonly int b1 = 2;
        private static readonly int br = 2;

        private static readonly string c0 = "aaaaaaaaaaa";
        private static readonly int c1 = 0;
        private static readonly int cr = 3;

        public static TheoryData<string, int, int> Assert0_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void GetLengthOfOptimalCompression0(string a0, int a1, int expected)
        {
            // Act
            int actual = _01531_StringCompression2.GetLengthOfOptimalCompression0(a0, a1);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
