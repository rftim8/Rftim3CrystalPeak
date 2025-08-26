using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00012_IntegerToRoman_Test
    {
        // Arrange
        private static readonly int a0 = 3;
        private static readonly string ar = "III";

        private static readonly int b0 = 58;
        private static readonly string br = "LVIII";

        private static readonly int c0 = 1994;
        private static readonly string cr = "MCMXCIV";

        public static TheoryData<int, string> _00012_IntegerToRoman_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00012_IntegerToRoman_Data))]
        public void IntegerToRoman0(int a0, string expected)
        {
            // Act
            string actual = _00012_IntegerToRoman.IntegerToRoman0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}