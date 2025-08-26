using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _13_TransparentOrigami_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_13_TransparentOrigami))!;
        private static readonly int ExpectedPartOne = int.Parse(RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_13_TransparentOrigami))![0]);
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_13_TransparentOrigami))![1];

        public static TheoryData<List<string>, int> _13_TransparentOrigamiPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _13_TransparentOrigamiPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_13_TransparentOrigamiPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _13_TransparentOrigami.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_13_TransparentOrigamiPartTwo_Data))]
        public void RftPartTwo(List<string> a0, string expected)
        {
            // Act
            string actual = _13_TransparentOrigami.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
