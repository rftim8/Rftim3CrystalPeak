using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCity_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCity))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCity))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCity))![1]);

        public static TheoryData<List<string>, int> _02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCityPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCityPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCityPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCity.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCityPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02314_TheFirstDayOfTheMaximumRecordedDegreeInEachCity.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
