using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00228_SummaryRanges_Test
    {
        // Arrange
        private static readonly int[] a0 = [0, 1, 2, 4, 5, 7];
        private static readonly string[] ar = ["0->2", "4->5", "7"];

        private static readonly int[] b0 = [0, 2, 3, 4, 6, 8, 9];
        private static readonly string[] br = ["0", "2->4", "6", "8->9"];

        public static TheoryData<int[], string[]> _00228_SummaryRanges_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00228_SummaryRanges_Data))]
        public void SummaryRanges0(int[] nums, string[] expected)
        {
            // Act
            IList<string> actual = _00228_SummaryRanges.SummaryRanges0(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00228_SummaryRanges_Data))]
        public void SummaryRanges1(int[] nums, string[] expected)
        {
            // Act
            IList<string> actual = _00228_SummaryRanges.SummaryRanges1(nums);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
