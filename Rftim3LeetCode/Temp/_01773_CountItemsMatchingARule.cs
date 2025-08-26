namespace Rftim3LeetCode.Temp
{
    public class _01773_CountItemsMatchingARule
    {
        /// <summary>
        /// You are given an array items, where each items[i] = [typei, colori, namei] describes the type, color, and name of the ith item. 
        /// You are also given a rule represented by two strings, ruleKey and ruleValue.
        /// The ith item is said to match the rule if one of the following is true:
        /// ruleKey == "type" and ruleValue == typei.
        /// ruleKey == "color" and ruleValue == colori.
        /// ruleKey == "name" and ruleValue == namei.
        /// Return the number of items that match the given rule.
        /// </summary>
        public _01773_CountItemsMatchingARule()
        {
            Console.WriteLine(CountItemsMatchingARule0(
            [
                [ "phone", "blue", "pixel" ],
                [ "computer","silver","lenovo" ],
                [ "phone", "gold", "iphone" ]
            ],
            "color",
            "silver"
            ));
            Console.WriteLine(CountItemsMatchingARule0(
            [
                [ "phone", "blue", "pixel" ],
                [ "computer","silver","phone" ],
                [ "phone", "gold", "iphone" ]
            ],
            "type",
            "phone"
            ));
        }

        public static int CountItemsMatchingARule0(IList<IList<string>> a0, string a1, string a2) => RftCountItemsMatchingARule0(a0, a1, a2);

        private static int RftCountItemsMatchingARule0(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            int c = 0;
            foreach (IList<string> item in items)
            {
                if (ruleKey == "color" && item[1] == ruleValue) c++;
                if (ruleKey == "type" && item[0] == ruleValue) c++;
                if (ruleKey == "name" && item[2] == ruleValue) c++;
            }

            return c;
        }
    }
}