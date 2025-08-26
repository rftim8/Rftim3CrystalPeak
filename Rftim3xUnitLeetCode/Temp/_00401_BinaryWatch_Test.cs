using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00401_BinaryWatch_Test
    {
        // Arrange
        private static readonly int a0 = 1;
        private static readonly string[] ar = ["0:01", "0:02", "0:04", "0:08", "0:16", "0:32", "1:00", "2:00", "4:00", "8:00"];

        private static readonly int b0 = 9;
        private static readonly string[] br = [];

        public static TheoryData<int, string[]> _00401_BinaryWatch_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_00401_BinaryWatch_Data))]
        public void ReadBinaryWatch0(int turnedOn, IList<string> expected)
        {
            // Act
            IList<string> actual = _00401_BinaryWatch.ReadBinaryWatch0(turnedOn);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
