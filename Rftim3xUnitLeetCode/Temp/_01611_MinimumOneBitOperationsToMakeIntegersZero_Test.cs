using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01611_MinimumOneBitOperationsToMakeIntegersZero_Test
    {
        // Arrange
        private static readonly int a0 = 3, ar = 2;

        private static readonly int b0 = 3, br = 2;

        public static TheoryData<int, int> _01611_MinimumOneBitOperationsToMakeIntegersZero_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_01611_MinimumOneBitOperationsToMakeIntegersZero_Data))]
        public void MinimumOneBitOperations(int a0, int expected)
        {
            // Act
            int actual = _01611_MinimumOneBitOperationsToMakeIntegersZero.MinimumOneBitOperationsToMakeIntegersZero0(a0);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01611_MinimumOneBitOperationsToMakeIntegersZero_Data))]
        public void MinimumOneBitOperations0(int a0, int expected)
        {
            // Act
            int actual = _01611_MinimumOneBitOperationsToMakeIntegersZero.MinimumOneBitOperationsToMakeIntegersZero1(a0);

            // Assert
            Assert.Equivalent(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01611_MinimumOneBitOperationsToMakeIntegersZero_Data))]
        public void MinimumOneBitOperations1(int a0, int expected)
        {
            // Act
            int actual = _01611_MinimumOneBitOperationsToMakeIntegersZero.MinimumOneBitOperationsToMakeIntegersZero2(a0);

            // Assert
            Assert.Equivalent(expected, actual);
        }
    }
}