using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00405_ConvertANumberToHexadecimal_Test
    {
        // Arrange
        private static readonly int a0 = 26;
        private static readonly string ar = "1a";

        private static readonly int b0 = -1;
        private static readonly string br = "ffffffff";

        public static TheoryData<int, string> _00405_ConvertANumberToHexadecimal_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00405_ConvertANumberToHexadecimal_Data))]
        public void ToHex0(int num, string expected)
        {
            // Act
            string actual = _00405_ConvertANumberToHexadecimal.ToHex0(num);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00405_ConvertANumberToHexadecimal_Data))]
        public void ToHex1(int num, string expected)
        {
            // Act
            string actual = _00405_ConvertANumberToHexadecimal.ToHex1(num);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00405_ConvertANumberToHexadecimal_Data))]
        public void ToHex2(int num, string expected)
        {
            // Act
            string actual = _00405_ConvertANumberToHexadecimal.ToHex2(num);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00405_ConvertANumberToHexadecimal_Data))]
        public void ToHex3(int num, string expected)
        {
            // Act
            string actual = _00405_ConvertANumberToHexadecimal.ToHex3(num);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
