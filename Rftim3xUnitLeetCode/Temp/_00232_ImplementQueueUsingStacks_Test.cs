using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00232_ImplementQueueUsingStacks_Test
    {
        // Arrange
        private static readonly List<string> a0 = ["push", "push", "peek", "pop", "empty"];
        private static readonly List<int?> a1 = [1, 2, null, null];
        private static readonly List<object?> ar = [null, null, 1, 1, false];

        public static TheoryData<List<string>, List<int?>, List<object?>> _00232_ImplementQueueUsingStacks_Data =>
            new()
            {
                { a0, a1, ar }
            };

        [Theory]
        [MemberData(nameof(_00232_ImplementQueueUsingStacks_Data))]
        public void ImplementQueueUsingStacks0(List<string> a, List<int?> b, List<object?> expected)
        {
            // Act
            List<object?> actual = _00232_ImplementQueueUsingStacks.ImplementQueueUsingStacks0(a, b);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
