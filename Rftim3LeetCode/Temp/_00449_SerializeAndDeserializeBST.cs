using Rftim3Convoy.Temp.Construct.Terminal;
using Rftim3Atlas.Models;
using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00449_SerializeAndDeserializeBST
    {
        /// <summary>
        /// Serialization is converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, 
        /// or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
        /// 
        /// Design an algorithm to serialize and deserialize a binary search tree.
        /// There is no restriction on how your serialization/deserialization algorithm should work.
        /// You need to ensure that a binary search tree can be serialized to a string, 
        /// and this string can be deserialized to the original tree structure.
        /// 
        /// The encoded string should be as compact as possible.
        /// </summary>
        public _00449_SerializeAndDeserializeBST()
        {
            TreeNode a2 = new(3);
            TreeNode a1 = new(1);
            TreeNode a0 = new(2, a1, a2);

            List<int?> res = SerializeAndDeserializeBST0(a0);
            RftTerminal.RftReadResult(res); // [2,3,1]
        }

        public static List<int?> SerializeAndDeserializeBST0(TreeNode? a0) => RftSerializeAndDeserializeBST0(a0);

        private static List<int?> RftSerializeAndDeserializeBST0(TreeNode? root)
        {
            List<int?> res = [];
            _ = new
            Codec();
            string tree = Codec.Serialize(root!);
            TreeNode? ans = Codec.Deserialize(tree);

            Stack<TreeNode?> st = [];
            st.Push(ans);

            while (st.Count != 0)
            {
                TreeNode? t = st.Pop();
                res.Add(t!.val);

                if (t.left is not null) st.Push(t.left);
                if (t.right is not null) st.Push(t.right);
            }

            return res;
        }

        private class Codec
        {
            public static string Serialize(TreeNode root)
            {
                StringBuilder sb = Postorder(root, new StringBuilder());
                if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }

            public static TreeNode? Deserialize(string data)
            {
                if (data == "") return null;

                LinkedList<int> nums = [];

                foreach (string s in data.Split(" "))
                {
                    nums.AddLast(int.Parse(s));
                }

                return Helper(int.MinValue, int.MaxValue, nums);
            }
        }

        private static StringBuilder Postorder(TreeNode? root, StringBuilder sb)
        {
            if (root == null) return sb;

            Postorder(root.left, sb);
            Postorder(root.right, sb);

            sb.Append(root.val);
            sb.Append(' ');

            return sb;
        }

        private static TreeNode? Helper(int lower, int upper, LinkedList<int> nums)
        {
            if (nums.Count == 0) return null;

            int val = nums.Last();

            if (val < lower || val > upper) return null;

            nums.RemoveLast();
            TreeNode root = new(val)
            {
                right = Helper(val, upper, nums),
                left = Helper(lower, val, nums)
            };

            return root;
        }

        public class Codec1
        {
            public static string Serialize(TreeNode root)
            {
                if (root == null) return string.Empty;

                StringBuilder stringBuilder = new("V" + root.val);

                if (root.left != null) stringBuilder.Append("L" + Serialize(root.left));
                if (root.right != null) stringBuilder.Append("R" + Serialize(root.right));

                stringBuilder.Append('$');
                return stringBuilder.ToString();
            }

            public static TreeNode? Deserialize(string data)
            {
                int index = 0;

                return DeserializeNode(data, ref index);
            }

            private static TreeNode? DeserializeNode(string data, ref int index)
            {
                if (index >= data.Length) return null;
                if (data[index] == 'V')
                {
                    index++;
                    int startIndex = index;
                    while (index < data.Length && data[index] != 'L' && data[index] != 'R' && data[index] != '$')
                    {
                        index++;
                    }
                    TreeNode node = new(int.Parse(data[startIndex..index]));
                    if (data[index] == 'L')
                    {
                        index++;
                        node.left = DeserializeNode(data, ref index);
                    }
                    if (data[index] == 'R')
                    {
                        index++;
                        node.right = DeserializeNode(data, ref index);
                    }
                    if (data[index] == '$')
                    {
                        index++;
                        return node;
                    }
                }

                return null;
            }
        }
    }
}
