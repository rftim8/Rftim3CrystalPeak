using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriod_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriod))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriod))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriod))![1]);

        public static TheoryData<List<string>, int> _01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriodPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriodPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriodPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriod.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriodPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _01604_AlertUsingSameKeyCardThreeorMoreTimesinaOneHourPeriod.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
