using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _EUROPEANRUGBYCHAMPIONSCUPRANKING_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_EUROPEANRUGBYCHAMPIONSCUPRANKING))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_EUROPEANRUGBYCHAMPIONSCUPRANKING))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_EUROPEANRUGBYCHAMPIONSCUPRANKING))![1]);

        public static TheoryData<List<string>, int> _EUROPEANRUGBYCHAMPIONSCUPRANKINGPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _EUROPEANRUGBYCHAMPIONSCUPRANKINGPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_EUROPEANRUGBYCHAMPIONSCUPRANKINGPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _EUROPEANRUGBYCHAMPIONSCUPRANKING.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_EUROPEANRUGBYCHAMPIONSCUPRANKINGPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _EUROPEANRUGBYCHAMPIONSCUPRANKING.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
