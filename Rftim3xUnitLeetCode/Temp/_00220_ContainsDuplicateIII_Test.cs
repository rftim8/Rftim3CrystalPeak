using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00220_ContainsDuplicateIII_Test
    {
        // Arrange
        private static readonly int[] a0 = [1, 2, 3, 1];
        private static readonly int a1 = 3, a2 = 0;
        private static readonly bool ar = true;

        private static readonly int[] b0 = [1, 5, 9, 1, 5, 9];
        private static readonly int b1 = 2, b2 = 3;
        private static readonly bool br = false;

        public static TheoryData<int[], int, int, bool> _00220_ContainsDuplicateIII_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br }
            };

        [Theory]
        [MemberData(nameof(_00220_ContainsDuplicateIII_Data))]
        public void ContainsDuplicateIII0(int[] a0, int a1, int a2, bool expected)
        {
            // Act
            bool actual = _00220_ContainsDuplicateIII.ContainsDuplicateIII0(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00220_ContainsDuplicateIII_Data))]
        public void ContainsDuplicateIII1(int[] a0, int a1, int a2, bool expected)
        {
            // Act
            bool actual = _00220_ContainsDuplicateIII.ContainsDuplicateIII1(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}