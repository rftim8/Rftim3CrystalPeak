using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00060_PermutationSequence_Test
    {
        // Arrange
        private static readonly int a0 = 0;
        private static readonly int a1 = 0;
        private static readonly string ar = "";

        public static TheoryData<int, int, string> _00060_PermutationSequence_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00060_PermutationSequence_Data))]
        public void PermutationSequence0(int a0, int a1, string expected)
        {
            // Act
            string actual = _00060_PermutationSequence.PermutationSequence0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}