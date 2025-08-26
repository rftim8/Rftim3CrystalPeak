using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _02_BathroomSecurity_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_02_BathroomSecurity))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_02_BathroomSecurity))![0];
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_02_BathroomSecurity))![1];

        public static TheoryData<List<string>, string> _02_BathroomSecurityPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _02_BathroomSecurityPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02_BathroomSecurityPartOne_Data))]
        public static void RftPartOne(List<string> input, string expected)
        {
            // Act
            string actual = _02_BathroomSecurity.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02_BathroomSecurityPartTwo_Data))]
        public static void RftPartTwo(List<string> input, string expected)
        {
            // Act
            string actual = _02_BathroomSecurity.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
