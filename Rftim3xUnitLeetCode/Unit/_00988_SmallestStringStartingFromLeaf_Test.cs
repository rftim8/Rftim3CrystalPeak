using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _00988_SmallestStringStartingFromLeaf_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_00988_SmallestStringStartingFromLeaf))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00988_SmallestStringStartingFromLeaf))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_00988_SmallestStringStartingFromLeaf))![1]);

        public static TheoryData<List<string>, int> _00988_SmallestStringStartingFromLeafPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _00988_SmallestStringStartingFromLeafPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_00988_SmallestStringStartingFromLeafPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _00988_SmallestStringStartingFromLeaf.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00988_SmallestStringStartingFromLeafPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _00988_SmallestStringStartingFromLeaf.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
