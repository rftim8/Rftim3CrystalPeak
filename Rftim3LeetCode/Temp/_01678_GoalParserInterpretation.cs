namespace Rftim3LeetCode.Temp
{
    public class _01678_GoalParserInterpretation
    {
        /// <summary>
        /// You own a Goal Parser that can interpret a string command. The command consists of an alphabet of "G", "()" and/or "(al)" in some order. 
        /// The Goal Parser will interpret "G" as the string "G", "()" as the string "o", and "(al)" as the string "al".
        /// The interpreted strings are then concatenated in the original order.
        /// Given the string command, return the Goal Parser's interpretation of command.
        /// </summary>
        public _01678_GoalParserInterpretation()
        {
            Console.WriteLine(Interpret("G()(al)"));
            Console.WriteLine(Interpret("G()()()()(al)"));
            Console.WriteLine(Interpret("(al)G(al)()()G"));
        }

        private static string Interpret(string command)
        {
            return command.Replace("()", "o").Replace("(", "").Replace(")", "");
        }
    }
}
