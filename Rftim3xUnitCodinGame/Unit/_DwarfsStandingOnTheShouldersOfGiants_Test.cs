using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _DwarfsStandingOnTheShouldersOfGiants_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_DwarfsStandingOnTheShouldersOfGiants))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_DwarfsStandingOnTheShouldersOfGiants))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_DwarfsStandingOnTheShouldersOfGiants))![1]);

        public static TheoryData<List<string>, int> _DwarfsStandingOnTheShouldersOfGiantsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _DwarfsStandingOnTheShouldersOfGiantsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_DwarfsStandingOnTheShouldersOfGiantsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _DwarfsStandingOnTheShouldersOfGiants.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_DwarfsStandingOnTheShouldersOfGiantsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _DwarfsStandingOnTheShouldersOfGiants.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
