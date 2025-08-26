namespace Rftim3LeetCode.Temp
{
    public class _01640_CheckArrayFormationThroughConcatenation
    {
        /// <summary>
        /// You are given an array of distinct integers arr and an array of integer arrays pieces, where the integers in pieces are distinct. 
        /// Your goal is to form arr by concatenating the arrays in pieces in any order. 
        /// However, you are not allowed to reorder the integers in each array pieces[i].
        /// Return true if it is possible to form the array arr from pieces.Otherwise, return false.
        /// </summary>
        public _01640_CheckArrayFormationThroughConcatenation()
        {
            Console.WriteLine(CanFormArray(
                [15, 88],
                [
                    [88],
                    [15]
                ]
            ));
            Console.WriteLine(CanFormArray(
                [49, 18, 16],
                [
                    [16, 18, 49]
                ]
            ));
            Console.WriteLine(CanFormArray(
                [91, 4, 64, 78],
                [
                    [78],
                    [4,64],
                    [91]
                ]
            ));
        }

        private static bool CanFormArray(int[] arr, int[][] pieces)
        {
            for (int k = 0; k < pieces.Length; k++)
            {
                bool r = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i; j < arr.Length; j++)
                    {
                        if (pieces[k].Length == arr[i..(j + 1)].Length)
                        {
                            if (pieces[k].SequenceEqual(arr[i..(j + 1)]))
                            {
                                i = arr.Length;
                                r = true;
                                break;
                            }
                        }
                    }
                }
                if (r == false) return false;
            }

            return true;
        }

        private static bool CanFormArray0(int[] arr, int[][] pieces)
        {
            Dictionary<int, int[]> mapping = [];

            foreach (int[] piece in pieces)
            {
                mapping.Add(piece[0], piece);
            }

            int i = 0;
            while (i < arr.Length)
            {
                if (!mapping.TryGetValue(arr[i], out int[]? value)) return false;

                int[] targetPiece = value;
                foreach (int x in targetPiece)
                {
                    if (x != arr[i]) return false;

                    i++;
                }
            }

            return true;
        }
    }
}
