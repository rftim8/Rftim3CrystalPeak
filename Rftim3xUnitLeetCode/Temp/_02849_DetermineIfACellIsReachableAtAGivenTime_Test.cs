using Rftim3LeetCode.Temp;
using Xunit.Abstractions;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02849_DetermineIfACellIsReachableAtAGivenTime_Test(ITestOutputHelper testOutputHelper)
    {
        private readonly ITestOutputHelper testOutputHelper = testOutputHelper;

        // Arrange
        private static readonly int a0 = 2;
        private static readonly int a1 = 4;
        private static readonly int a2 = 7;
        private static readonly int a3 = 7;
        private static readonly int a4 = 6;
        private static readonly bool ar = true;

        private static readonly int b0 = 3;
        private static readonly int b1 = 1;
        private static readonly int b2 = 7;
        private static readonly int b3 = 3;
        private static readonly int b4 = 3;
        private static readonly bool br = false;

        public static TheoryData<int, int, int, int, int, bool> _02849_DetermineIfACellIsReachableAtAGivenTime_Data =>
            new()
            {
                { a0, a1, a2, a3, a4, ar },
                { b0, b1, b2, b3, b4, br }
            };

        [Theory]
        [MemberData(nameof(_02849_DetermineIfACellIsReachableAtAGivenTime_Data))]
        public void IsReachableAtTime0(int sx, int sy, int fx, int fy, int t, bool expected)
        {
            // Act
            bool actual = _02849_DetermineIfACellIsReachableAtAGivenTime.IsReachableAtTime0(sx, sy, fx, fy, t);

            testOutputHelper.WriteLine(actual.ToString());

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
