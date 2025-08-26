using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01630_ArithmeticSubarrays_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 6, 5, 9, 3, 7];
        private static readonly int[] a1 = [0, 0, 2];
        private static readonly int[] a2 = [2, 3, 5];
        private static readonly IList<bool> ar = [true, false, true];

        private static readonly int[] b0 = [-12, -9, -3, -12, -6, 15, 20, -25, -20, -15, -10];
        private static readonly int[] b1 = [0, 1, 6, 4, 8, 7];
        private static readonly int[] b2 = [4, 4, 9, 7, 9, 10];
        private static readonly IList<bool> br = [false, true, false, false, true, true];

        public static TheoryData<int[], int[], int[], IList<bool>> _01630_ArithmeticSubarrays_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br }
            };

        [Theory]
        [MemberData(nameof(_01630_ArithmeticSubarrays_Data))]
        public void CheckArithmeticSubarrays0(int[] a0, int[] a1, int[] a2, IList<bool> expected)
        {
            // Act
            IList<bool> actual = _01630_ArithmeticSubarrays.CheckArithmeticSubarrays0(a0, a1, a2);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
