using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _01642_FurthestBuildingYouCanReach_Test
    {
        // Arrange
        private static readonly int[] a0 = [4, 2, 7, 6, 9, 14, 12];
        private static readonly int a1 = 5, a2 = 1, ar = 4;

        private static readonly int[] b0 = [4, 12, 2, 7, 3, 18, 20, 3, 19];
        private static readonly int b1 = 10, b2 = 2, br = 7;

        private static readonly int[] c0 = [14, 3, 19, 3];
        private static readonly int c1 = 17, c2 = 0, cr = 3;

        public static TheoryData<int[], int, int, int> _01642_FurthestBuildingYouCanReach_Data =>
            new()
            {
                { a0, a1, a2, ar },
                { b0, b1, b2, br },
                { c0, c1, c2, cr }
            };


        [Theory]
        [MemberData(nameof(_01642_FurthestBuildingYouCanReach_Data))]
        public void FurthestBuildingYouCanReach0(int[] a0, int a1, int a2, int expected)
        {
            // Act
            int actual = _01642_FurthestBuildingYouCanReach.FurthestBuildingYouCanReach0(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01642_FurthestBuildingYouCanReach_Data))]
        public void FurthestBuildingYouCanReach1(int[] a0, int a1, int a2, int expected)
        {
            // Act
            int actual = _01642_FurthestBuildingYouCanReach.FurthestBuildingYouCanReach1(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01642_FurthestBuildingYouCanReach_Data))]
        public void FurthestBuildingYouCanReach2(int[] a0, int a1, int a2, int expected)
        {
            // Act
            int actual = _01642_FurthestBuildingYouCanReach.FurthestBuildingYouCanReach2(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01642_FurthestBuildingYouCanReach_Data))]
        public void FurthestBuildingYouCanReach3(int[] a0, int a1, int a2, int expected)
        {
            // Act
            int actual = _01642_FurthestBuildingYouCanReach.FurthestBuildingYouCanReach3(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01642_FurthestBuildingYouCanReach_Data))]
        public void FurthestBuildingYouCanReach4(int[] a0, int a1, int a2, int expected)
        {
            // Act
            int actual = _01642_FurthestBuildingYouCanReach.FurthestBuildingYouCanReach4(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_01642_FurthestBuildingYouCanReach_Data))]
        public void FurthestBuildingYouCanReach5(int[] a0, int a1, int a2, int expected)
        {
            // Act
            int actual = _01642_FurthestBuildingYouCanReach.FurthestBuildingYouCanReach5(a0, a1, a2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}