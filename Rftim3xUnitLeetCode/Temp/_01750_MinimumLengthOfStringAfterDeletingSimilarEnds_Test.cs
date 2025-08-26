using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01750_MinimumLengthOfStringAfterDeletingSimilarEnds_Test
    {
        // Arrange
        private static readonly string a0 = "ca";
        private static readonly int ar = 2;

        private static readonly string b0 = "cabaabac";
        private static readonly int br = 0;

        private static readonly string c0 = "aabccabba";
        private static readonly int cr = 3;

        private static readonly string d0 = "abbbbbbbbbbbbbbbbbbba";
        private static readonly int dr = 0;

        private static readonly string e0 = "bbbbbbbbbbbbbbbbbbbbbbbbbbbabbbbbbbbbbbbbbbccbcbcbccbbabbb";
        private static readonly int er = 1;

        public static TheoryData<string, int> _01750_MinimumLengthOfStringAfterDeletingSimilarEnds_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr },
                { d0, dr },
                { e0, er }
            };


        [Theory]
        [MemberData(nameof(_01750_MinimumLengthOfStringAfterDeletingSimilarEnds_Data))]
        public void MinimumLengthOfStringAfterDeletingSimilarEnds0(string a0, int expected)
        {
            // Act
            int actual = _01750_MinimumLengthOfStringAfterDeletingSimilarEnds.MinimumLengthOfStringAfterDeletingSimilarEnds0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01750_MinimumLengthOfStringAfterDeletingSimilarEnds_Data))]
        public void MinimumLengthOfStringAfterDeletingSimilarEnds1(string a0, int expected)
        {
            // Act
            int actual = _01750_MinimumLengthOfStringAfterDeletingSimilarEnds.MinimumLengthOfStringAfterDeletingSimilarEnds1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}