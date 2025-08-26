using Rftim3Console.System.Arrays;
using System.Collections;
using System.Globalization;

namespace Rftim3Console.System.Arrays
{
    class RftArray
    {
        private static readonly int[] aa = new int[10];
        private static readonly int[,] aa1 = new int[5, 5];
        private static readonly int[,,] aa2 = new int[5, 5, 5];
        private static readonly int[][] aa3 = new int[3][];
        private static string[] b = ["ab", "cd", "ef", "gh", "ij"];
        private static readonly int[] c = [.. Enumerable.Repeat(0, 40)];

        #region 1D
        private readonly int[] a1 = [1, 2, 3, 4, 5];
        private readonly string[] sa1 = ["cpp", "cs", "js", "ts", "cpp"];
        private readonly string[] sai1 = ["1", "2", "3", "4", "5"];
        private readonly CultureInfo[] cia1 = [
            new("ar-SA", false),
            new("en-US", false),
            new("fr-FR", false),
            new("ja-JP", false)
        ];
        #endregion

        #region 2D
        private readonly int[,] a2sq = new int[,] {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        private readonly int[,] a2 = new int[,] {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},
            {4, 5, 6},
            {1, 2, 3}
        };
        private readonly int[][] j2 = [
            [1,2,3],
            [4,5,6,8,10],
            [7,8,9]
        ];
        #endregion

        #region 3D
        private readonly int[,,] a3cube = new int[,,] {
            {{ 1,2,3 }, { 4,5,6 }, { 7,8,9 }},
            {{ 1,2,3 }, { 4,5,6 }, { 7,8,9 }},
            {{ 1,2,3 }, { 4,5,6 }, { 7,8,9 }}
        };
        private readonly int[,,] a3 = new int[,,] {
            {{ 1 }, { 5 }, { 7 }},
            {{ 1 }, { 5 }, { 7 }},
            {{ 1 }, { 5 }, { 7 }}
        };
        private readonly int[][][] j3 = [
            [
                [1,2,3],
                [4,5,6],
                [7,8,9]
            ]
            ,
            [
                [1,2,3],
                [4,5,6],
                [7,8,9]
            ]
            ,
            [
                [1,2,3],
                [4,5,6],
                [7,8,9]
            ]
        ];
        #endregion

        public RftArray()
        {
            RftBasic();
            //RftJagged();
            //RftLinq();
            //RftLinqConvert();

            //RftStopwatch rftStopwatch = new();

            #region Print
            #region 1D
            //Rft1D(a1);
            #endregion

            #region 2D
            //Rft2DSquare(a2sq);
            //Rft2D(a2);
            //Rft2DJagged(j2);
            #endregion

            #region 3D
            //Rft3DCube(a3cube);
            //Rft3D(a3);
            //Rft3DJagged(j3);
            #endregion
            #endregion

            #region Ops
            //RftAsReadOnly(sa1);

            RftBinarySearch();

            //RftBinarySearchT(sa1);
            //RftClear(a1);
            //RftClone(cia1);
            //RftConvertAll(sai1);
            //RftCopy(a1);
            //RftCopyTo(a1);
            //RftCreateInstance();
            //RftExists(sa1);
            //RftFindAll(sa1);
            //RftFindIndex(sa1);
            //RftFindLastIndex(sa1);
            //RftFind(sa1);
            //RftForEach(a1);
            //RftGetEnumerator(sa1);
            //RftGetLength(a2);
            //RftGetLowerBound(a1);
            //RftIndexOf(sa1);
            //RftIsSynchronized(a1);
            //RftLastIndexOf(sa1);
            //RftLength(a1);
            //RftRank(a2);
            //RftResize(a1);
            //RftReverse(a1);
            //RftSort(sa1);
            //RftSortKvp();
            //RftTrueForAll(a1);
            #endregion

            //rftStopwatch.RftStopwatchStop();
        }

