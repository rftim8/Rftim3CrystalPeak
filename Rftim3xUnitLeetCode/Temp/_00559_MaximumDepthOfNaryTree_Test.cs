using Rftim3Atlas.Models;

namespace Rftim3xUnitLeetCode.Temp
{
    public class _00559_MaximumDepthOfNaryTree_Test
    {
        // Arrange
        private static readonly List<Node> a0 = [new(1), new(3), new(2), new(4), new(5), new(6)];
        private static readonly int ar = 3;

        private static readonly List<Node> b0 = [new(1), new(2), new(3), new(4), new(5), new(6), new(7), new(8), new(9), new(10), new(11), new(12), new(13), new(14)];
        private static readonly int br = 5;

        public _00559_MaximumDepthOfNaryTree_Test()
        {
            a0[0].children = [a0[1], a0[2], a0[3]];
            a0[1].children = [a0[4], a0[5]];

            b0[0].children = [b0[1], b0[2], b0[3], b0[4]];
            b0[2].children = [b0[5], b0[6]];
            b0[3].children = [b0[7]];
            b0[4].children = [b0[8], b0[9]];
            b0[6].children = [b0[10]];
            b0[7].children = [b0[11]];
            b0[8].children = [b0[12]];
            b0[10].children = [b0[13]];
        }

        public static TheoryData<List<Node>, int> _00559_MaximumDepthOfNaryTree_Data =>
            new()
            {
                { a0, ar },
                { b0, 5 }
            };

        [Theory]
        [MemberData(nameof(_00559_MaximumDepthOfNaryTree_Data))]
        public void MaxDepth(List<Node> a0, int expected)
        {
            // Act
            //int actual = _00559_MaximumDepthOfNaryTree.MaxDepth0(a0[0]);

            // Assert
            //Assert.Equal(expected, actual);
        }
    }
}
