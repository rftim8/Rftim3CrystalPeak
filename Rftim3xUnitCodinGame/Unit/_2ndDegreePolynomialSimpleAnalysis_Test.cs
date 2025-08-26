using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _2ndDegreePolynomialSimpleAnalysis_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_2ndDegreePolynomialSimpleAnalysis))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_2ndDegreePolynomialSimpleAnalysis))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_2ndDegreePolynomialSimpleAnalysis))![1]);

        public static TheoryData<List<string>, int> _2ndDegreePolynomialSimpleAnalysisPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _2ndDegreePolynomialSimpleAnalysisPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_2ndDegreePolynomialSimpleAnalysisPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _2ndDegreePolynomialSimpleAnalysis.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_2ndDegreePolynomialSimpleAnalysisPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _2ndDegreePolynomialSimpleAnalysis.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
