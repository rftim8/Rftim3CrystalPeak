using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00212_WordSearchII
    {
        /// <summary>
        /// Given an m x n board of characters and a list of strings words, return all words on the board.
        /// 
        /// Each word must be constructed from letters of sequentially adjacent cells, 
        /// where adjacent cells are horizontally or vertically neighboring.
        /// The same letter cell may not be used more than once in a word.
        /// </summary>
        public _00212_WordSearchII()
        {
            IList<string> x = WordSearchII0(
                [['o', 'a', 'a', 'n'], ['e', 't', 'a', 'e'], ['i', 'h', 'k', 'r'], ['i', 'f', 'l', 'v']],
                ["oath", "pea", "eat", "rain"]
                );
            RftTerminal.RftReadResult(x);

            IList<string> x0 = WordSearchII0(
                [['a', 'b'], ['c', 'd']],
                []
                );
            RftTerminal.RftReadResult(x0);
        }

        public static IList<string> WordSearchII0(char[][] a0, string[] a1) => RftWordSearchII0(a0, a1);

        // Backtracking with trie
        private static char[][]? _board;
        private static List<string>? _result;

        private static List<string> RftWordSearchII0(char[][] board, string[] words)
        {
            _result = [];
            TrieNode root = new();
            foreach (string word in words)
            {
                TrieNode node = root;

                foreach (char letter in word.ToCharArray())
                {
                    if (node.children.TryGetValue(letter, out TrieNode? value)) node = value;
                    else
                    {
                        TrieNode newNode = new();
                        node.children.Add(letter, newNode);
                        node = newNode;
                    }
                }
                node.word = word;
            }

            _board = board;

            for (int row = 0; row < board.Length; ++row)
            {
                for (int col = 0; col < board[row].Length; ++col)
                {
                    if (root.children.ContainsKey(board[row][col])) Backtracking(row, col, root);
                }
            }

            return _result;
        }

        private static void Backtracking(int row, int col, TrieNode parent)
        {
            char letter = _board![row][col];
            TrieNode currNode = parent.children[letter];

            if (currNode.word != null)
            {
                _result!.Add(currNode.word);
                currNode.word = null;
            }

            _board[row][col] = '#';

            int[] rowOffset = [-1, 0, 1, 0];
            int[] colOffset = [0, 1, 0, -1];
            for (int i = 0; i < 4; ++i)
            {
                int newRow = row + rowOffset[i];
                int newCol = col + colOffset[i];
                if (newRow < 0 ||
                    newRow >= _board.Length ||
                    newCol < 0 ||
                    newCol >= _board[0].Length)
                {
                    continue;
                }

                if (currNode.children.ContainsKey(_board[newRow][newCol])) Backtracking(newRow, newCol, currNode);
            }

            _board[row][col] = letter;

            if (currNode.children.Count == 0) parent.children.Remove(letter);
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> children = [];
            public string? word;

            public TrieNode() { }
        }
    }
}
