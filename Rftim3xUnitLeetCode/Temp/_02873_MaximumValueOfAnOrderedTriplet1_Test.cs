using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _02873_MaximumValueOfAnOrderedTriplet1_Test
    {
        // Arrange
        private static readonly int[] a0 = [12, 6, 1, 2, 7];
        private static readonly long ar = 77;

        private static readonly int[] b0 = [1, 10, 3, 4, 19];
        private static readonly long br = 133;

        private static readonly int[] c0 = [1, 2, 3];
        private static readonly long cr = 0;

        public static TheoryData<int[], long> _02873_MaximumValueOfAnOrderedTriplet1_Data =>
            new()
            {
                { a0, ar },
                { b0, br }
            };

        [Theory]
        [MemberData(nameof(_02873_MaximumValueOfAnOrderedTriplet1_Data))]
        public void MaximumTripletValue0(int[] a0, long expected)
        {
            // Act
            long actual = _02873_MaximumValueOfAnOrderedTriplet1.MaximumTripletValue0(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_02873_MaximumValueOfAnOrderedTriplet1_Data))]
        public void MaximumTripletValue1(int[] a0, long expected)
        {
            // Act
            long actual = _02873_MaximumValueOfAnOrderedTriplet1.MaximumTripletValue1(a0);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
