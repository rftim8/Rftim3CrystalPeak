using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _14_OneTimePad : I_14_OneTimePad
    {
        #region Static
        private readonly List<string>? data;

        public _14_OneTimePad()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_14_OneTimePad));
        }

        /// <summary>
        /// In order to communicate securely with Santa while you're on this mission, you've been using a one-time pad that you generate using a pre-agreed algorithm. 
        /// Unfortunately, you've run out of keys in your one-time pad, and so you need to generate some more.
        /// 
        /// To generate keys, you first get a stream of random data by taking the MD5 of a pre-arranged salt(your puzzle input) and an increasing 
        /// integer index(starting with 0, and represented in decimal); the resulting MD5 hash should be represented as a string of lowercase hexadecimal digits.
        /// 
        /// However, not all of these MD5 hashes are keys, and you need 64 new keys for your one-time pad.A hash is a key only if:
        /// 
        /// It contains three of the same character in a row, like 777. Only consider the first such triplet in a hash.
        /// One of the next 1000 hashes in the stream contains that same character five times in a row, like 77777.
        /// Considering future hashes for five-of-a-kind sequences does not cause those hashes to be skipped; 
        /// instead, regardless of whether the current hash is a key, always resume testing for keys starting with the very next hash.
        /// 
        /// For example, if the pre-arranged salt is abc:
        /// 
        /// The first index which produces a triple is 18, because the MD5 hash of abc18 contains...cc38887a5....However, 
        /// index 18 does not count as a key for your one-time pad, because none of the next thousand hashes(index 19 through index 1018) contain 88888.
        /// The next index which produces a triple is 39; the hash of abc39 contains eee.It is also the first key:
        /// one of the next thousand hashes (the one at index 816) contains eeeee.
        /// None of the next six triples are keys, but the one after that, at index 92, is: it contains 999 and index 200 contains 99999.
        /// Eventually, index 22728 meets all of the criteria to generate the 64th key.
        /// So, using our example salt of abc, index 22728 produces the 64th key.
        /// 
        /// Given the actual salt in your puzzle input, what index produces your 64th one-time pad key?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            Salt = input[0];
            int keyCount = 0;
            Stopwatch sw = Stopwatch.StartNew();
            while (keyCount != 64)
            {
                _index++;

                string hash = CalculateMd5Hash($"{Salt}{_index}");
                Match match = KeyRegex.Match(hash);
                if (!match.Success) continue;

                string keyMatch = new(match.Value[0], 5);
                for (int i = 1; i <= 1000; i++)
                {
                    int matchIndex = _index + i;
                    string nextHash = CalculateMd5Hash($"{Salt}{matchIndex}");

                    if (!nextHash.Contains(keyMatch)) continue;

                    keyCount++;
                    //Console.WriteLine(GenerateFoundKeyMessage(1, keyCount, nextHash, i));

                    break;
                }
            }
            sw.Stop();

            //return GenerateResultMessage(1, _index, sw);
            return _index;
        }

        /// <summary>
        /// Of course, in order to make this process even more secure, you've also implemented key stretching.
        /// 
        /// Key stretching forces attackers to spend more time generating hashes.Unfortunately, it forces everyone else to spend more time, too.
        /// To implement key stretching, whenever you generate a hash, before you use it, you first find the MD5 hash of that hash, then the MD5 hash of that hash, 
        /// and so on, a total of 2016 additional hashings. Always use lowercase hexadecimal representations of hashes.
        /// 
        /// For example, to find the stretched hash for index 0 and salt abc:
        /// 
        /// Find the MD5 hash of abc0: 577571be4de9dcce85a041ba0410f29f.
        /// Then, find the MD5 hash of that hash: eec80a0c92dc8a0777c619d9bb51e910.
        /// Then, find the MD5 hash of that hash: 16062ce768787384c81fe17a7a60c7e3.
        /// ...repeat many times...
        /// Then, find the MD5 hash of that hash: a107ff634856bb300138cac6568c0f24.
        /// So, the stretched hash for index 0 in this situation is a107ff....In the end, you find the original hash (one use of MD5), 
        /// then find the hash-of-the-previous-hash 2016 times, for a total of 2017 uses of MD5.
        /// 
        /// The rest of the process remains the same, but now the keys are entirely different.Again for salt abc:
        /// 
        /// The first triple (222, at index 5) has no matching 22222 in the next thousand hashes.
        /// The second triple (eee, at index 10) hash a matching eeeee at index 89, and so it is the first key.
        /// Eventually, index 22551 produces the 64th key(triple fff with matching fffff at index 22859.
        /// Given the actual salt in your puzzle input and using 2016 extra MD5 calls of key stretching, what index now produces your 64th one-time pad key?
        /// </summary>        
        [Benchmark]
        public int PartTwo() => PartTwo0(data!);

        private static int PartTwo0(List<string> input)
        {
            _index = -1;
            Salt = input[0];
            Stopwatch sw = Stopwatch.StartNew();
            while (KeyList.Count < 64)
            {
                _index++;
                string hash;
                if (HashList.Count == _index)
                {
                    string hashSource = GenerateHashInput(_index);
                    hash = AddHash(GenerateMd5Part2(hashSource));
                }
                else hash = HashList[_index];

                Match triplet = TripletRegex.Match(hash);
                if (!triplet.Success) continue;
                string quintet = new(triplet.Value[0], 5);

                for (var i = 1; i <= 1000; i++)
                {
                    int index = _index + i;
                    string nextHash = HashList.Count == index
                                          ? AddHash(GenerateMd5Part2(GenerateHashInput(index)))
                                          : HashList[index];
                    if (!nextHash.Contains(quintet)) continue;
                    KeyList.Add(hash);
                    //Console.WriteLine(GenerateFoundKeyMessage(2, KeyList.Count, hash, _index));
                    break;
                }
            }
            sw.Stop();
            Md5Hash.Dispose();

            //return GenerateResultMessage(2, _index, sw);
            return _index;
        }

        private static string? Salt;
        private static readonly Regex KeyRegex = MyRegex();
        private static int _index = -1;
        private static readonly Regex TripletRegex = MyRegex1();
        private static readonly List<string> HashList = [];
        private static readonly List<string> KeyList = [];
        private static readonly MD5 Md5Hash = MD5.Create();

        private class Container
        {
            public char Char;
            public int Counter;
            public int Index;
        }

        private static string GenerateResultMessage(int part, int index, Stopwatch sw) => $"Part {part}: 64th key found at index {index} in {new TimeSpan(sw.ElapsedTicks):g}.";

        private static string GenerateFoundKeyMessage(int part, int count, string hash, int index) => $"Part {part}: Found key {count,-3}: {hash} (index {index})";

        private static string CalculateMd5Hash(string input)
        {
            byte[] source = Encoding.ASCII.GetBytes(input);
            byte[] hash = MD5.HashData(source);

            StringBuilder sb = new();
            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString().ToLower();
        }

        private static string GetMd5Hash(string input)
        {
            byte[] data = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new();

            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static string GenerateHashInput(int index) => $"{Salt}{index}";

        private static string AddHash(string input)
        {
            string hash = GetMd5Hash(input);
            HashList.Add(hash);

            return hash;
        }

        private static string GenerateMd5Part2(string input)
        {
            for (var i = 0; i < 2016; i++)
            {
                input = GetMd5Hash(input);
            }

            return input;
        }

        [GeneratedRegex(@"(.)\1{2}")]
        private static partial Regex MyRegex();
        [GeneratedRegex(@"(\w)\1{2}")]
        private static partial Regex MyRegex1();
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static int PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _14_OneTimePad(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_14_OneTimePad));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}