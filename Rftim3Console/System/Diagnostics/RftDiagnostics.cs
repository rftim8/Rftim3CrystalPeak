using System.Diagnostics;

namespace Rftim3Console.System.Diagnostics
{
    public class RftDiagnostics
    {
        public RftDiagnostics()
        {
            RftLogTypes();
            Console.WriteLine();
        }

        private static void RftLogTypes()
        {
            int count = 0;

            Console.WriteLine("This message is readable by the end user.");
            Trace.WriteLine("This is a trace message when tracing the app.");
            Debug.WriteLine("This is a debug message just for developers.");
            Debug.WriteLineIf(count == 0, "The count is 0.");

            bool errorFlag = true;
            Trace.WriteIf(errorFlag, "Error in AppendData procedure.\n");
            Debug.WriteIf(errorFlag, "Transaction abandoned.\n");
            Trace.Write("Invalid value for data request\n");

            //int dividend = 4;
            int divisor = 2;
            Trace.Assert(divisor != 0, $"{nameof(divisor)} is 0 and will cause an exception.");
            Debug.Assert(divisor != 0, $"{nameof(divisor)} is 0 and will cause an exception.");
        }
    }
}
