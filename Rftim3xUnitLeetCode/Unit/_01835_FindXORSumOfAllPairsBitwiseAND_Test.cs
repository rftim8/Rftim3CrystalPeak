using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01835_FindXORSumOfAllPairsBitwiseAND_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01835_FindXORSumOfAllPairsBitwiseAND))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01835_FindXORSumOfAllPairsBitwiseAND))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01835_FindXORSumOfAllPairsBitwiseAND))![1]);

        public static TheoryData<List<string>, int> _01835_FindXORSumOfAllPairsBitwiseANDPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01835_FindXORSumOfAllPairsBitwiseANDPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01835_FindXORSumOfAllPairsBitwiseANDPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01835_FindXORSumOfAllPairsBitwiseAND.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01835_FindXORSumOfAllPairsBitwiseANDPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01835_FindXORSumOfAllPairsBitwiseAND.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
