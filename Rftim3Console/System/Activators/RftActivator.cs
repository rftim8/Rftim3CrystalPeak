using System.Reflection;
using System.Runtime.Remoting;
using System.Text;

namespace Rftim3Console.System.Activators
{
    public class RftActivator
    {
        public RftActivator()
        {
            // Create an instance of the StringBuilder type using
            // Activator.CreateInstance.
            object? o = Activator.CreateInstance(typeof(StringBuilder));

            // Append a string into the StringBuilder object and display the
            // StringBuilder.
            StringBuilder? sb = o as StringBuilder;
            sb!.Append("Hello, there.");
            Console.WriteLine(sb);

            // Create an instance of the SomeType class that is defined in this
            // assembly.
            ObjectHandle? oh = Activator.CreateInstanceFrom(Assembly.GetEntryAssembly()!.Location, typeof(SomeType).FullName ?? "");

            // Call an instance method defined by the SomeType type using this object.
            SomeType? st = oh!.Unwrap() as SomeType;

            st!.DoSomething(5);
        }

        private class SomeType
        {
            public Action<int> DoSomething = DoSomething0;

            private static void DoSomething0(int x) => Console.WriteLine("100 / {0} = {1}", x, 100 / x);
        }
    }
}
