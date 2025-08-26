using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02018_CheckIfWordCanBePlacedInCrossword_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02018_CheckIfWordCanBePlacedInCrossword))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02018_CheckIfWordCanBePlacedInCrossword))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02018_CheckIfWordCanBePlacedInCrossword))![1]);

        public static TheoryData<List<string>, int> _02018_CheckIfWordCanBePlacedInCrosswordPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02018_CheckIfWordCanBePlacedInCrosswordPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02018_CheckIfWordCanBePlacedInCrosswordPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02018_CheckIfWordCanBePlacedInCrossword.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02018_CheckIfWordCanBePlacedInCrosswordPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02018_CheckIfWordCanBePlacedInCrossword.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
