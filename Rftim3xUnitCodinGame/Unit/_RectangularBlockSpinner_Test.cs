using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _RectangularBlockSpinner_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_RectangularBlockSpinner))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_RectangularBlockSpinner))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_RectangularBlockSpinner))![1]);

        public static TheoryData<List<string>, int> _RectangularBlockSpinnerPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _RectangularBlockSpinnerPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_RectangularBlockSpinnerPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _RectangularBlockSpinner.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_RectangularBlockSpinnerPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _RectangularBlockSpinner.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
