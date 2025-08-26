using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00205_IsomorphicStrings_Test
    {
        // Arrange
        private static readonly string a0 = "egg";
        private static readonly string a1 = "add";
        private static readonly bool ar = true;

        private static readonly string b0 = "foo";
        private static readonly string b1 = "bar";
        private static readonly bool br = false;

        private static readonly string c0 = "paper";
        private static readonly string c1 = "title";
        private static readonly bool cr = true;

        public static TheoryData<string, string, bool> _00205_IsomorphicStrings_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_00205_IsomorphicStrings_Data))]
        public void IsIsomorphic0(string s, string t, bool expected)
        {
            // Act
            bool actual = _00205_IsomorphicStrings.IsIsomorphic0(s, t);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
