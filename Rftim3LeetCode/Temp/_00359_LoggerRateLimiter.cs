using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00359_LoggerRateLimiter
    {
        /// <summary>
        /// Design a logger system that receives a stream of messages along with their timestamps. 
        /// Each unique message should only be printed at most every 10 seconds (i.e. a message printed at timestamp t will prevent other identical messages
        /// from being printed until timestamp t + 10).
        /// 
        /// All messages will come in chronological order.
        /// Several messages may arrive at the same timestamp.
        /// 
        /// Implement the Logger class:
        /// 
        /// Logger() Initializes the logger object.
        /// bool shouldPrintMessage(int timestamp, string message) Returns true if the message should be printed in the given timestamp, otherwise returns false.
        /// </summary>
        public _00359_LoggerRateLimiter()
        {
            List<bool?> a0 = LoggerRateLimiter0(
                ["Logger", "shouldPrintMessage", "shouldPrintMessage", "shouldPrintMessage", "shouldPrintMessage", "shouldPrintMessage", "shouldPrintMessage"],
                [[], [1, "foo"], [2, "bar"], [3, "foo"], [8, "bar"], [10, "foo"], [11, "foo"]]);
            RftTerminal.RftReadResult(a0);
        }

        public static List<bool?> LoggerRateLimiter0(List<string> a0, List<object?[]> a1) => RftLoggerRateLimiter0(a0, a1);

        private static List<bool?> RftLoggerRateLimiter0(List<string> a0, List<object?[]> a1)
        {
            List<bool?> res = [];

            Logger obj = new();
            for (int i = 1; i < a0.Count; i++)
            {
                res.Add(obj.ShouldPrintMessage((int)a1[i][0]!, (string)a1[i][1]!));
            }

            return res;
        }

        private class Logger
        {
            private readonly Dictionary<string, int> msgDict;

            public Logger()
            {
                msgDict = [];
            }

            public bool ShouldPrintMessage(int timestamp, string message)
            {
                if (!msgDict.TryGetValue(message, out int value))
                {
                    value = timestamp;
                    msgDict.Add(message, value);
                    return true;
                }

                int oldTimestamp = value;
                if (timestamp - oldTimestamp >= 10)
                {
                    if (msgDict.ContainsKey(message)) msgDict[message] = timestamp;
                    else msgDict[message] = timestamp;

                    return true;
                }
                else return false;
            }
        }

        private class Logger1
        {
            private readonly Dictionary<string, int> hash;

            public Logger1() => hash = [];

            public bool ShouldPrintMessage(int timestamp, string message)
            {
                if (timestamp - hash.GetValueOrDefault(message, -10) >= 10)
                {
                    hash[message] = timestamp;
                    return true;
                }

                return false;
            }
        }
    }
}
