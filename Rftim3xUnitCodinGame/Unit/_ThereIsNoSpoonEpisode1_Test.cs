using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _ThereIsNoSpoonEpisode1_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_ThereIsNoSpoonEpisode1))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_ThereIsNoSpoonEpisode1))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_ThereIsNoSpoonEpisode1))![1]);

        public static TheoryData<List<string>, int> _ThereIsNoSpoonEpisode1PartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _ThereIsNoSpoonEpisode1PartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_ThereIsNoSpoonEpisode1PartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _ThereIsNoSpoonEpisode1.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_ThereIsNoSpoonEpisode1PartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _ThereIsNoSpoonEpisode1.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
