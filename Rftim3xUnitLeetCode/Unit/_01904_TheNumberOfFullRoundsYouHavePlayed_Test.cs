using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01904_TheNumberOfFullRoundsYouHavePlayed_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01904_TheNumberOfFullRoundsYouHavePlayed))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01904_TheNumberOfFullRoundsYouHavePlayed))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01904_TheNumberOfFullRoundsYouHavePlayed))![1]);

        public static TheoryData<List<string>, int> _01904_TheNumberOfFullRoundsYouHavePlayedPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01904_TheNumberOfFullRoundsYouHavePlayedPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01904_TheNumberOfFullRoundsYouHavePlayedPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01904_TheNumberOfFullRoundsYouHavePlayed.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01904_TheNumberOfFullRoundsYouHavePlayedPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01904_TheNumberOfFullRoundsYouHavePlayed.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
