namespace Rftim3xUnitLeetCode.Temp
{
    public class _02870_MinimumNumberOfOperationsToMakeArrayEmpty_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 3, 3, 2, 2, 4, 2, 3, 4];
        private static readonly int ar = 4;

        private static readonly int[] b0 = [2, 1, 2, 2, 3, 3];
        private static readonly int br = -1;

        public static TheoryData<int[], int> _02870_MinimumNumberOfOperationsToMakeArrayEmpty_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02870_MinimumNumberOfOperationsToMakeArrayEmpty_Data))]
        public void MinOperations0(int[] a0, int expected)
        {
            // Act
            //int actual = _02870_MinimumNumberOfOperationsToMakeArrayEmpty.MinOperations0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02870_MinimumNumberOfOperationsToMakeArrayEmpty_Data))]
        public void MinOperations1(int[] a0, int expected)
        {
            // Act
            //int actual = _02870_MinimumNumberOfOperationsToMakeArrayEmpty.MinOperations1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
