using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01657_DetermineIfTwoStringsAreClose_Test
    {
        // Arrange
        private static readonly string a0 = "abc";
        private static readonly string a1 = "bca";
        private static readonly bool ar = true;

        private static readonly string b0 = "a";
        private static readonly string b1 = "aa";
        private static readonly bool br = false;

        private static readonly string c0 = "cabbba";
        private static readonly string c1 = "abbccc";
        private static readonly bool cr = true;

        private static readonly string d0 = "uau";
        private static readonly string d1 = "ssx";
        private static readonly bool dr = false;

        public static TheoryData<string, string, bool> _01657_DetermineIfTwoStringsAreClose_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr },
                { d0, d1, dr }
            };

        [Theory]
        [MemberData(nameof(_01657_DetermineIfTwoStringsAreClose_Data))]
        public void CloseStrings0(string a0, string a1, bool expected)
        {
            // Act
            bool actual = _01657_DetermineIfTwoStringsAreClose.CloseStrings0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01657_DetermineIfTwoStringsAreClose_Data))]
        public void CloseStrings1(string a0, string a1, bool expected)
        {
            // Act
            bool actual = _01657_DetermineIfTwoStringsAreClose.CloseStrings1(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
