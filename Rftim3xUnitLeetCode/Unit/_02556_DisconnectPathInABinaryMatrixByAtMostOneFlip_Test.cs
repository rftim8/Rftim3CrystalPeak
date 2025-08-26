using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02556_DisconnectPathInABinaryMatrixByAtMostOneFlip_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02556_DisconnectPathInABinaryMatrixByAtMostOneFlip))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02556_DisconnectPathInABinaryMatrixByAtMostOneFlip))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02556_DisconnectPathInABinaryMatrixByAtMostOneFlip))![1]);

        public static TheoryData<List<string>, int> _02556_DisconnectPathInABinaryMatrixByAtMostOneFlipPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02556_DisconnectPathInABinaryMatrixByAtMostOneFlipPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02556_DisconnectPathInABinaryMatrixByAtMostOneFlipPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02556_DisconnectPathInABinaryMatrixByAtMostOneFlip.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02556_DisconnectPathInABinaryMatrixByAtMostOneFlipPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02556_DisconnectPathInABinaryMatrixByAtMostOneFlip.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
