namespace Rftim3xUnitLeetCode.Temp
{
    public class _00434_NumberOfSegmentsInAString_Test
    {
        // Arrange
        private static readonly string a0 = "Hello, my name is John";
        private static readonly int ar = 5;

        private static readonly string b0 = "Hello";
        private static readonly int br = 1;

        public static TheoryData<string, int> _00434_NumberOfSegmentsInAString_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00434_NumberOfSegmentsInAString_Data))]
        public void CountSegments0(string s, int expected)
        {
            // Act
            //int actual = _00434_NumberOfSegmentsInAString.CountSegments0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00434_NumberOfSegmentsInAString_Data))]
        public void CountSegments1(string s, int expected)
        {
            // Act
            //int actual = _00434_NumberOfSegmentsInAString.CountSegments1(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
