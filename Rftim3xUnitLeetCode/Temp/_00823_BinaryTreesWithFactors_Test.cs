namespace Rftim3xUnitLeetCode.Temp
{
    public class _00823_BinaryTreesWithFactors_Test
    {
        // Arrange
        private static readonly int[] a0 = [2, 4];
        private static readonly int ar = 3;

        private static readonly int[] b0 = [2, 4, 5, 10];
        private static readonly int br = 7;

        public static TheoryData<int[], int> _00823_BinaryTreesWithFactors_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00823_BinaryTreesWithFactors_Data))]
        public void NumFactoredBinaryTrees0(int[] arr, int expected)
        {
            // Act
            //int actual = _00823_BinaryTreesWithFactors.NumFactoredBinaryTrees0(arr);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
