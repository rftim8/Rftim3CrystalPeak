namespace Rftim3xUnitLeetCode.Temp
{
    public class _01759_CountNumberOfHomogenousSubstrings_Test
    {
        // Arrange
        private static readonly string a0 = "abbcccaa";
        private static readonly int ar = 13;

        private static readonly string b0 = "xy";
        private static readonly int br = 2;

        private static readonly string c0 = "zzzzz";
        private static readonly int cr = 15;

        public static TheoryData<string, int> _01759_CountNumberOfHomogenousSubstrings_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01759_CountNumberOfHomogenousSubstrings_Data))]
        public void CountHomogenous0(string s, int expected)
        {
            // Act
            //int actual = _01759_CountNumberOfHomogenousSubstrings.CountHomogenous0(s);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
