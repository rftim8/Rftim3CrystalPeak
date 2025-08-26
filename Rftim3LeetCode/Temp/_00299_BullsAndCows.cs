namespace Rftim3LeetCode.Temp
{
    public class _00299_BullsAndCows
    {
        /// <summary>
        /// You are playing the Bulls and Cows game with your friend.
        /// You write down a secret number and ask your friend to guess what the number is. 
        /// When your friend makes a guess, you provide a hint with the following info:
        /// The number of "bulls", which are digits in the guess that are in the correct position.
        /// The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position.
        /// Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        ///         Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        /// The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows.
        /// Note that both secret and guess may contain duplicate digits.
        /// </summary>
        public _00299_BullsAndCows()
        {
            Console.WriteLine(BullsAndCows0("1807", "7810"));
            Console.WriteLine(BullsAndCows0("1123", "0111"));
        }

        public static string BullsAndCows0(string a0, string a1) => RftBullsAndCows0(a0, a1);

        private static string RftBullsAndCows0(string secret, string guess)
        {
            int n = secret.Length;

            int a = 0, b = 0;
            Dictionary<char, int> a0 = [];
            Dictionary<char, int> b0 = [];

            for (int i = 0; i < n; i++)
            {
                if (secret[i] == guess[i]) a++;
                else
                {
                    if (a0.TryGetValue(secret[i], out int value)) a0[secret[i]] = ++value;
                    else a0.Add(secret[i], 1);

                    if (b0.TryGetValue(guess[i], out int value1)) b0[guess[i]] = ++value1;
                    else b0.Add(guess[i], 1);
                }
            }

            foreach (KeyValuePair<char, int> item in a0)
            {
                if (b0.TryGetValue(item.Key, out int value))
                {
                    if (item.Value <= value) b += item.Value;
                    if (item.Value > value) b += value;
                }
            }

            return $"{a}A{b}B";
        }
    }
}