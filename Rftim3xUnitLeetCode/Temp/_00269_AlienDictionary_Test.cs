using Rftim3LeetCode.Temp;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00269_AlienDictionary_Test
    {
        // Arrange
        private static readonly string[] a0 = ["wrt", "wrf", "er", "ett", "rftt"];
        private static readonly string ar = "wertf";

        private static readonly string[] b0 = ["z", "x"];
        private static readonly string br = "zx";

        private static readonly string[] c0 = ["z", "x", "z"];
        private static readonly string cr = "";

        public static TheoryData<string[], string> _00269_AlienDictionary_Data =>
            new()
            {
                { a0, ar },
                { b0, br },
                { c0, cr }
            };


        [Theory]
        [MemberData(nameof(_00269_AlienDictionary_Data))]
        public void AlienDictionary0(string[] a0, string expected)
        {
            // Act
            string actual = _00269_AlienDictionary.AlienDictionary0(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00269_AlienDictionary_Data))]
        public void AlienDictionary1(string[] a0, string expected)
        {
            // Act
            string actual = _00269_AlienDictionary.AlienDictionary1(a0);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(_00269_AlienDictionary_Data))]
        public void AlienDictionary2(string[] a0, string expected)
        {
            // Act
            string actual = _00269_AlienDictionary.AlienDictionary2(a0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}