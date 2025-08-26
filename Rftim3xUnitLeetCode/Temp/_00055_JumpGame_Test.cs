using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00055_JumpGame_Test
    {
        // Arrange
        private static readonly int[] a0 = [];
        private static readonly bool ar = true;

        public static TheoryData<int[], bool> _00055_JumpGame_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00055_JumpGame_Data))]
        public void JumpGame0(int[] a0, bool expected)
        {
            // Act
            bool actual = _00055_JumpGame.JumpGame0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}