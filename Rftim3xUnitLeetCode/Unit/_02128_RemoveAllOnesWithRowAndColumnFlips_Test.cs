using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02128_RemoveAllOnesWithRowAndColumnFlips_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02128_RemoveAllOnesWithRowAndColumnFlips))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02128_RemoveAllOnesWithRowAndColumnFlips))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02128_RemoveAllOnesWithRowAndColumnFlips))![1]);

        public static TheoryData<List<string>, int> _02128_RemoveAllOnesWithRowAndColumnFlipsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02128_RemoveAllOnesWithRowAndColumnFlipsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02128_RemoveAllOnesWithRowAndColumnFlipsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02128_RemoveAllOnesWithRowAndColumnFlips.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02128_RemoveAllOnesWithRowAndColumnFlipsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02128_RemoveAllOnesWithRowAndColumnFlips.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
