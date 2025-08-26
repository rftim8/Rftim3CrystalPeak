using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02167_MinimumTimeToRemoveAllCarsContainingIllegalGoods_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02167_MinimumTimeToRemoveAllCarsContainingIllegalGoods))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02167_MinimumTimeToRemoveAllCarsContainingIllegalGoods))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02167_MinimumTimeToRemoveAllCarsContainingIllegalGoods))![1]);

        public static TheoryData<List<string>, int> _02167_MinimumTimeToRemoveAllCarsContainingIllegalGoodsPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02167_MinimumTimeToRemoveAllCarsContainingIllegalGoodsPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02167_MinimumTimeToRemoveAllCarsContainingIllegalGoodsPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02167_MinimumTimeToRemoveAllCarsContainingIllegalGoods.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02167_MinimumTimeToRemoveAllCarsContainingIllegalGoodsPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02167_MinimumTimeToRemoveAllCarsContainingIllegalGoods.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
