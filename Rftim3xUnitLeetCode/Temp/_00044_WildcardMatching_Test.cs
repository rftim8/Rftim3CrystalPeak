using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00044_WildcardMatching_Test
    {
        // Arrange
        private static readonly string a0 = "";
        private static readonly string a1 = "";
        private static readonly bool ar = true;

        public static TheoryData<string, string, bool> _00044_WildcardMatching_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00044_WildcardMatching_Data))]
        public void WildcardMatching0(string a0, string a1, bool expected)
        {
            // Act
            bool actual = _00044_WildcardMatching.WildcardMatching0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}