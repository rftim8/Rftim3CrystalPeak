using System.Collections;

namespace Rftim3Convoy
{
    public class RftComparerReverse : IComparer
    {
        public int Compare(object? x, object? y)
        {
            return new CaseInsensitiveComparer().Compare(y, x);
        }
    }
}
