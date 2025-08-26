using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02447_NumberOfSubarraysWithGCDEqualtoK_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02447_NumberOfSubarraysWithGCDEqualtoK))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02447_NumberOfSubarraysWithGCDEqualtoK))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02447_NumberOfSubarraysWithGCDEqualtoK))![1]);

        public static TheoryData<List<string>, int> _02447_NumberOfSubarraysWithGCDEqualtoKPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02447_NumberOfSubarraysWithGCDEqualtoKPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02447_NumberOfSubarraysWithGCDEqualtoKPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02447_NumberOfSubarraysWithGCDEqualtoK.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02447_NumberOfSubarraysWithGCDEqualtoKPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02447_NumberOfSubarraysWithGCDEqualtoK.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
