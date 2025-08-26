using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03025_FindTheNumberOfWaysToPlacePeopleI_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03025_FindTheNumberOfWaysToPlacePeopleI_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03025_FindTheNumberOfWaysToPlacePeopleI_Data))]
        public void FindTheNumberOfWaysToPlacePeopleI0(int[] a0, int expected)
        {
            // Act
            int actual = _03025_FindTheNumberOfWaysToPlacePeopleI.FindTheNumberOfWaysToPlacePeopleI0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}