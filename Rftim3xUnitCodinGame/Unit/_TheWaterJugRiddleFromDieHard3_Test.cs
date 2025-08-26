using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _TheWaterJugRiddleFromDieHard3_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_TheWaterJugRiddleFromDieHard3))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_TheWaterJugRiddleFromDieHard3))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_TheWaterJugRiddleFromDieHard3))![1]);

        public static TheoryData<List<string>, int> _TheWaterJugRiddleFromDieHard3PartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _TheWaterJugRiddleFromDieHard3PartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_TheWaterJugRiddleFromDieHard3PartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _TheWaterJugRiddleFromDieHard3.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_TheWaterJugRiddleFromDieHard3PartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _TheWaterJugRiddleFromDieHard3.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
