using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00049_GroupAnagrams_Test
    {
        // Arrange
        private static readonly string[] a0 = [];
        private static readonly List<IList<string>> ar = [];

        public static TheoryData<string[], List<IList<string>>> _00049_GroupAnagrams_Data =>
            new()
            {
                { a0, ar }
            };


        [Theory]
        [MemberData(nameof(_00049_GroupAnagrams_Data))]
        public void GroupAnagrams0(string[] a0, List<IList<string>> expected)
        {
            // Act
            IList<IList<string>> actual = _00049_GroupAnagrams.GroupAnagrams0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}