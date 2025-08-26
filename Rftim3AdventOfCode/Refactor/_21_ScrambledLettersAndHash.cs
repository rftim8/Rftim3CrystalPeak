using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3AdventOfCode.Refactor;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;
using System.Text.RegularExpressions;

namespace Rftim3AdventOfCode
{
    public partial class _21_ScrambledLettersAndHash : I_21_ScrambledLettersAndHash
    {
        #region Static
        private readonly List<string>? data;

        public _21_ScrambledLettersAndHash()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_21_ScrambledLettersAndHash));
        }

        /// <summary>
        /// The computer system you're breaking into uses a weird scrambling function to store its passwords.
        /// It shouldn't be much trouble to create your own scrambled password so you can add it to the system; you just have to implement the scrambler.
        /// 
        /// The scrambling function is a series of operations(the exact list is provided in your puzzle input). 
        /// Starting with the password to be scrambled, apply each operation in succession to the string. 
        /// The individual operations behave as follows:
        /// 
        /// swap position X with position Y means that the letters at indexes X and Y(counting from 0) should be swapped.
        /// swap letter X with letter Y means that the letters X and Y should be swapped(regardless of where they appear in the string).
        /// rotate left/right X steps means that the whole string should be rotated; for example, one right rotation would turn abcd into dabc.
        /// rotate based on position of letter X means that the whole string should be rotated to the right based on the index of letter X (counting from 0) 
        /// as determined before this instruction does any rotations.
        /// Once the index is determined, rotate the string to the right one time, plus a number of times equal to that index, plus one additional time if the index was at least 4.
        /// reverse positions X through Y means that the span of letters at indexes X through Y (including the letters at X and Y) should be reversed in order.
        /// move position X to position Y means that the letter which is at index X should be removed from the string, then inserted such that it ends up at index Y.
        /// For example, suppose you start with abcde and perform the following operations:
        /// 
        /// swap position 4 with position 0 swaps the first and last letters, producing the input for the next step, ebcda.
        /// swap letter d with letter b swaps the positions of d and b: edcba.
        /// reverse positions 0 through 4 causes the entire string to be reversed, producing abcde.
        /// rotate left 1 step shifts all letters left one position, causing the first letter to wrap to the end of the string: bcdea.
        /// move position 1 to position 4 removes the letter at position 1 (c), then inserts it at position 4 (the end of the string): bdeac.
        /// move position 3 to position 0 removes the letter at position 3 (a), then inserts it at position 0 (the front of the string): abdec.
        /// rotate based on position of letter b finds the index of letter b(1), then rotates the string right once plus a number of times equal to that index(2): ecabd.
        /// rotate based on position of letter d finds the index of letter d(4), then rotates the string right once, plus a number of times equal to that index, 
        /// plus an additional time because the index was at least 4, for a total of 6 right rotations: decab.
        /// After these steps, the resulting scrambled password is decab.
        /// 
        /// Now, you just need to generate a new scrambled password and you can access the system.Given the list of scrambling operations in your puzzle input,
        /// what is the result of scrambling abcdefgh?
        /// </summary>
        [Benchmark]
        public string PartOne() => PartOne0(data!);

        private static string PartOne0(List<string> input)
        {
            char[] buffer = new char[input1.Length];
            Array.Copy(input1.ToCharArray(), buffer, input1.Length);
            for (int i = 0; i < input.Count; i++)
            {
                string instruction = input[i];
                Scramble(ref buffer, instruction);
                //Console.Write(buffer);
                //Console.WriteLine("->{0}:\t{1}", new string(buffer), instruction);
            }

            return new string(buffer);
        }

        /// <summary>
        /// You scrambled the password correctly, but you discover that you can't actually modify the password file on the system. 
        /// You'll need to un-scramble one of the existing passwords by reversing the scrambling process.
        /// 
        /// What is the un-scrambled version of the scrambled password fbgdceah?
        /// </summary>        
        [Benchmark]
        public string PartTwo() => PartTwo0(data!);

        private static string PartTwo0(List<string> input)
        {
            char[] buffer = new char[input2.Length];
            Array.Copy(input2.ToCharArray(), buffer, input2.Length);
            for (int i = input.Count - 1; i >= 0; i--)
            {
                string instruction = input[i];
                string scrubbled = new(buffer);
                Unscramble(ref buffer, instruction);
                //Console.Write(new string(buffer));
                //Console.WriteLine("->{0}:\t{1}", scrubbled, instruction);

                char[] newbuffer = new char[buffer.Length]; Array.Copy(buffer, newbuffer, buffer.Length);
                Scramble(ref newbuffer, instruction);
                if (new string(newbuffer) != scrubbled) return scrubbled;
            }

            return new string(buffer);
        }

        private const string input1 = "abcdefgh";
        private const string input2 = "fbgdceah";
        private static readonly Regex reg = MyRegex();
        private static readonly Regex regRotate = MyRegex1();
        private static readonly Regex regRevOrMove = MyRegex2();

        private static void Scramble(ref char[] buffer, string instruction)
        {
            Match match = reg.Match(instruction);
            if (match.Success)
            {
                if (match.Groups[1].Value == "position")
                {
                    int from = int.Parse(match.Groups[2].Value);
                    int to = int.Parse(match.Groups[3].Value);
                    (buffer[to], buffer[from]) = (buffer[from], buffer[to]);
                }
                else
                {
                    char cfrom = match.Groups[2].Value[0];
                    char cto = match.Groups[3].Value[0];
                    for (int t = 0; t < buffer.Length; t++)
                    {
                        if (buffer[t] == cfrom) buffer[t] = cto;
                        else if (buffer[t] == cto) buffer[t] = cfrom;
                    }
                }

                return;
            }
            match = regRotate.Match(instruction);
            if (match.Success)
            {
                string pattern = match.Groups[1].Value;
                int X;
                if (pattern.StartsWith("based"))
                {
                    X = Array.IndexOf(buffer, match.Groups[2].Value[0]);
                    X += X > 3 ? 2 : 1;
                    pattern = "right";
                }
                else X = int.Parse(match.Groups[2].Value);

                X %= buffer.Length;

                if (X == 0)
                {
                    Console.WriteLine("Nothing! X is 0.");
                    return;
                }

                if (pattern == "left")
                {
                    char[] newbuffer = new char[buffer.Length];
                    Array.Copy(buffer, X, newbuffer, 0, buffer.Length - X);
                    Array.Copy(buffer, 0, newbuffer, buffer.Length - X, X);
                    buffer = newbuffer;
                }
                else
                {
                    char[] newbuffer = new char[buffer.Length];
                    Array.Copy(buffer, 0, newbuffer, X, buffer.Length - X);
                    Array.Copy(buffer, buffer.Length - X, newbuffer, 0, X);
                    buffer = newbuffer;
                }

                return;
            }

            match = regRevOrMove.Match(instruction);
            if (match.Success)
            {
                string pattern = match.Groups[1].Value;
                int from = int.Parse(match.Groups[2].Value);
                int to = int.Parse(match.Groups[4].Value);

                if (pattern == "reverse")
                {
                    int l = to - from;
                    for (int t = 0; t <= l / 2; t++)
                    {
                        (buffer[to - t], buffer[from + t]) = (buffer[from + t], buffer[to - t]);
                    }
                }
                else
                {
                    char fromx = buffer[from];

                    if (from < to) Array.Copy(buffer, from + 1, buffer, from, to - from);
                    else Array.Copy(buffer, to, buffer, to + 1, from - to);

                    buffer[to] = fromx;
                }

            }
        }

        private static void Unscramble(ref char[] buffer, string instruction)
        {
            Match match = reg.Match(instruction);
            if (match.Success)
            {
                if (match.Groups[1].Value == "position")
                {
                    int from = int.Parse(match.Groups[3].Value);
                    int to = int.Parse(match.Groups[2].Value);
                    (buffer[to], buffer[from]) = (buffer[from], buffer[to]);
                }
                else
                {
                    char cfrom = match.Groups[2].Value[0];
                    char cto = match.Groups[3].Value[0];
                    for (int t = 0; t < buffer.Length; t++)
                    {
                        if (buffer[t] == cfrom) buffer[t] = cto;
                        else if (buffer[t] == cto) buffer[t] = cfrom;
                    }
                }

                return;
            }
            match = regRotate.Match(instruction);
            if (match.Success)
            {
                string pattern = match.Groups[1].Value;
                int X;
                if (pattern.StartsWith("based"))
                {
                    X = Array.IndexOf(buffer, match.Groups[2].Value[0]);
                    if (X % 2 == 0) X = (X + buffer.Length) / 2 + 1;
                    else X = X / 2 + 1;

                    pattern = "right";
                }
                else X = int.Parse(match.Groups[2].Value);

                X %= buffer.Length;

                if (X == 0) return;

                if (pattern == "right")
                {
                    char[] newbuffer = new char[buffer.Length];
                    Array.Copy(buffer, X, newbuffer, 0, buffer.Length - X);
                    Array.Copy(buffer, 0, newbuffer, buffer.Length - X, X);
                    buffer = newbuffer;
                }
                else
                {
                    char[] newbuffer = new char[buffer.Length];
                    Array.Copy(buffer, 0, newbuffer, X, buffer.Length - X);
                    Array.Copy(buffer, buffer.Length - X, newbuffer, 0, X);
                    buffer = newbuffer;
                }

                return;
            }

            match = regRevOrMove.Match(instruction);
            if (match.Success)
            {
                string pattern = match.Groups[1].Value;
                int from = int.Parse(match.Groups[2].Value);
                int to = int.Parse(match.Groups[4].Value);

                if (pattern == "reverse")
                {
                    int l = to - from;
                    for (int t = 0; t <= l / 2; t++)
                    {
                        (buffer[to - t], buffer[from + t]) = (buffer[from + t], buffer[to - t]);
                    }
                }
                else
                {
                    (to, from) = (from, to);
                    char fromx = buffer[from];

                    if (from < to) Array.Copy(buffer, from + 1, buffer, from, to - from);
                    else Array.Copy(buffer, to, buffer, to + 1, from - to);

                    buffer[to] = fromx;
                }
            }
        }

        [GeneratedRegex(@"^swap (position|letter) (\w|\d*) with \1 (\w|\d*)")]
        private static partial Regex MyRegex();
        [GeneratedRegex(@"^rotate (left|right|based on position of letter) (\w|\d*)")]
        private static partial Regex MyRegex1();
        [GeneratedRegex(@"^(reverse|move) positions? (\d*) (through|to position) (\d*)")]
        private static partial Regex MyRegex2();
        #endregion

        #region UnitTest
        public static string PartOne_Test(List<string> data) => PartOne0(data);

        public static string PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _21_ScrambledLettersAndHash(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_21_ScrambledLettersAndHash));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}