using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00368_LargestDivisibleSubset_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3];
        private static readonly List<int> ar = [1, 2];

        private static readonly int[] b0 = [1, 2, 4, 8];
        private static readonly List<int> br = [1, 2, 4, 8];

        public static TheoryData<int[], List<int>> _00368_LargestDivisibleSubset_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00368_LargestDivisibleSubset_Data))]
        public void LargestDivisibleSubset0(int[] a0, List<int> expected)
        {
            // Act
            IList<int> actual = _00368_LargestDivisibleSubset.LargestDivisibleSubset0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00368_LargestDivisibleSubset_Data))]
        public void LargestDivisibleSubset1(int[] a0, List<int> expected)
        {
            // Act
            IList<int> actual = _00368_LargestDivisibleSubset.LargestDivisibleSubset1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00368_LargestDivisibleSubset_Data))]
        public void LargestDivisibleSubset2(int[] a0, List<int> expected)
        {
            // Act
            IList<int> actual = _00368_LargestDivisibleSubset.LargestDivisibleSubset2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00368_LargestDivisibleSubset_Data))]
        public void LargestDivisibleSubset3(int[] a0, List<int> expected)
        {
            // Act
            IList<int> actual = _00368_LargestDivisibleSubset.LargestDivisibleSubset3(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}