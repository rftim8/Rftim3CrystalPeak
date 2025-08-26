using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00043_MultiplyStrings_Test
    {
        // Arrange
        private static readonly string a0 = "";
        private static readonly string a1 = "";
        private static readonly string ar = "";

        public static TheoryData<string, string, string> _00043_MultiplyStrings_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00043_MultiplyStrings_Data))]
        public void MultiplyStrings0(string a0, string a1, string expected)
        {
            // Act
            string actual = _00043_MultiplyStrings.MultiplyStrings0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}