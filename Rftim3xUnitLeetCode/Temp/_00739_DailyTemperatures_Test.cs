using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00739_DailyTemperatures_Test
    {
        // Arrange
        private static readonly int[] a0 = [73, 74, 75, 71, 69, 72, 76, 73];
        private static readonly int[] ar = [1, 1, 4, 2, 1, 1, 0, 0];

        private static readonly int[] b0 = [30, 40, 50, 60];
        private static readonly int[] br = [1, 1, 1, 0];

        private static readonly int[] c0 = [30, 60, 90];
        private static readonly int[] cr = [1, 1, 0];

        public static TheoryData<int[], int[]> _00739_DailyTemperatures_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00739_DailyTemperatures_Data))]
        public void DailyTemperatures0(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00739_DailyTemperatures.DailyTemperatures0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00739_DailyTemperatures_Data))]
        public void DailyTemperatures1(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _00739_DailyTemperatures.DailyTemperatures1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}