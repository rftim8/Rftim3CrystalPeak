using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00038_CountAndSay_Test
    {
        // Arrange
        private static readonly int a0 = 0;
        private static readonly string ar = "";

        public static TheoryData<int, string> _00038_CountAndSay_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00038_CountAndSay_Data))]
        public void CountAndSay0(int a0, string expected)
        {
            // Act
            string actual = _00038_CountAndSay.CountAndSay0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}