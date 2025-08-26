using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01155_NumberOfDiceRollsWithTargetSum_Test
    {
        // Arrange
        private static readonly int a0 = 1, a1 = 6, a2 = 3, ar = 1;
        private static readonly int b0 = 2, b1 = 6, b2 = 7, br = 6;
        private static readonly int c0 = 30, c1 = 30, c2 = 500, cr = 222616187;

        public static TheoryData<int, int, int, int> Assert0_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br },
                { c0, c1, c2, cr }
            };

        [Theory]
        [MemberData(nameof(Assert0_Data))]
        public void NumRollsToTarget0(int a0, int a1, int a2, int expected)
        {
            // Act
            int actual = _01155_NumberOfDiceRollsWithTargetSum.NumRollsToTarget0(a0, a1, a2);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
