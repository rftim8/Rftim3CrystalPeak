using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00359_LoggerRateLimiter_Test
    {
        // Arrange
        private static readonly List<string> a0 = [];
        private static readonly List<object?[]> a1 = [];
        private static readonly List<bool?> ar = [];

        public static TheoryData<List<string>, List<object?[]>, List<bool?>> _00359_LoggerRateLimiter_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00359_LoggerRateLimiter_Data))]
        public void LoggerRateLimiter0(List<string> a0, List<object?[]> a1, List<bool?> expected)
        {
            // Act
            List<bool?> actual = _00359_LoggerRateLimiter.LoggerRateLimiter0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}