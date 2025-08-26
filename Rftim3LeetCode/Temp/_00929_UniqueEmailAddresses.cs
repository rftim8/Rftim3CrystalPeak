namespace Rftim3LeetCode.Temp
{
    public class _00929_UniqueEmailAddresses
    {
        /// <summary>
        /// Every valid email consists of a local name and a domain name, separated by the '@' sign. 
        /// Besides lowercase letters, the email may contain one or more '.' or '+'.
        /// For example, in "alice@leetcode.com", "alice" is the local name, and "leetcode.com" is the domain name.
        /// If you add periods '.' between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.
        /// Note that this rule does not apply to domain names.
        /// For example, "alice.z@leetcode.com" and "alicez@leetcode.com" forward to the same email address.
        /// If you add a plus '+' in the local name, everything after the first plus sign will be ignored.
        /// This allows certain emails to be filtered.
        /// Note that this rule does not apply to domain names.
        /// For example, "m.y+name@email.com" will be forwarded to "my@email.com".
        /// It is possible to use both of these rules at the same time.
        /// Given an array of strings emails where we send one email to each emails[i], return the number of different addresses that actually receive mails.
        /// </summary>
        public _00929_UniqueEmailAddresses()
        {
            Console.WriteLine(NumUniqueEmails(["test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com"]));
            Console.WriteLine(NumUniqueEmails(["a@leetcode.com", "b@leetcode.com", "c@leetcode.com"]));
            Console.WriteLine(NumUniqueEmails([
                "fg.r.u.uzj+o.pw@kziczvh.com",
                "r.cyo.g+d.h+b.ja@tgsg.z.com",
                "fg.r.u.uzj+o.f.d@kziczvh.com",
                "r.cyo.g+ng.r.iq@tgsg.z.com",
                "fg.r.u.uzj+lp.k@kziczvh.com",
                "r.cyo.g+n.h.e+n.g@tgsg.z.com",
                "fg.r.u.uzj+k+p.j@kziczvh.com",
                "fg.r.u.uzj+w.y+b@kziczvh.com",
                "r.cyo.g+x+d.c+f.t@tgsg.z.com",
                "r.cyo.g+x+t.y.l.i@tgsg.z.com",
                "r.cyo.g+brxxi@tgsg.z.com",
                "r.cyo.g+z+dr.k.u@tgsg.z.com",
                "r.cyo.g+d+l.c.n+g@tgsg.z.com",
                "fg.r.u.uzj+vq.o@kziczvh.com",
                "fg.r.u.uzj+uzq@kziczvh.com",
                "fg.r.u.uzj+mvz@kziczvh.com",
                "fg.r.u.uzj+taj@kziczvh.com",
                "fg.r.u.uzj+fek@kziczvh.com"
            ]));
        }

        private static int NumUniqueEmails(string[] emails)
        {
            HashSet<string> hs = [];

            foreach (string email in emails)
            {
                string local = email.Split('@')[0];
                string local0 = local.Contains('+') ? local[..local.IndexOf('+')].Replace(".", "") : local.Replace(".", "");
                string domain = email.Split('@')[1];
                hs.Add(local0 + "@" + domain);
            }

            return hs.Count;
        }
    }
}
