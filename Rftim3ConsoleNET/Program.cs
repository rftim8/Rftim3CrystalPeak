using System;

namespace Rftim3ConsoleNET
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args is null)
                throw new ArgumentNullException(nameof(args));
        }
    }
}
