using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03059_FindAllUniqueEmailDomains_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03059_FindAllUniqueEmailDomains))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03059_FindAllUniqueEmailDomains))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03059_FindAllUniqueEmailDomains))![1]);

        public static TheoryData<List<string>, int> _03059_FindAllUniqueEmailDomainsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03059_FindAllUniqueEmailDomainsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03059_FindAllUniqueEmailDomainsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03059_FindAllUniqueEmailDomains.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03059_FindAllUniqueEmailDomainsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03059_FindAllUniqueEmailDomains.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
