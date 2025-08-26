using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _03001_MinimumMovesToCaptureTheQueen_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_03001_MinimumMovesToCaptureTheQueen))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03001_MinimumMovesToCaptureTheQueen))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_03001_MinimumMovesToCaptureTheQueen))![1]);

        public static TheoryData<List<string>, int> _03001_MinimumMovesToCaptureTheQueenPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _03001_MinimumMovesToCaptureTheQueenPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_03001_MinimumMovesToCaptureTheQueenPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _03001_MinimumMovesToCaptureTheQueen.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_03001_MinimumMovesToCaptureTheQueenPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _03001_MinimumMovesToCaptureTheQueen.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
