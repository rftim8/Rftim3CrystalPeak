using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00225_ImplementStackUsingQueues_Test
    {
        // Arrange
        private static readonly List<string> a0 = ["push", "push", "top", "pop", "empty"];
        private static readonly List<int?> a1 = [1, 2, null, null];
        private static readonly List<object?> ar = [null, null, 2, 2, false];

        public static TheoryData<List<string>, List<int?>, List<object?>> _00225_ImplementStackUsingQueues_Data =>
            new()
            {
                { a0, a1, ar }
            };

        [Theory]
        [MemberData(nameof(_00225_ImplementStackUsingQueues_Data))]
        public void ImplementStackUsingQueues0(List<string> a, List<int?> b, List<object?> expected)
        {
            // Act
            List<object?> actual = _00225_ImplementStackUsingQueues.ImplementStackUsingQueues0(a, b);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00225_ImplementStackUsingQueues_Data))]
        public void ImplementStackUsingQueues1(List<string> a, List<int?> b, List<object?> expected)
        {
            // Act
            List<object?> actual = _00225_ImplementStackUsingQueues.ImplementStackUsingQueues1(a, b);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
