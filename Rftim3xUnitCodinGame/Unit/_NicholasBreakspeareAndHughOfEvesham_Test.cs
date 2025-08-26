using Rftim3Convoy.Services.Static.CP.CodinGame.Data;
using Rftim3CodinGame.Refactor;

namespace Rftim3xUnitCodinGame.Unit
{
    public class _NicholasBreakspeareAndHughOfEvesham_Test
    {
        // Arrange
        private static readonly List<string> Input = RftCodinGameStaticData.Input_Test(problemName: nameof(_NicholasBreakspeareAndHughOfEvesham))!;
        private static readonly int ExpectedPartOne = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_NicholasBreakspeareAndHughOfEvesham))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftCodinGameStaticData.Output_Test(problemName: nameof(_NicholasBreakspeareAndHughOfEvesham))![1]);

        public static TheoryData<List<string>, int> _NicholasBreakspeareAndHughOfEveshamPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _NicholasBreakspeareAndHughOfEveshamPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_NicholasBreakspeareAndHughOfEveshamPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _NicholasBreakspeareAndHughOfEvesham.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_NicholasBreakspeareAndHughOfEveshamPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _NicholasBreakspeareAndHughOfEvesham.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
