using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01578_MinimumTimeToMakeRopeColorful_Test
    {
        // Arrange
        private static readonly string a0 = "abaac";
        private static readonly int[] a1 = [1, 2, 3, 4, 5];
        private static readonly int ar = 3;

        private static readonly string b0 = "abc";
        private static readonly int[] b1 = [1, 2, 3];
        private static readonly int br = 0;

        private static readonly string c0 = "aabaa";
        private static readonly int[] c1 = [1, 2, 3, 4, 1];
        private static readonly int cr = 2;

        private static readonly string d0 = "cddcdcae";
        private static readonly int[] d1 = [4, 8, 8, 4, 4, 5, 4, 2];
        private static readonly int dr = 8;

        private static readonly string e0 = "bbbaaa";
        private static readonly int[] e1 = [4, 9, 3, 8, 8, 9];
        private static readonly int er = 23;

        public static TheoryData<string, int[], int> Assert0_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr },
                { d0, d1, dr },
                { e0, e1, er }
            };

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void MinCost0(string a0, int[] a1, int expected)
        {
            // Act
            int actual = _01578_MinimumTimeToMakeRopeColorful.MinCost0(a0, a1);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void MinCost1(string a0, int[] a1, int expected)
        {
            // Act
            int actual = _01578_MinimumTimeToMakeRopeColorful.MinCost1(a0, a1);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
