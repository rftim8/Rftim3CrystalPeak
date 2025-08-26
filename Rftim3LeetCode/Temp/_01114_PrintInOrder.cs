namespace Rftim3LeetCode.Temp
{
    public class _01114_PrintInOrder
    {
        /// <summary>
        /// Suppose we have a class:
        /// public class Foo
        /// {
        ///     public void first() { print("first"); }
        ///     public void second() { print("second"); }
        ///     public void third() { print("third"); }
        /// }
        /// The same instance of Foo will be passed to three different threads.
        /// Thread A will call first(), thread B will call second(), and thread C will call third().
        /// Design a mechanism and modify the program to ensure that second() is executed after first(), and third() is executed after second().
        /// Note:
        /// We do not know how the threads will be scheduled in the operating system, even though the numbers in the input seem to imply the ordering.
        /// The input format you see is mainly to ensure our tests' comprehensiveness.
        /// </summary>
        public _01114_PrintInOrder()
        {
            Foo.First(() => Console.WriteLine("first"));
            Foo.Second(() => Console.WriteLine("second"));
            Foo.Third(() => Console.WriteLine("third"));
        }

        private class Foo
        {
            private static readonly AutoResetEvent s = new(false);
            private static readonly AutoResetEvent t = new(false);

            public Foo() { }

            public static void First(Action printFirst)
            {
                printFirst();
                s.Set();
            }

            public static void Second(Action printSecond)
            {
                s.WaitOne();
                printSecond();
                t.Set();
            }

            public static void Third(Action printThird)
            {
                t.WaitOne();
                printThird();
            }
        }
    }
}
