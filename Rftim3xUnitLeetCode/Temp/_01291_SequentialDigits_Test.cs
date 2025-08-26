using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01291_SequentialDigits_Test
    {
        // Arrange
        private static readonly int a0 = 100, a1 = 300;
        private static readonly List<int> ar = [123, 234];

        private static readonly int b0 = 1000, b1 = 13000;
        private static readonly List<int> br = [1234, 2345, 3456, 4567, 5678, 6789, 12345];

        private static readonly int c0 = 10, c1 = 1000000000;
        private static readonly List<int> cr = [12, 23, 34, 45, 56, 67, 78, 89, 123, 234, 345, 456, 567, 678, 789, 1234, 2345, 3456, 4567, 5678, 6789, 12345, 23456, 34567, 45678, 56789, 123456, 234567, 345678, 456789, 1234567, 2345678, 3456789, 12345678, 23456789, 123456789];

        private static readonly int d0 = 58, d1 = 155;
        private static readonly List<int> dr = [67, 78, 89, 123];

        public static TheoryData<int, int, List<int>> _01291_SequentialDigits_Data =>
            new()
            {
                { a0, a1, ar },
                { b0, b1, br },
                { c0, c1, cr },
                { d0, d1, dr }
            };


        [Theory]
        [MemberData(nameof(_01291_SequentialDigits_Data))]
        public void SequentialDigits0(int a0, int a1, List<int> expected)
        {
            // Act
            IList<int> actual = _01291_SequentialDigits.SequentialDigits0(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01291_SequentialDigits_Data))]
        public void SequentialDigits1(int a0, int a1, List<int> expected)
        {
            // Act
            IList<int> actual = _01291_SequentialDigits.SequentialDigits1(a0, a1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}