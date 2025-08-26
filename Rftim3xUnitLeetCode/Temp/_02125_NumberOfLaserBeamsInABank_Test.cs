using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02125_NumberOfLaserBeamsInABank_Test
    {
        // Arrange
        private static readonly string[] a0 = ["011001", "000000", "010100", "001000"];
        private static readonly int ar = 8;

        private static readonly string[] b0 = ["000", "111", "000"];
        private static readonly int br = 0;

        public static TheoryData<string[], int> Assert0_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void NumberOfBeams0(string[] a0, int expected)
        {
            // Act
            int actual = _02125_NumberOfLaserBeamsInABank.NumberOfBeams0(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void NumberOfBeams1(string[] a0, int expected)
        {
            // Act
            int actual = _02125_NumberOfLaserBeamsInABank.NumberOfBeams1(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
