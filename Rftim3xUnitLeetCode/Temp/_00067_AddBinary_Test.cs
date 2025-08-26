using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00067_AddBinary_Test
    {
        // Arrange
        private static readonly string a0 = "11";
        private static readonly string a1 = "1";
        private static readonly string ar = "100";

        private static readonly string b0 = "1010";
        private static readonly string b1 = "1011";
        private static readonly string br = "10101";

        public static TheoryData<string, string, string> _00067_AddBinary_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00067_AddBinary_Data))]
        public void AddBinary0(string a, string b, string expected)
        {
            // Act
            string actual = _00067_AddBinary.AddBinary0(a, b);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
