using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02864_MaximumOddBinaryNumber_Test
    {
        // Arrange
        private static readonly string a0 = "010";
        private static readonly string ar = "001";

        private static readonly string b0 = "0101";
        private static readonly string br = "1001";

        public static TheoryData<string, string> _02864_MaximumOddBinaryNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02864_MaximumOddBinaryNumber_Data))]
        public void MaximumOddBinaryNumber0(string a0, string expected)
        {
            // Act
            string actual = _02864_MaximumOddBinaryNumber.MaximumOddBinaryNumber0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02864_MaximumOddBinaryNumber_Data))]
        public void MaximumOddBinaryNumber1(string a0, string expected)
        {
            // Act
            string actual = _02864_MaximumOddBinaryNumber.MaximumOddBinaryNumber1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
