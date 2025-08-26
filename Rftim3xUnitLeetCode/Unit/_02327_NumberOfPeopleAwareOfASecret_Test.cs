using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02327_NumberOfPeopleAwareOfASecret_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02327_NumberOfPeopleAwareOfASecret))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02327_NumberOfPeopleAwareOfASecret))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02327_NumberOfPeopleAwareOfASecret))![1]);

        public static TheoryData<List<string>, int> _02327_NumberOfPeopleAwareOfASecretPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02327_NumberOfPeopleAwareOfASecretPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02327_NumberOfPeopleAwareOfASecretPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02327_NumberOfPeopleAwareOfASecret.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02327_NumberOfPeopleAwareOfASecretPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02327_NumberOfPeopleAwareOfASecret.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
