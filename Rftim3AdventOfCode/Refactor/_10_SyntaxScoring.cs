using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3Convoy.Services.Host.CP.AdventOfCode.Data;
using Rftim3Convoy.Services.Static.CP.AdventOfCode.Data;

namespace Rftim3AdventOfCode.Refactor
{
    public class _10_SyntaxScoring : I_10_SyntaxScoring
    {
        #region Static
        private readonly List<string>? data;

        public _10_SyntaxScoring()
        {
            data = RftAdventOfCodeStaticData.Input_Test(testType: false, problemName: nameof(_10_SyntaxScoring));
        }

        /// <summary>
        /// You ask the submarine to determine the best route out of the deep-sea cave, but it only replies:
        /// 
        /// Syntax error in navigation subsystem on line: all of them
        /// All of them?! The damage is worse than you thought.You bring up a copy of the navigation subsystem (your puzzle input).
        /// 
        /// The navigation subsystem syntax is made of several lines containing chunks.
        /// There are one or more chunks on each line, and chunks contain zero or more other chunks.
        /// Adjacent chunks are not separated by any delimiter; if one chunk stops, the next chunk(if any) can immediately start.
        /// Every chunk must open and close with one of four legal pairs of matching characters:
        /// 
        /// If a chunk opens with(, it must close with).
        /// If a chunk opens with[, it must close with].
        /// If a chunk opens with {, it must close with }.
        /// If a chunk opens with<, it must close with>.
        /// So, () is a legal chunk that contains no other chunks, as is []. More complex but valid chunks include([]), {() () ()
        /// }, < ([{ }])>, [<>({}){ }
        /// [([])<>]], and even(((((((((()))))))))).
        /// 
        /// Some lines are incomplete, but others are corrupted. Find and discard the corrupted lines first.
        /// 
        /// A corrupted line is one where a chunk closes with the wrong character - that is, 
        /// where the characters it opens and closes with do not form one of the four legal pairs listed above.
        /// 
        /// Examples of corrupted chunks include (], {()()()>, (((()))}, and < ([]){ ()}
        /// [{}]). Such a chunk can appear anywhere within a line, and its presence causes the whole line to be considered corrupted.
        /// 
        /// For example, consider the following navigation subsystem:
        /// 
        /// [({(< (())[] > [[{[]{< () <>>
        /// [(()[<>])]({[<{<< [] >> (
        /// {([(<{}[<>[]}>{
        ///     []
        ///     {
        ///         [(< () >
        /// (((({<>}<{<{<>}
        ///             {
        ///                 []
        ///                 {
        ///                     [] { }
        ///                     [[< [([]))< ([[{ }
        ///                     [[()]]]
        /// [{
        ///                         [{ ({ }]{ } } ([{
        ///                             [{
        ///                                 { { } } ([]
        /// {< [[]] >}<{
        ///                                     [{
        ///                                         [{
        ///                                             []
        ///                                             {
        ///                                                 ()[[[]
        /// [< (< (< (<{ }))>< ([]([]()
        /// <{
        ///                                                     ([([[(<> ()){ }]> (<<{
        ///                                                         {
        /// <{
        ///                                                                 ([{ { } }
        ///                                                                 [< [[[<>{ }]]]> []]
        /// Some of the lines aren't corrupted, just incomplete; you can ignore these lines for now. The remaining five lines are corrupted:
        /// 
        /// { ([(<{ } [<> []}>{
        ///                                                                     [] { [(< () > -Expected ], but found }
        ///                                                                     instead.
        /// [[< [([]))< ([[{ }
        ///                                                                     [[()]]] -Expected ], but found ) instead.
        /// [{
        ///                                                                         [{ ({ }]{ } } ([{
        ///                                                                             [{
        ///                                                                                 { { } } ([] - Expected), but found ] instead.
        /// [< (< (< (<{ }))>< ([]([]() - Expected >, but found) instead.
        /// <{
        ///                                                                                     ([([[(<> ()){ }]> (<<{
        ///                                                                                         {
        ///                                                                                             -Expected ], but found > instead.
        /// Stop at the first incorrect closing character on each corrupted line.
        /// 
        /// Did you know that syntax checkers actually have contests to see who can get the high score for syntax errors in a file ? It's true!
        /// To calculate the syntax error score for a line, take the first illegal character on the line and look it up in the following table:
        /// 
        /// ): 3 points.
        /// ]: 57 points.
        /// }: 1197 points.
        /// >: 25137 points.
        /// In the above example, an illegal ) was found twice(2 * 3 = 6 points), an illegal ] was found once(57 points), an illegal }
        /// was found once(1197 points), and an illegal > was found once(25137 points). 
        /// So, the total syntax error score for this file is 6 + 57 + 1197 + 25137 = 26397 points!
        /// 
        /// Find the first illegal character in each corrupted line of the navigation subsystem.What is the total syntax error score for those errors?
        /// </summary>
        [Benchmark]
        public int PartOne() => PartOne0(data!);

