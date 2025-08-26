namespace Rftim3LeetCode.Temp
{
    public class _02299_StrongPasswordChecker2
    {
        /// <summary>
        /// A password is said to be strong if it satisfies all the following criteria:
        /// It has at least 8 characters.
        /// It contains at least one lowercase letter.
        /// It contains at least one uppercase letter.
        /// It contains at least one digit.
        /// It contains at least one special character. 
        /// The special characters are the characters in the following string: "!@#$%^&*()-+".
        /// It does not contain 2 of the same character in adjacent positions (i.e., "aab" violates this condition, but "aba" does not).
        /// Given a string password, return true if it is a strong password.Otherwise, return false.
        /// </summary>
        public _02299_StrongPasswordChecker2()
        {
            Console.WriteLine(StrongPasswordCheckerII("IloveLe3tcode!"));
            Console.WriteLine(StrongPasswordCheckerII("Me+You--IsMyDream"));
            Console.WriteLine(StrongPasswordCheckerII("1aB!"));
            Console.WriteLine(StrongPasswordCheckerII("11A!A!Aa"));
            Console.WriteLine(StrongPasswordCheckerII("aA0!bB1@@3rbHkB8Puvl"));
        }

        private static bool StrongPasswordCheckerII(string password)
        {
            int n = password.Length;
            if (n < 8) return false;

            bool l = false;
            bool u = false;
            bool d = false;
            bool s = false;
            for (int i = 0; i < n; i++)
            {
                if (i != 0) if (password[i] == password[i - 1]) return false;
                if (!l) if (char.IsLower(password[i])) l = true;
                if (!u) if (char.IsUpper(password[i])) u = true;
                if (!d) if (char.IsDigit(password[i])) d = true;
                if (!s) if (!char.IsLetterOrDigit(password[i])) s = true;
            }

            return l && u && d && s;
        }
    }
}
