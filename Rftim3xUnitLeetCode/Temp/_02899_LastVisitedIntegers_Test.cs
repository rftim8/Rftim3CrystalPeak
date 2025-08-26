using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02899_LastVisitedIntegers_Test
    {
        // Arrange
        private static readonly IList<string> a0 = ["1", "2", "prev", "prev", "prev"];
        private static readonly IList<int> ar = [2, 1, -1];

        private static readonly IList<string> b0 = ["1", "prev", "2", "prev", "prev"];
        private static readonly IList<int> br = [1, 2, 1];

        public static TheoryData<IList<string>, IList<int>> _02899_LastVisitedIntegers_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02899_LastVisitedIntegers_Data))]
        public void LastVisitedIntegers0(IList<string> a0, IList<int> expected)
        {
            // Act
            IList<int> actual = _02899_LastVisitedIntegers.LastVisitedIntegers0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
