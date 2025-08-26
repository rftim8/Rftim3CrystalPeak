using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02517_MaximumTastinessOfCandyBasket_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02517_MaximumTastinessOfCandyBasket))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02517_MaximumTastinessOfCandyBasket))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02517_MaximumTastinessOfCandyBasket))![1]);

        public static TheoryData<List<string>, int> _02517_MaximumTastinessOfCandyBasketPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02517_MaximumTastinessOfCandyBasketPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02517_MaximumTastinessOfCandyBasketPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02517_MaximumTastinessOfCandyBasket.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02517_MaximumTastinessOfCandyBasketPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02517_MaximumTastinessOfCandyBasket.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
