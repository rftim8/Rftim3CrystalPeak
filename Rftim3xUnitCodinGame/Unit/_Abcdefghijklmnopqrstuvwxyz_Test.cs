using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _Abcdefghijklmnopqrstuvwxyz_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_Abcdefghijklmnopqrstuvwxyz))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_Abcdefghijklmnopqrstuvwxyz))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_Abcdefghijklmnopqrstuvwxyz))![1]);

        public static TheoryData<List<string>, int> _AbcdefghijklmnopqrstuvwxyzPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _AbcdefghijklmnopqrstuvwxyzPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_AbcdefghijklmnopqrstuvwxyzPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _Abcdefghijklmnopqrstuvwxyz.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_AbcdefghijklmnopqrstuvwxyzPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _Abcdefghijklmnopqrstuvwxyz.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
