namespace Rftim3Console.Syntax.Operators
{
    public class OperatorOverloading0
    {
        public OperatorOverloading0()
        {
            MyList<int> a = new()
            {
                Count = 4,
                Items = [5, 2, 3]
            };

            MyList<int> b = new()
            {
                Count = 4,
                Items = [1, 2, 3, 4]
            };

            Console.WriteLine(a.Equals(b));
        }

        private class MyList<T>
        {
            public int Count { get; set; }
            public List<int>? Items { get; set; }

            public MyList()
            {

            }

            public static bool operator ==(MyList<T> a, MyList<T> b) => Equals(a, b);

            public static bool operator !=(MyList<T> a, MyList<T> b) => !Equals(a, b);

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public bool Equals(MyList<T> other) => Equals(this, other);

            public override bool Equals(object? obj)
            {
                if (ReferenceEquals(this, obj)) return true;

                if (obj is null) return false;

                throw new NotImplementedException();
            }

            private static bool Equals(MyList<T> a, MyList<T> b)
            {
                if (a is null) return b is null;

                if (b is null || a.Count != b.Count) return false;

                for (int i = 0; i < a.Count; i++)
                {
                    if (!Equals(a.Items![i], b.Items![i])) return false;
                }

                return true;
            }
        }
    }
}
