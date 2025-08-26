using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00482_LicenseKeyFormatting_Test
    {
        // Arrange
        private static readonly string a0 = "5F3Z-2e-9-w";
        private static readonly int a1 = 4;
        private static readonly string ar = "5F3Z-2E9W";

        private static readonly string b0 = "2-5g-3-J";
        private static readonly int b1 = 2;
        private static readonly string br = "2-5G-3J";

        public static TheoryData<string, int, string> _00482_LicenseKeyFormatting_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br }
            };

        [Theory]
        [MemberData(nameof(_00482_LicenseKeyFormatting_Data))]
        public void LicenseKeyFormatting0(string s, int k, string expected)
        {
            // Act
            string actual = _00482_LicenseKeyFormatting.LicenseKeyFormatting0(s, k);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00482_LicenseKeyFormatting_Data))]
        public void LicenseKeyFormatting1(string s, int k, string expected)
        {
            // Act
            string actual = _00482_LicenseKeyFormatting.LicenseKeyFormatting1(s, k);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
