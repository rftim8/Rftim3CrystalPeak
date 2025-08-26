namespace Rftim3xUnitLeetCode.Temp
{
    public class _00008_StringToIntegerAtoi_Test
    {
        // Arrange
        private static readonly string a0 = "42";
        private static readonly int ar = 42;

        private static readonly string b0 = "   -42";
        private static readonly int br = -42;

        private static readonly string c0 = "4193 with words";
        private static readonly int cr = 4193;

        public static TheoryData<string, int> _00008_StringToIntegerAtoi_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00008_StringToIntegerAtoi_Data))]
        public void StringToIntegerAtoi0(string a0, int expected)
        {
            // Act
            //int actual = _00008_StringToIntegerAtoi.StringToIntegerAtoi0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00008_StringToIntegerAtoi_Data))]
        public void StringToIntegerAtoi1(string a0, int expected)
        {
            // Act
            //int actual = _00008_StringToIntegerAtoi.StringToIntegerAtoi1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}