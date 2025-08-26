using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _NatureOfTriangles_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_NatureOfTriangles))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_NatureOfTriangles))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_NatureOfTriangles))![1]);

        public static TheoryData<List<string>, int> _NatureOfTrianglesPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _NatureOfTrianglesPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_NatureOfTrianglesPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _NatureOfTriangles.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_NatureOfTrianglesPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _NatureOfTriangles.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
