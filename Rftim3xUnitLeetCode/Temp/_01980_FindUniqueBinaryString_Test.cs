using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01980_FindUniqueBinaryString_Test
    {
        // Arrange
        private static readonly string[] a0 = ["01", "10"];
        private static readonly List<string> ar = ["00", "11"];

        private static readonly string[] b0 = ["00", "01"];
        private static readonly List<string> br = ["10"];

        private static readonly string[] c0 = ["111", "011", "001"];
        private static readonly List<string> cr = ["000"];

        public static TheoryData<string[], List<string>> _01980_FindUniqueBinaryString_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_01980_FindUniqueBinaryString_Data))]
        public void FindDifferentBinaryString0(string[] a0, List<string> expected)
        {
            // Act
            string actual = _01980_FindUniqueBinaryString.FindDifferentBinaryString0(a0);

            // Assert
            Assert.Contains(actual, expected);
        }

        [Theory]
        [MemberData(nameof(_01980_FindUniqueBinaryString_Data))]
        public void FindDifferentBinaryString1(string[] a0, List<string> expected)
        {
            // Act
            string actual = _01980_FindUniqueBinaryString.FindDifferentBinaryString1(a0);

            // Assert
            Assert.Contains(actual, expected);
        }
    }
}
