using Rftim3Atlas.Models;
using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00297_SerializeAndDeserializeBinaryTree
    {
        /// <summary>
        /// Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, 
        /// or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
        /// Design an algorithm to serialize and deserialize a binary tree.There is no restriction on how your serialization/deserialization algorithm should work.
        /// You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.
        /// Clarification: The input/output format is the same as how LeetCode serializes a binary tree. You do not necessarily need to follow this format,
        /// so please be creative and come up with different approaches yourself.
        /// </summary>
        public _00297_SerializeAndDeserializeBinaryTree()
        {
            TreeNode0 a4 = new(5);
            TreeNode0 a3 = new(4);
            TreeNode0 a2 = new(3, a3, a4);
            TreeNode0 a1 = new(2);
            TreeNode0 a0 = new(1, a1, a2);

            TreeNode0? ans = Codec.Deserialize(Codec.Serialize(a0));
            Console.WriteLine(ans?.val);
        }

        private class Codec
        {
            public static string Serialize(TreeNode0 root)
            {
                if (root is null) return "";

                StringBuilder sb = new();
                Queue<TreeNode0?> q = new();
                q.Enqueue(root);

                while (q.Any())
                {
                    TreeNode0? crt = q.Dequeue();

                    if (crt is not null)
                    {
                        sb.Append(crt.val + ",");
                        q.Enqueue(crt.left);
                        q.Enqueue(crt.right);
                    }
                    else sb.Append("#,");
                }

                return sb.ToString();
            }

            public static TreeNode0? Deserialize(string data)
            {
                if (data == "") return null;

                string[] nodes = data.Split(',', StringSplitOptions.RemoveEmptyEntries);
                Queue<TreeNode0> q = new();
                TreeNode0 root = new(int.Parse(nodes[0]));
                q.Enqueue(root);

                for (int i = 1; i < nodes.Length; i++)
                {
                    TreeNode0 crt = q.Dequeue();
                    if (nodes[i] != "#")
                    {
                        TreeNode0 left = new(int.Parse(nodes[i]));
                        crt.left = left;
                        q.Enqueue(left);
                    }

                    if (nodes[++i] != "#")
                    {
                        TreeNode0 right = new(int.Parse(nodes[i]));
                        crt.right = right;
                        q.Enqueue(right);
                    }
                }

                return root;
            }
        }

        private class Codec0
        {
            public string Serialize(TreeNode0? root)
            {
                string retVal = "#";
                if (root is null) return retVal;

                retVal += root.val;
                retVal += Serialize(root.left);
                retVal += Serialize(root.right);

                return retVal;
            }

            public TreeNode0? Deserialize(string data)
            {
                string localData = data;
                return Deserialize(ref localData);
            }

            private TreeNode0? Deserialize(ref string data)
            {
                TreeNode0? root = null;

                if (data.IndexOf("#", 1) == -1) return root;

                string val = data.Substring(1, data[1..].IndexOf("#"));
                if (string.IsNullOrEmpty(val)) return root;

                root = new TreeNode0(int.Parse(val));

                data = data[data.IndexOf("#", 1)..];
                root.left = Deserialize(ref data);

                data = data[data.IndexOf("#", 1)..];
                root.right = Deserialize(ref data);

                return root;
            }
        }
    }
}
