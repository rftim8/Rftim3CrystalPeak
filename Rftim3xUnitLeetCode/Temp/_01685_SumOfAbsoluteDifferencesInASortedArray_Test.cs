using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01685_SumOfAbsoluteDifferencesInASortedArray_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 3, 5];
        private static readonly int[] ar = [4, 3, 5];

        private static readonly int[] b0 = [1, 4, 6, 8, 10];
        private static readonly int[] br = [24, 15, 13, 15, 21];

        public static TheoryData<int[], int[]> _01685_SumOfAbsoluteDifferencesInASortedArray_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_01685_SumOfAbsoluteDifferencesInASortedArray_Data))]
        public void GetSumAbsoluteDifferences0(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _01685_SumOfAbsoluteDifferencesInASortedArray.GetSumAbsoluteDifferences0(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }

        [Theory]
        [MemberData(nameof(_01685_SumOfAbsoluteDifferencesInASortedArray_Data))]
        public void GetSumAbsoluteDifferences1(int[] a0, int[] expected)
        {
            // Act
            int[] actual = _01685_SumOfAbsoluteDifferencesInASortedArray.GetSumAbsoluteDifferences1(a0);

            // Assert
            Assert.Equivalent(expected, actual, true);
        }
    }
}
