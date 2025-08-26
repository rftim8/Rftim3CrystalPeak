using Rftim3Convoy.Services.Static.CP.LeetCode.Data;
using Rftim3LeetCode.Refactor;

namespace Rftim3xUnitLeetCode.Unit
{
    public class _02084_DropType1OrdersForCustomersWithType0Orders_Test
    {
        // Arrange
        private static readonly List<string> Input = RftLeetCodeStaticData.Input_Test(problemName: nameof(_02084_DropType1OrdersForCustomersWithType0Orders))!;
        private static readonly int ExpectedPartOne = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02084_DropType1OrdersForCustomersWithType0Orders))![0]);
        private static readonly int ExpectedPartTwo = int.Parse(RftLeetCodeStaticData.Output_Test(problemName: nameof(_02084_DropType1OrdersForCustomersWithType0Orders))![1]);

        public static TheoryData<List<string>, int> _02084_DropType1OrdersForCustomersWithType0OrdersPartOne_Data =>
            new()
            {
                { Input, ExpectedPartOne }
            };

        public static TheoryData<List<string>, int> _02084_DropType1OrdersForCustomersWithType0OrdersPartTwo_Data =>
            new()
            {
                { Input, ExpectedPartTwo }
            };

        [Theory]
        [MemberData(nameof(_02084_DropType1OrdersForCustomersWithType0OrdersPartOne_Data))]
        public void RftPartOne(List<string> a0, int expected)
        {
            // Act
            int actual = _02084_DropType1OrdersForCustomersWithType0Orders.PartOne_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02084_DropType1OrdersForCustomersWithType0OrdersPartTwo_Data))]
        public void RftPartTwo(List<string> a0, int expected)
        {
            // Act
            int actual = _02084_DropType1OrdersForCustomersWithType0Orders.PartTwo_Test(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
