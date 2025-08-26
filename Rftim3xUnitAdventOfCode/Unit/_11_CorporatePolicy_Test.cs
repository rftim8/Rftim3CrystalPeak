using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using Rftim3AdventOfCode.Refactor;

namespace Rftim3xUnitAdventOfCode.Unit
{
    public class _11_CorporatePolicy_Test
    {
        // Arrange
        private static readonly List<string> Input = RftAdventOfCodeStaticData.Input_Test(problemName: nameof(_11_CorporatePolicy))!;
        private static readonly string ExpectedPartOne = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_11_CorporatePolicy))![0];
        private static readonly string ExpectedPartTwo = RftAdventOfCodeStaticData.Output_Test(problemName: nameof(_11_CorporatePolicy))![1];

        public static TheoryData<List<string>, string> _11_CorporatePolicyPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, string> _11_CorporatePolicyPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_11_CorporatePolicyPartOne_Data))]
        public static void RftPartOne(List<string> input, string expected)
        {
            // Act
            string actual = _11_CorporatePolicy.PartOne_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory(Skip = "Return value void")]
        [MemberData(nameof(_11_CorporatePolicyPartTwo_Data))]
        public static void RftPartTwo(List<string> input, string expected)
        {
            // Act
            string actual = _11_CorporatePolicy.PartTwo_Test(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
