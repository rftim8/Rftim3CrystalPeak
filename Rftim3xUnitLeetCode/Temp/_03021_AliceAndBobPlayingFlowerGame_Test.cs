using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _03021_AliceAndBobPlayingFlowerGame_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly int ar = 0;

        public static TheoryData<int[], int> _03021_AliceAndBobPlayingFlowerGame_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_03021_AliceAndBobPlayingFlowerGame_Data))]
        public void AliceAndBobPlayingFlowerGame0(int[] a0, int expected)
        {
            // Act
            int actual = _03021_AliceAndBobPlayingFlowerGame.AliceAndBobPlayingFlowerGame0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}