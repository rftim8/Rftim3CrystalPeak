using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00246_StrobogrammaticNumber_Test
    {
        // Arrange
        private static readonly string a0 = "69";
        private static readonly bool ar = true;

        private static readonly string b0 = "88";
        private static readonly bool br = true;

        private static readonly string c0 = "962";
        private static readonly bool cr = false;

        public static TheoryData<string, bool> _00246_StrobogrammaticNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00246_StrobogrammaticNumber_Data))]
        public void StrobogrammaticNumber0(string a0, bool expected)
        {
            // Act
            bool actual = _00246_StrobogrammaticNumber.StrobogrammaticNumber0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}