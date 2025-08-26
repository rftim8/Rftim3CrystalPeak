using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00263_UglyNumber_Test
    {
        // Arrange
        private static readonly int a0 = 6;
        private static readonly bool ar = true;

        private static readonly int b0 = 1;
        private static readonly bool br = true;

        private static readonly int c0 = 14;
        private static readonly bool cr = false;

        public static TheoryData<int, bool> _00263_UglyNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00263_UglyNumber_Data))]
        public void IsUgly0(int n, bool expected)
        {
            // Act
            bool actual = _00263_UglyNumber.IsUgly0(n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
