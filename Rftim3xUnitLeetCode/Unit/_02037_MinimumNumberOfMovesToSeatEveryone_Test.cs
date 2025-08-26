using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02037_MinimumNumberOfMovesToSeatEveryone_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02037_MinimumNumberOfMovesToSeatEveryone))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02037_MinimumNumberOfMovesToSeatEveryone))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02037_MinimumNumberOfMovesToSeatEveryone))![1]);

        public static TheoryData<List<string>, int> _02037_MinimumNumberOfMovesToSeatEveryonePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02037_MinimumNumberOfMovesToSeatEveryonePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02037_MinimumNumberOfMovesToSeatEveryonePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02037_MinimumNumberOfMovesToSeatEveryone.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02037_MinimumNumberOfMovesToSeatEveryonePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02037_MinimumNumberOfMovesToSeatEveryone.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
