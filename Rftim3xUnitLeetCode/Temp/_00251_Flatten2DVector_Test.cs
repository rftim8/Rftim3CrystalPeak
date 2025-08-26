using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00251_Flatten2DVector_Test
    {
        // Arrange
        private static readonly string[] a0 = ["Vector2D", "next", "next", "next", "hasNext", "hasNext", "next", "hasNext"];
        private static readonly object[] a1 = [new int[][] { [1, 2], [3], [4] }, 0, 0, 0, 0, 0, 0, 0];
        private static readonly List<object?> ar = [null, 1, 2, 3, true, true, 4, false];

        public static TheoryData<string[], object[], List<object?>> _00251_Flatten2DVector_Data =>
            new()
            {
                { a0, a1, ar }
            };

        [Theory]
        [MemberData(nameof(_00251_Flatten2DVector_Data))]
        public void CanAttendMeetings0(string[] a0, object[] a1, List<object?> expected)
        {
            // Act
            List<object?> actual = _00251_Flatten2DVector.Flatten2DVector0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
