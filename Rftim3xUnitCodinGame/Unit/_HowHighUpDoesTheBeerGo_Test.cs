using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _HowHighUpDoesTheBeerGo_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_HowHighUpDoesTheBeerGo))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_HowHighUpDoesTheBeerGo))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_HowHighUpDoesTheBeerGo))![1]);

        public static TheoryData<List<string>, int> _HowHighUpDoesTheBeerGoPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _HowHighUpDoesTheBeerGoPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_HowHighUpDoesTheBeerGoPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _HowHighUpDoesTheBeerGo.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_HowHighUpDoesTheBeerGoPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _HowHighUpDoesTheBeerGo.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
