using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00202_HappyNumber_Test
    {
        // Arrange
        private static readonly int a0 = 19;
        private static readonly bool ar = true;

        private static readonly int b0 = 2;
        private static readonly bool br = false;

        public static TheoryData<int, bool> _00202_HappyNumber_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00202_HappyNumber_Data))]
        public void IsHappy0(int n, bool expected)
        {
            // Act
            bool actual = _00202_HappyNumber.IsHappy0(n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
