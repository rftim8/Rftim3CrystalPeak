using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02821_DelayTheResolutionOfEachPromise_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02821_DelayTheResolutionOfEachPromise))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02821_DelayTheResolutionOfEachPromise))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02821_DelayTheResolutionOfEachPromise))![1]);

        public static TheoryData<List<string>, int> _02821_DelayTheResolutionOfEachPromisePartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02821_DelayTheResolutionOfEachPromisePartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02821_DelayTheResolutionOfEachPromisePartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02821_DelayTheResolutionOfEachPromise.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02821_DelayTheResolutionOfEachPromisePartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02821_DelayTheResolutionOfEachPromise.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
