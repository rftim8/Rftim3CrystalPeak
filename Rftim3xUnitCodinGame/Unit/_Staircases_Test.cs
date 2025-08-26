using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _Staircases_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_Staircases))!;
        private static readonly List<string> ExpectedSolution_0 = RftCodinGameStaticData.Output_Test(problemName: nameof(_Staircases))!;

        public static TheoryData<List<string>, List<string>> ExpectedSolution_0_Data =>
            new()
            {
                { Input, ExpectedSolution_0 }
            };

        [Theory]
        [MemberData(nameof(ExpectedSolution_0_Data))]
        public void RftPartOne(List<string> a0, List<string> expected)
        {
            // Act
            List<string> actual = _Staircases.Solution_Test(a0);

            // Assert
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }
    }
}