        private static int PartOne0(List<string> input)
        {
            (List<char> corrupted, List<Stack<char>> autocompleted) = ParseLines(input);

            int corrupted_score = corrupted.Sum(CorruptedScore);

            static int CorruptedScore(char c) => c switch { ')' => 3, ']' => 57, '}' => 1197, '>' => 25137, _ => 0 };

            return corrupted_score;
        }

        /// <summary>
        /// Now, discard the corrupted lines. The remaining lines are incomplete.
        /// 
        /// Incomplete lines don't have any incorrect characters - instead, they're missing some closing characters at the end of the line.
        /// To repair the navigation subsystem, you just need to figure out the sequence of closing characters that complete all open chunks in the line.
        /// 
        /// You can only use closing characters (), ], }, or >), and you must add them in the correct order so that only legal pairs are formed and all chunks end up closed.
        /// 
        /// In the example above, there are five incomplete lines:
        /// 
        /// [({ (< (())[] > [[{ [] {< () <>> -Complete by adding } }]])})].
        /// [(()[<>])] ({[<{<<[]>>( - Complete by adding )}>]}).
        /// (((({<>}<{<{<>} { [] { [] { } -Complete by adding } }>}>)))).
        /// {< [[]] >}<{ [{ [{ [] { ()[[[] - Complete by adding]]} }]}]}>.
        /// <{ ([{ { } } [< [[[<>{ }]]]> []] -Complete by adding ])}>.
        /// Did you know that autocomplete tools also have contests? It's true! The score is determined by considering the completion string character-by-character.
        /// Start with a total score of 0. Then, for each character, multiply the total score by 5 and then increase the total score by the point value 
        /// given for the character in the following table:
        /// 
        /// ): 1 point.
        /// ]: 2 points.
        /// }: 3 points.
        /// >: 4 points.
        /// So, the last completion string above - ])}> -would be scored as follows:
        /// 
        /// Start with a total score of 0.
        /// Multiply the total score by 5 to get 0, then add the value of ] (2) to get a new total score of 2.
        /// Multiply the total score by 5 to get 10, then add the value of ) (1) to get a new total score of 11.
        /// Multiply the total score by 5 to get 55, then add the value of } (3) to get a new total score of 58.
        /// Multiply the total score by 5 to get 290, then add the value of > (4) to get a new total score of 294.
        /// The five lines' completion strings have total scores as follows:
        /// 
        /// }}]])})] -288957 total points.
        /// )}>]}) -5566 total points.
        /// }}>}>)))) -1480781 total points.
        /// ]]}}]}]}> -995444 total points.
        /// ])}> -294 total points.
        /// Autocomplete tools are an odd bunch: the winner is found by sorting all of the scores and then taking the middle score.
        /// (There will always be an odd number of scores to consider.)
        /// In this example, the middle score is 288957 because there are the same number of scores smaller and larger than it.
        /// 
        /// Find the completion string for each incomplete line, score the completion strings, and sort the scores. What is the middle score?
        /// </summary>        
        [Benchmark]
        public long PartTwo() => PartTwo0(data!);

        private static long PartTwo0(List<string> input)
        {
            (List<char> corrupted, List<Stack<char>> autocompleted) = ParseLines(input);

            long autocompleted_score = autocompleted
                .Select(x => x.Aggregate(0L, (a, x) => a * 5 + AutocompleteScore(x)))
                .OrderBy(x => x)
                .Skip(autocompleted.Count / 2)
                .Take(1)
                .Single();

            static int AutocompleteScore(char c) => c switch { '(' => 1, '[' => 2, '{' => 3, '<' => 4, _ => 0 };

            return autocompleted_score;
        }

        private static (List<char> corrupted, List<Stack<char>> autocompleted) ParseLines(List<string> input)
        {
            List<char> corrupted = [];
            List<Stack<char>> autocompleted = [];

            foreach (string line in input)
            {
                Stack<char> stack = new();
                foreach (char c in line)
                {
                    if (c is '(' or '[' or '{' or '<')
                    {
                        stack.Push(c);
                        continue;
                    }

                    (char, char c) pair = (stack.Pop(), c);
                    if (!(pair is ('(', ')') or ('[', ']') or ('{', '}') or ('<', '>')))
                    {
                        corrupted.Add(c);
                        stack.Clear();
                        break;
                    }
                }

                if (stack.Count != 0) autocompleted.Add(stack);
            }

            return (corrupted, autocompleted);
        }
        #endregion

        #region UnitTest
        public static int PartOne_Test(List<string> data) => PartOne0(data);

        public static long PartTwo_Test(List<string> data) => PartTwo0(data);
        #endregion

        #region Host
        private readonly IRftAdventOfCodeHostData? RftAdventOfCodeHostData;

        public _10_SyntaxScoring(IHost host)
        {
            RftAdventOfCodeHostData = host.Services.GetRequiredService<IRftAdventOfCodeHostData>();
            data = RftAdventOfCodeHostData.Input_Test(problemName: nameof(_10_SyntaxScoring));
        }

        public void PrintSolution()
        {
            Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
        }
        #endregion
    }
}