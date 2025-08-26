using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _10_CathodeRayTube_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_10_CathodeRayTube))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_10_CathodeRayTube))![0]);
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_10_CathodeRayTube))![1];

        public static TheoryData<List<string>, int> _10_CathodeRayTubePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _10_CathodeRayTubePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_10_CathodeRayTubePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _10_CathodeRayTube.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_10_CathodeRayTubePartTwo_Data))]
        public void RftPartTwo(List<string> a0, string expected)
        {
            // Act
            string actual = _10_CathodeRayTube.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