        private static void RftBasic()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    aa1[i, j] = i;
                    Console.Write($" {aa1[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\n\n");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        aa2[i, j, k] = i;
                        Console.Write($" {aa2[i, j, k]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            aa3[0] = new int[5];
            aa3[1] = new int[2];
            aa3[2] = new int[3];

            Console.WriteLine();
            for (int i = 0; i < aa.Length; i++)
            {
                aa[i] = i * i;
                Console.WriteLine($"a[{i}] = {aa[i]}");
            }
            Console.WriteLine();

            Array.Clear(aa, 2, 5);
            foreach (int item in aa)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Array.Clear(b, 2, 2);
            Array.Resize(ref b, 3);
            foreach (string item in b)
            {
                if (!string.IsNullOrEmpty(item)) Console.Write($"{item} ");
                else Console.Write("x ");
            }
        }

        private static void RftJagged()
        {
            int[][] jagged =
            [
                [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
                [10, 11, 12, 13, 14, 15, 16, 17, 18, 19],
                [20, 21, 22, 23, 24, 25, 26, 27, 28, 29],
                [30, 31, 32, 33, 34, 35, 36, 37, 38, 39],
                [40, 41, 42, 43, 44, 45, 46, 47, 48, 49],
                [40, 41, 42, 43, 44, 45, 46, 47, 48, 49],
                [40, 41, 42, 43, 44, 45, 46, 47, 48, 49],
                [40, 41, 42, 43, 44, 45, 46, 47, 48, 49],
                [40, 41, 42, 43, 44, 45, 46, 47, 48, 49],
                [40, 41, 42, 43, 44, 45, 46, 47, 48, 49]
            ];

            int[][] selectedRows = jagged[3..^3];

            foreach (int[] item in selectedRows)
            {
                int[] selectedColumns = item[2..^2];
                foreach (int cell in selectedColumns)
                {
                    Console.WriteLine($"{cell}, ");
                }
            }
        }

        private static void RftLinq()
        {
            long[] xs = [.. (Console.ReadLine() ?? string.Empty).Split(' ').Select(long.Parse)];
            long[] ys = [.. (Console.ReadLine() ?? string.Empty).Split(' ').Select(long.Parse)];
            Array.Sort(xs);
            Array.Sort(ys);
            for (int i = 0; i < xs.Length; i++)
            {
                Console.Write("(");
                Console.Write(xs[i]);
                Console.Write(", ");
                Console.Write(ys[i]);
                Console.Write(")");
                if (i < xs.Length - 1) Console.Write(", ");
            }
        }

        private static void RftLinqConvert()
        {
            int n = int.Parse(Console.ReadLine() ?? string.Empty);

            int[,] matrix = new int[n + 2, n + 2];
            for (int y = 0; y < n; y++)
            {
                int[] input = Array.ConvertAll((Console.ReadLine() ?? string.Empty).Replace("b", "-1").Replace("o", "0").Split(), int.Parse);

                for (int x = 0; x < n; x++)
                {
                    matrix[y + 1, x + 1] = input[x];
                }
            }
        }

        #region Print
        private static void Rft1D(int[] a1)
        {
            Console.WriteLine("1D Array:");
            RftArray1D.RftPrint(a1);
        }
        private static void Rft2DSquare(int[,] a2sq)
        {
            Console.WriteLine("2D Array Square:");
            RftArray2D.RftPrintSquare(a2sq);
        }
        private static void Rft2D(int[,] a2)
        {
            Console.WriteLine("2D Array:");
            RftArray2D.RftPrint(a2);
        }
        private static void Rft2DJagged(int[][] j2)
        {
            Console.WriteLine("2D Array Jagged:");
            RftArray2D.RftPrintJagged(j2);
        }
        private static void Rft3DCube(int[,,] a3cube)
        {
            Console.WriteLine("3D Array:");
            RftArray3D.RftPrintCube(a3cube);
        }
        private static void Rft3D(int[,,] a3)
        {
            Console.WriteLine("3D Array:");
            RftArray3D.RftPrint(a3);
        }
        private static void Rft3DJagged(int[][][] j3)
        {
            Console.WriteLine("3D Array Jagged:");
            RftArray3D.RftPrintJagged(j3);
        }
        #endregion

        #region Ops
        private static void RftAsReadOnly(string[] sa1)
        {
            Console.WriteLine("Read only:");
            IList<string> il = Array.AsReadOnly(sa1);
            sa1[0] = "python";
            RftArray1D.RftPrint([il]);
        }

        public static void RftBinarySearch()
        {
            Console.WriteLine("Binary search:");
            Array b = Array.CreateInstance(typeof(int), 5);
            b.SetValue(8, 0);
            b.SetValue(2, 1);
            b.SetValue(6, 2);
            b.SetValue(3, 3);
            b.SetValue(7, 4);
            Array.Sort(b);

            int index = Array.BinarySearch(b, 1);
            Console.WriteLine(index < 0 ? $"Next larger object at: {~index}" : $"Found at index: {index}");
        }
        private static void RftBinarySearchT<T>(T[] sa1)
        {
            Console.WriteLine("Binary search T:");
            RftArray1D.RftPrint(sa1);
            Array.Sort(sa1);
            int index = Array.BinarySearch(sa1, "cq");
            Console.WriteLine(index < 0 ? $"Next larger at: {~index}" : $"Found at index: {index}");
        }
        private static void RftClear(int[] a)
        {
            Console.WriteLine("Clear:");
            Array.Clear(a, 2, 2);
            RftArray1D.RftPrint(a);
            Array.Clear(a);
            RftArray1D.RftPrint(a);
        }
        private static void RftClone(CultureInfo[] cia1)
        {
            Console.WriteLine("Clone:");
            CultureInfo[] a = (CultureInfo[])cia1.Clone();
            RftArray1D.RftPrint(a);
        }
        private static void RftConvertAll(string[] sai1)
        {
            Console.WriteLine("Convert all:");
            int[] a = Array.ConvertAll(sai1, int.Parse);
            RftArray1D.RftPrint(a);
        }
        private static void RftCopy(int[] a)
        {
            Console.WriteLine("Copy:");
            int n = a.Length;
            int[] b = new int[n];
            Array.Copy(a, b, n);
            RftArray1D.RftPrint(b);
        }
        private static void RftCopyTo(int[] a1)
        {
            Console.WriteLine("Copy to:");
            int[] b = [5, 4, 3, 2];
            Array.Resize(ref b, a1.Length + b.Length + 1);
            a1.CopyTo(b, 4);
            RftArray1D.RftPrint(b);
        }
        private static void RftCreateInstance()
        {
            Console.WriteLine("Create instance:");
            int[] a1 = (int[])Array.CreateInstance(typeof(int), 10);
            a1[5] = 5;
            RftArray1D.RftPrint(a1);

            //Enumerable as initializer
            int[] c = [.. Enumerable.Repeat(0, 10)];
            RftArray1D.RftPrint(c);

            int x = 3;
            int[,] a2 = (int[,])Array.CreateInstance(typeof(int), x, x);
            RftArray2D.RftPrint(a2);
        }
        private static void RftExists(string[] sa1)
        {
            Console.WriteLine("Exists:");
            Console.WriteLine(Array.Exists(sa1, StartsWith));

            static bool StartsWith(string s)
            {
                if (string.IsNullOrEmpty(s)) return false;
                return s[0] == 'c';
            }

            Console.WriteLine(Array.Exists(sa1, o => o.StartsWith('c')));

            Console.WriteLine(Array.Exists(sa1, o =>
            {
                if (string.IsNullOrEmpty(o)) return false;
                return o[0] == 'c';
            }));
        }
        private static void RftFindAll(string[] sa1)
        {
            Console.WriteLine("Find all:");
            string[] a = Array.FindAll(sa1, o => o.StartsWith('c'));
            RftArray1D.RftPrint(a);
        }
        private static void RftFindIndex(string[] sa1)
        {
            Console.WriteLine("Find index:");
            Console.WriteLine(Array.FindIndex(sa1, 0, o => o == "js"));
        }
        private static void RftFindLastIndex(string[] sa1)
        {
            Console.WriteLine("Find last index:");
            Console.WriteLine(Array.FindLastIndex(sa1, o => o == "cpp"));
        }
        private static void RftFind(string[] sa1)
        {
            Console.WriteLine("Find:");
            Console.WriteLine(Array.Find(sa1, o => o == "js"));
        }
        private static void RftForEach(int[] a1)
        {
            Console.WriteLine("For each:");
            Array.ForEach(a1, RftPrintValue);
            static void RftPrintValue(int value)
            {
                Console.WriteLine(value * value);
            }

            Array.ForEach(a1, o =>
            {
                Console.WriteLine(o * o);
            });
        }
        private static void RftGetEnumerator(string[] sa1)
        {
            Console.WriteLine("Get enumerator:");
            IEnumerator enumerator = sa1.GetEnumerator();
            while (enumerator.MoveNext() && enumerator.Current is not null)
            {
                Console.WriteLine(enumerator.Current);
            }
        }
        private static void RftGetLength(int[,] a2)
        {
            Console.WriteLine("Length:");
            for (int i = 0; i < a2.Rank; i++)
            {
                Console.WriteLine(a2.GetLength(i));
            }
        }
        private static void RftGetLowerBound(int[] a1)
        {
            Console.WriteLine("Lower/Upper bounds:");
            Console.WriteLine($"Lower bound: {a1.GetLowerBound(0)}");
            Console.WriteLine($"Upper bound: {a1.GetUpperBound(0)}");
        }
        private static void RftIndexOf(string[] sa1)
        {
            Console.WriteLine("Index of:");
            Console.WriteLine(Array.IndexOf(sa1, "js"));
        }
        private static void RftIsSynchronized(int[] a1)
        {
            Console.WriteLine("Is synchronized:");
            lock (a1.SyncRoot)
            {
                foreach (object item in a1)
                {
                    Console.WriteLine(item);
                }
            }
        }
        private static void RftLastIndexOf(string[] sa1)
        {
            Console.WriteLine("Last index of:");
            Console.WriteLine(Array.LastIndexOf(sa1, "cpp"));
        }
        private static void RftLength(int[] a1)
        {
            Console.WriteLine("Length:");
            Console.WriteLine($"Number of elements: {a1.Length}");
        }
        private static void RftRank(int[,] a2)
        {
            Console.WriteLine("Rank:");
            Console.WriteLine(a2.Rank);
        }
        private static void RftResize(int[] a1)
        {
            Console.WriteLine("Resize:");
            Array.Resize(ref a1, 10);
            RftArray1D.RftPrint(a1);
        }
        private static void RftReverse(int[] a1)
        {
            Console.WriteLine("Reverse:");
            Array.Reverse(a1, 2, 3);
            RftArray1D.RftPrint(a1);
        }
        private static void RftSort(string[] sa1)
        {
            Console.WriteLine("Sort:");
            Array.Sort(sa1, (a, b) => b.CompareTo(a));
            RftArray1D.RftPrint(sa1);
        }
        private static void RftSortKvp()
        {
            Console.WriteLine("Sort kvp:");
            string[] a = ["a", "b", "c"];
            int[] b = [3, 2, 1];
            Array.Sort(a, b, new RftComparerReverse());
            RftArray1D.RftPrint(a);
            RftArray1D.RftPrint(b);
        }
        private static void RftTrueForAll(int[] a1)
        {
            Console.WriteLine("True for all:");
            Console.WriteLine(Array.TrueForAll(a1, o =>
            {
                return o % 1 == 0;
            }));
        }
        #endregion
    }

    public class RftComparerReverse : IComparer
    {
        public int Compare(object? x, object? y)
        {
            return new CaseInsensitiveComparer().Compare(y, x);
        }
    }
}
