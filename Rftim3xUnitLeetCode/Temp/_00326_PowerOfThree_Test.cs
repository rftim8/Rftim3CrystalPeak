using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00326_PowerOfThree_Test
    {
        // Arrange
        private static readonly int a0 = 27;
        private static readonly bool ar = true;

        private static readonly int b0 = 0;
        private static readonly bool br = false;

        private static readonly int c0 = -1;
        private static readonly bool cr = false;

        public static TheoryData<int, bool> _00326_PowerOfThree_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };

        [Theory]
        [MemberData(nameof(_00326_PowerOfThree_Data))]
        public void IsPowerOfThree0(int n, bool expected)
        {
            // Act
            bool actual = _00326_PowerOfThree.IsPowerOfThree0(n);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00326_PowerOfThree_Data))]
        public void IsPowerOfThree1(int n, bool expected)
        {
            // Act
            bool actual = _00326_PowerOfThree.IsPowerOfThree1(n);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00326_PowerOfThree_Data))]
        public void IsPowerOfThree2(int n, bool expected)
        {
            // Act
            bool actual = _00326_PowerOfThree.IsPowerOfThree2(n);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
