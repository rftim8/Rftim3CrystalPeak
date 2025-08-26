using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00303_RangeSumQueryImmutable_Test
    {
        // Arrange
        private static readonly List<string> a0 = ["NumArray", "sumRange", "sumRange", "sumRange"];
        private static readonly IList<IList<int>> a1 = [[-2, 0, 3, -5, 2, -1], [0, 2], [2, 5], [0, 5]];
        private static readonly List<object?> ar = [null, 1, -1, -3];

        public static TheoryData<List<string>, IList<IList<int>>, List<object?>> _00303_RangeSumQueryImmutable_Data =>
            new()
            {
                { a0, a1, ar }
            };

        [Theory]
        [MemberData(nameof(_00303_RangeSumQueryImmutable_Data))]
        public void RangeSumQueryImmutable0(List<string> a, IList<IList<int>> b, List<object?> expected)
        {
            // Act
            List<object?> actual = _00303_RangeSumQueryImmutable.RangeSumQueryImmutable0(a, b);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
