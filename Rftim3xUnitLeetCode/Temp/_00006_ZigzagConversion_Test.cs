using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00006_ZigzagConversion_Test
    {
        // Arrange
        private static readonly string a0 = "PAYPALISHIRING";
        private static readonly int a1 = 3;
        private static readonly string ar = "PAHNAPLSIIGYIR";

        private static readonly string b0 = "PAYPALISHIRING";
        private static readonly int b1 = 4;
        private static readonly string br = "PINALSIGYAHRPI";

        private static readonly string c0 = "A";
        private static readonly int c1 = 1;
        private static readonly string cr = "A";

        public static TheoryData<string, int, string> _00006_ZigzagConversion_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00006_ZigzagConversion_Data))]
        public void ZigzagConversion0(string a0, int a1, string expected)
        {
            // Act
            string actual = _00006_ZigzagConversion.ZigzagConversion0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00006_ZigzagConversion_Data))]
        public void ZigzagConversion1(string a0, int a1, string expected)
        {
            // Act
            string actual = _00006_ZigzagConversion.ZigzagConversion1(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
