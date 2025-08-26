using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00243_ShortestWordDistance_Test
    {
        // Arrange
        private static readonly string[] a0 = ["practice", "makes", "perfect", "coding", "makes"];
        private static readonly string a1 = "coding", a2 = "practice";
        private static readonly int ar = 3;

        private static readonly string[] b0 = ["practice", "makes", "perfect", "coding", "makes"];
        private static readonly string b1 = "makes", b2 = "coding";
        private static readonly int br = 1;

        public static TheoryData<string[], string, string, int> _00243_ShortestWordDistance_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br }
            };


        [Theory]
        [MemberData(nameof(_00243_ShortestWordDistance_Data))]
        public void ShortestWordDistance0(string[] a0, string a1, string a2, int expected)
        {
            // Act
            int actual = _00243_ShortestWordDistance.ShortestWordDistance0(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}