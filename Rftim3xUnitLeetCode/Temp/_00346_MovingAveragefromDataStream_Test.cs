using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00346_MovingAveragefromDataStream_Test
    {
        // Arrange
        private static readonly List<string> a0 = ["MovingAverage", "next", "next", "next", "next"];
        private static readonly List<int[]> a1 = [[3], [1], [10], [3], [5]];
        private static readonly List<double?> ar = [1, 5.5, 4.666666666666667, 6];

        public static TheoryData<List<string>, List<int[]>, List<double?>> _00346_MovingAveragefromDataStream_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00346_MovingAveragefromDataStream_Data))]
        public void MovingAveragefromDataStream0(List<string> a0, List<int[]> a1, List<double?> expected)
        {
            // Act
            List<double?> actual = _00346_MovingAveragefromDataStream.MovingAveragefromDataStream0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}