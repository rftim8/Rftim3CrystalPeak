using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01441_BuildAnArrayWithStackOperations_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 3];
        private static readonly int a1 = 3;
        private static readonly IList<string> ar = ["Push", "Push", "Pop", "Push"];

        private static readonly int[] b0 = [1, 2, 3];
        private static readonly int b1 = 3;
        private static readonly IList<string> br = ["Push", "Push", "Push"];

        private static readonly int[] c0 = [1, 2];
        private static readonly int c1 = 4;
        private static readonly IList<string> cr = ["Push", "Push"];

        public static TheoryData<int[], int, IList<string>> _01441_BuildAnArrayWithStackOperations_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr }
            };

        [Theory]
        [MemberData(nameof(_01441_BuildAnArrayWithStackOperations_Data))]
        public void BuildArray0(int[] input, int n, IList<string> expected)
        {
            // Act
            IList<string> actual = _01441_BuildAnArrayWithStackOperations.BuildArray0(input, n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
