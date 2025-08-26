using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00050_PowOfxTon_Test
    {
        // Arrange
        private static readonly double a0 = 0;
        private static readonly int a1 = 0;
        private static readonly double ar = 0;

        public static TheoryData<double, int, double> _00050_PowOfxTon_Data =>
            new()
            {
                { a0, a1, ar }
            };


        [Theory]
        [MemberData(nameof(_00050_PowOfxTon_Data))]
        public void PowOfxTon0(double a0, int a1, double expected)
        {
            // Act
            double actual = _00050_PowOfxTon.PowOfxTon0(a0, a1);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}