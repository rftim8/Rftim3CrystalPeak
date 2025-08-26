namespace Rftim3xUnitLeetCode.Temp
{
    public class _00104_MaximumDepthOfBinaryTree_Test
    {
        // Arrange
        private static readonly int[] a0 = [3, 9, 20, 0, 0, 15, 7];
        private static readonly int ar = 3;

        private static readonly int[] b0 = [1, 0, 2];
        private static readonly int br = 2;

        public static TheoryData<int[], int> _00104_MaximumDepthOfBinaryTree_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };


        [Theory]
        [MemberData(nameof(_00104_MaximumDepthOfBinaryTree_Data))]
        public void MaximumDepthOfBinaryTree0(int[] a0, int expected)
        {
            // Act
            //int actual = _00104_MaximumDepthOfBinaryTree.MaximumDepthOfBinaryTree0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}